﻿#pragma checksum "C:\git\GuzzleR\GuzzlerMobileApp\views\devices.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "16093E59B2A69F993B8D65FFBA1000E6"
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
    partial class devices : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(global::Windows.UI.Xaml.Controls.Primitives.Selector obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.SelectedItem = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Control_IsEnabled(global::Windows.UI.Xaml.Controls.Control obj, global::System.Boolean value)
            {
                obj.IsEnabled = value;
            }
        };

        private class devices_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            Idevices_Bindings
        {
            private global::GuzzlerMobileApp.views.devices dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ComboBox obj3;
            private global::Windows.UI.Xaml.Controls.HyperlinkButton obj4;
            private global::Windows.UI.Xaml.Controls.ComboBox obj5;

            private devices_obj1_BindingsTracking bindingsTracking;

            public devices_obj1_Bindings()
            {
                this.bindingsTracking = new devices_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3:
                        this.obj3 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        (this.obj3).RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty,
                            (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
                            {
                                if (this.initialized)
                                {
                                    // Update Two Way binding
                                    this.dataRoot.DevToRemove = (this.obj3).SelectedItem != null ? (this.obj3).SelectedItem.ToString() : null;
                                }
                            });
                        break;
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.HyperlinkButton)target;
                        (this.obj4).RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Control.IsEnabledProperty,
                            (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
                            {
                                if (this.initialized)
                                {
                                    // Update Two Way binding
                                    this.dataRoot.IsNextEnabled = (this.obj4).IsEnabled;
                                }
                            });
                        break;
                    case 5:
                        this.obj5 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        (this.obj5).RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty,
                            (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
                            {
                                if (this.initialized)
                                {
                                    // Update Two Way binding
                                    this.dataRoot.ChosenDev = (this.obj5).SelectedItem != null ? (this.obj5).SelectedItem.ToString() : null;
                                }
                            });
                        break;
                    default:
                        break;
                }
            }

            // Idevices_Bindings

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

            // devices_obj1_Bindings

            public void SetDataRoot(global::GuzzlerMobileApp.views.devices newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::GuzzlerMobileApp.views.devices obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_DevToRemove(obj.DevToRemove, phase);
                        this.Update_IsNextEnabled(obj.IsNextEnabled, phase);
                        this.Update_ChosenDev(obj.ChosenDev, phase);
                    }
                }
            }
            private void Update_DevToRemove(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj3, obj, null);
                }
            }
            private void Update_IsNextEnabled(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Control_IsEnabled(this.obj4, obj);
                }
            }
            private void Update_ChosenDev(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj5, obj, null);
                }
            }

            private class devices_obj1_BindingsTracking
            {
                global::System.WeakReference<devices_obj1_Bindings> WeakRefToBindingObj; 

                public devices_obj1_BindingsTracking(devices_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<devices_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_(null);
                }

                public void PropertyChanged_(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    devices_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::GuzzlerMobileApp.views.devices obj = sender as global::GuzzlerMobileApp.views.devices;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_DevToRemove(obj.DevToRemove, DATA_CHANGED);
                                    bindings.Update_IsNextEnabled(obj.IsNextEnabled, DATA_CHANGED);
                                    bindings.Update_ChosenDev(obj.ChosenDev, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "DevToRemove":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_DevToRemove(obj.DevToRemove, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "IsNextEnabled":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_IsNextEnabled(obj.IsNextEnabled, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "ChosenDev":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ChosenDev(obj.ChosenDev, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void UpdateChildListeners_(global::GuzzlerMobileApp.views.devices obj)
                {
                    devices_obj1_Bindings bindings;
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
                    #line 83 "..\..\..\views\devices.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Click += this.removeDev_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.removeDev = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.HyperlinkButton element4 = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    #line 60 "..\..\..\views\devices.xaml"
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)element4).Click += this.Next_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.chooseDev = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 38 "..\..\..\views\devices.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.regNewDev_click;
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
                    devices_obj1_Bindings bindings = new devices_obj1_Bindings();
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

