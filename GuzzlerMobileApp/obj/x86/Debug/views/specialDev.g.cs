﻿#pragma checksum "C:\Users\Alex\Desktop\GuzzlerMobileApp_Windows_CS\GuzzlerMobileApp\views\specialDev.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C0ACE930011782BF9C02E8750621EAF2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GuzzlerMobileApp.views
{
    partial class specialDev : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBox_Text(global::Windows.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        private class specialDev_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IspecialDev_Bindings
        {
            private global::GuzzlerMobileApp.views.specialDev dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBox obj4;

            private specialDev_obj1_BindingsTracking bindingsTracking;

            public specialDev_obj1_Bindings()
            {
                this.bindingsTracking = new specialDev_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        break;
                    default:
                        break;
                }
            }

            // IspecialDev_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            // specialDev_obj1_Bindings

            public void SetDataRoot(global::GuzzlerMobileApp.views.specialDev newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::GuzzlerMobileApp.views.specialDev obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_DeviceName(obj.DeviceName, phase);
                    }
                }
                else
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.UpdateFallback_DeviceName(phase);
                    }
                }
            }
            private void Update_DeviceName(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj4, obj, null);
                }
            }

            private void UpdateFallback_DeviceName(int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj4, "Name Of Device", null);
                }
            }

            private class specialDev_obj1_BindingsTracking
            {
                global::System.WeakReference<specialDev_obj1_Bindings> WeakRefToBindingObj; 

                public specialDev_obj1_BindingsTracking(specialDev_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<specialDev_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_(null);
                }

                public void PropertyChanged_(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    specialDev_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::GuzzlerMobileApp.views.specialDev obj = sender as global::GuzzlerMobileApp.views.specialDev;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_DeviceName(obj.DeviceName, DATA_CHANGED);
                            }
                            else
                            {
                                bindings.UpdateFallback_DeviceName(DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "DeviceName":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_DeviceName(obj.DeviceName, DATA_CHANGED);
                                    }
                                    else
                                    {
                                    bindings.UpdateFallback_DeviceName(DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void UpdateChildListeners_(global::GuzzlerMobileApp.views.specialDev obj)
                {
                    specialDev_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        if (bindings.dataRoot != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)bindings.dataRoot).PropertyChanged -= PropertyChanged_;
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.Button element2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 61 "..\..\..\views\specialDev.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Click += this.backButton_Click;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 43 "..\..\..\views\specialDev.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.checkNow_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    specialDev_obj1_Bindings bindings = new specialDev_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}
