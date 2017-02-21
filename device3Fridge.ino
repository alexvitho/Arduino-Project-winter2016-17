#include <NTPClient.h>
#include <WiFiUdp.h>
#include <ESP8266WiFi.h>
#include <Wire.h>
#include <Adafruit_ADS1015.h>
int counterS=0;


#define NTP_OFFSET   60 * 60      // In seconds
#define NTP_INTERVAL 60 * 1000    // In miliseconds
#define NTP_ADDRESS  "europe.pool.ntp.org"

WiFiUDP ntpUDP;
NTPClient timeClient(ntpUDP, NTP_ADDRESS, NTP_OFFSET, NTP_INTERVAL);

double counter=0.0;
// replace with your channel's thingspeak API key, 
String apiKey = "QVXNK9GF40AH0KXA";
//WIFI credentials go here
//const char* ssid = "Al-G3";  //alex's phone
//const char* password = "c7466474";
//const char* ssid = "Leonid";  //alex's phone
//const char* password = "ktubhs12";
const char* ssid = "de44607";  //alex's phone
const char* password = "c7466474";

String uri = "/devices/GD003/messages/events?api-version=2016-02-03";  //for IOT hub
//char * connectionString = "HostName=HubGuzz.azure-devices.net;DeviceId=NodeMcu1;SharedAccessKey=xmbgdaoRqLAXy/jHyNLFsLwFOZL61M7OLI8FpMzi7iI="; //for long time storage
//char * connectionString2 = "HostName=HubGuzzReal.azure-devices.net;DeviceId=NodeMcu1;SharedAccessKey=Zxet6apmCWfwq2VVS2+0jFrNRAQQbEV8TKmVQ2QSRnU="; // for real time storage
const char* server2 = "SharedAccessSignature sr=GuzzlerHub.azure-devices.net%2Fdevices%2FGD003&sig=wDfnw3eJnKPUG6dyBK9WCNeht2Wji7VIuKKVqHImf%2Bw%3D&se=1488112995"; //password for long time
const char* server3 = "SharedAccessSignature sr=GuzzlerRealTime.azure-devices.net%2Fdevices%2FGD003&sig=NE0AcMYLUzN7Vh6CkOOh4QILUQYmxBpjeB652fWUHh8%3D&se=1488113590"; //password for real time
Adafruit_ADS1115 ads;  /* Use this for the 16-bit version */
//Maximum value of ADS
#define ADC_COUNTS 32768
#define PHASECAL 1.7
#define VCAL 0.6
#define ICAL 0.003


WiFiClientSecure client;
WiFiClientSecure client2;

double filteredI;
double lastFilteredV,filteredV; //Filtered_ is the raw analog value minus the DC offset
int sampleV;                 //sample_ holds the raw analog read value
int sampleI; 

double offsetV;                          //Low-pass filter output
double offsetI;                          //Low-pass filter output
double temp=0;
double realPower,
       apparentPower,
       powerFactor,
       Vrms,
       Irms;
double phaseShiftedV; //Holds the calibrated phase shifted voltage.
int startV; //Instantaneous voltage at start of sample window.
double sqV,sumV,sqI,sumI,instP,sumP; //sq = squared, sum = Sum, inst = instantaneous
boolean lastVCross, checkVCross; //Used to measure number of times threshold is crossed.

double squareRoot(double fg)  
{
  double n = fg / 2.0;
  double lstX = 0.0;
  while (n != lstX)
  {
    lstX = n;
    n = (n + fg / n) / 2.0;
  }
  return n;
}

void calcVI(unsigned int crossings, unsigned int timeout)
{

  unsigned int crossCount = 0;                             //Used to measure number of times threshold is crossed.
  unsigned int numberOfSamples = 0;                        //This is now incremented  

  //-------------------------------------------------------------------------------------------------------------------------
  // 1) Waits for the waveform to be close to 'zero' (mid-scale adc) part in sin curve.
  //-------------------------------------------------------------------------------------------------------------------------
  boolean st=false;                                  //an indicator to exit the while loop

  unsigned long start = millis();    //millis()-start makes sure it doesnt get stuck in the loop if there is an error.

  while(st==false)                                   //the while loop...
  {
     startV = ads.readADC_Differential_2_3();                    //using the voltage waveform
     if ((abs(startV) < (ADC_COUNTS*0.55)) && (abs(startV) > (ADC_COUNTS*0.45))) st=true;  //check its within range
     if ((millis()-start)>timeout) st = true;
  }
  
  //-------------------------------------------------------------------------------------------------------------------------
  // 2) Main measurement loop
  //------------------------------------------------------------------------------------------------------------------------- 
  start = millis(); 

  while ((crossCount < crossings) && ((millis()-start)<timeout)) 
  {
    numberOfSamples++;                       //Count number of times looped.
    lastFilteredV = filteredV;               //Used for delay/phase compensation
    
    //-----------------------------------------------------------------------------
    // A) Read in raw voltage and current samples
    //-----------------------------------------------------------------------------
    sampleV = ads.readADC_Differential_2_3();                 //Read in raw voltage signal
    sampleI = ads.readADC_Differential_0_1();                 //Read in raw current signal

    //-----------------------------------------------------------------------------
    // B) Apply digital low pass filters to extract the 2.5 V or 1.65 V dc offset,
    //     then subtract this - signal is now centred on 0 counts.
    //-----------------------------------------------------------------------------
    offsetV = offsetV + ((sampleV-offsetV)/1024);
  filteredV = sampleV - offsetV;
    offsetI = offsetI + ((sampleI-offsetI)/1024);
  filteredI = sampleI - offsetI;
   
    //-----------------------------------------------------------------------------
    // C) Root-mean-square method voltage
    //-----------------------------------------------------------------------------  
    sqV= filteredV * filteredV;                 //1) square voltage values
    sumV += sqV;                                //2) sum
    
    //-----------------------------------------------------------------------------
    // D) Root-mean-square method current
    //-----------------------------------------------------------------------------   
    sqI = filteredI * filteredI;                //1) square current values
    sumI += sqI;                                //2) sum 
    
    //-----------------------------------------------------------------------------
    // E) Phase calibration
    //-----------------------------------------------------------------------------
    phaseShiftedV = lastFilteredV + PHASECAL * (filteredV - lastFilteredV); 
    
    //-----------------------------------------------------------------------------
    // F) Instantaneous power calc
    //-----------------------------------------------------------------------------   
    instP = phaseShiftedV * filteredI;          //Instantaneous Power
    sumP +=instP;                               //Sum  
    
    //-----------------------------------------------------------------------------
    // G) Find the number of times the voltage has crossed the initial voltage
    //    - every 2 crosses we will have sampled 1 wavelength 
    //    - so this method allows us to sample an integer number of half wavelengths which increases accuracy
    //-----------------------------------------------------------------------------       
    lastVCross = checkVCross;                     
    if (sampleV > startV) checkVCross = true; 
                     else checkVCross = false;
    if (numberOfSamples==1) lastVCross = checkVCross;                  
                     
    if (lastVCross != checkVCross) crossCount++;
  }
 
  //-------------------------------------------------------------------------------------------------------------------------
  // 3) Post loop calculations
  //------------------------------------------------------------------------------------------------------------------------- 
  //Calculation of the root of the mean of the voltage and current squared (rms)
  //Calibration coefficients applied. 
  float multiplier = 0.125F; /* ADS1115 @ +/- 4.096V gain (16-bit results) */
  double V_RATIO = VCAL * multiplier;
  Vrms = V_RATIO * squareRoot(sumV / numberOfSamples); 
  
  double I_RATIO = ICAL * multiplier;
  Irms = I_RATIO * squareRoot(sumI / numberOfSamples); 

  //Calculation power values
  realPower = V_RATIO * I_RATIO * sumP / numberOfSamples;
  apparentPower = Vrms * Irms;
  powerFactor=realPower / apparentPower;

  //Reset accumulators
  sumV = 0;
  sumI = 0;
  sumP = 0;
//--------------------------------------------------------------------------------------       
}

double calcIrms(unsigned int Number_of_Samples)
{
  /* Be sure to update this value based on the IC and the gain settings! */
  float multiplier = 0.125F;    /* ADS1115 @ +/- 4.096V gain (16-bit results) */
  for (unsigned int n = 0; n < Number_of_Samples; n++)
  {
    sampleI = ads.readADC_Differential_0_1();

    // Digital low pass filter extracts the 2.5 V or 1.65 V dc offset, 
  //  then subtract this - signal is now centered on 0 counts.
    offsetI = (offsetI + (sampleI-offsetI)/1024);
    filteredI = sampleI - offsetI;
    //filteredI = sampleI * multiplier;

    // Root-mean-square method current
    // 1) square current values
    sqI = filteredI * filteredI;
    // 2) sum 
    sumI += sqI;
  }
  
  Irms = squareRoot(sumI / Number_of_Samples)*multiplier; 

  //Reset accumulators
  sumI = 0;
//--------------------------------------------------------------------------------------       
 
  return Irms;
}

void setup() {
  Serial.begin(115200);
  delay(10);
 
  // We start by connecting to a WiFi network

  //Serial.println();
  //Serial.println();
  //Serial.print("Connecting to ");
  //Serial.println(ssid);
  
  WiFi.begin(ssid, password);
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("");
  Serial.println("WiFi connected");  
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());

  ads.setGain(GAIN_ONE);        // 1x gain   +/- 4.096V  1 bit = 0.125mV
  ads.begin();
   timeClient.begin();
}

void loop() {
   timeClient.update(); 
  calcVI(20,2000); 
  Serial.print("Real Power:");
  Serial.println(realPower);
 

  if (!client.connect("GuzzlerHub.azure-devices.net", 443)) { //connect iot hub
    Serial.println("connection failed");
    return;
  }
    String formattedTime = timeClient.getFormattedTime();
 unsigned long epcohTime =  timeClient.getEpochTime();
 String data = "{Id: \"GD003-17\"  , messageId:" + String(epcohTime)+ ", realPower:" + String(realPower) +"}";
  String request = String("POST ") +uri + " HTTP/1.1\r\n" +
               "Host: " + String("GuzzlerHub.azure-devices.net") + "\r\n" +
               "Authorization: " + server2 + "\r\n" +                
               "Content-Type: application/atom+xml;type=entry;charset=utf-8\r\n" + 
               "Content-Length: " + data.length() + "\r\n\r\n" +
               data;
  
  //counter+=0.01;   no longer need
  

  Serial.println(request);
  if (counterS==10 ){
    
  counterS=0;
  client.print(request);
  }
  counterS++;
 
  client.stop();
delay(20);
  
  if (!client.connect("GuzzlerRealTime.azure-devices.net",443)) { //connect to iot real
Serial.println("connection failed");
    return;
  }
  formattedTime = timeClient.getFormattedTime();
 epcohTime =  timeClient.getEpochTime();


   String data2 = "{Id: \"GD003-17\"  , messageId:" + String(epcohTime) + ", realPower:" + String(realPower) +"}";
  String request2 = String("POST ") +uri + " HTTP/1.1\r\n" +
               "Host: " + String("GuzzlerRealTime.azure-devices.net") + "\r\n" +
               "Authorization: " + server3 + "\r\n" +                
               "Content-Type: application/atom+xml;type=entry;charset=utf-8\r\n" + 
               "Content-Length: " + data2.length() + "\r\n\r\n" +
               data2;
  client.print(request2);
  client.stop();

  //Serial.println("Waiting...");    
  // thingspeak needs minimum 15 sec delay between updates
  delay(40);  
}
