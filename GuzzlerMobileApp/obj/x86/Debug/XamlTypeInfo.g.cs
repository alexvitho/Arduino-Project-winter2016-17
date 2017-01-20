﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace GuzzlerMobileApp
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
    private global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlTypeInfoProvider _provider;

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        /// <summary>
        /// GetXamlType(String)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            if(_provider == null)
            {
                _provider = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        /// <summary>
        /// GetXmlnsDefinitions()
        /// </summary>
        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByType(type);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByName(typeName);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[12];
            _typeNameTable[0] = "GuzzlerMobileApp.QuickStartTask";
            _typeNameTable[1] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[2] = "Int32";
            _typeNameTable[3] = "String";
            _typeNameTable[4] = "Boolean";
            _typeNameTable[5] = "GuzzlerMobileApp.ExtendedSplash";
            _typeNameTable[6] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[7] = "GuzzlerMobileApp.MainPage";
            _typeNameTable[8] = "GuzzlerMobileApp.views.checkNow";
            _typeNameTable[9] = "GuzzlerMobileApp.views.devices";
            _typeNameTable[10] = "GuzzlerMobileApp.views.regDev";
            _typeNameTable[11] = "GuzzlerMobileApp.views.specialDev";

            _typeTable = new global::System.Type[12];
            _typeTable[0] = typeof(global::GuzzlerMobileApp.QuickStartTask);
            _typeTable[1] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[2] = typeof(global::System.Int32);
            _typeTable[3] = typeof(global::System.String);
            _typeTable[4] = typeof(global::System.Boolean);
            _typeTable[5] = typeof(global::GuzzlerMobileApp.ExtendedSplash);
            _typeTable[6] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[7] = typeof(global::GuzzlerMobileApp.MainPage);
            _typeTable[8] = typeof(global::GuzzlerMobileApp.views.checkNow);
            _typeTable[9] = typeof(global::GuzzlerMobileApp.views.devices);
            _typeTable[10] = typeof(global::GuzzlerMobileApp.views.regDev);
            _typeTable[11] = typeof(global::GuzzlerMobileApp.views.specialDev);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_0_QuickStartTask() { return new global::GuzzlerMobileApp.QuickStartTask(); }
        private object Activate_7_MainPage() { return new global::GuzzlerMobileApp.MainPage(); }
        private object Activate_9_devices() { return new global::GuzzlerMobileApp.views.devices(); }
        private object Activate_10_regDev() { return new global::GuzzlerMobileApp.views.regDev(); }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  GuzzlerMobileApp.QuickStartTask
                userType = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
                userType.Activator = Activate_0_QuickStartTask;
                userType.AddMemberName("Number");
                userType.AddMemberName("Title");
                userType.AddMemberName("Description");
                userType.AddMemberName("ShowMinimal");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  Int32
                xamlType = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 3:   //  String
                xamlType = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 4:   //  Boolean
                xamlType = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 5:   //  GuzzlerMobileApp.ExtendedSplash
                userType = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 6:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 7:   //  GuzzlerMobileApp.MainPage
                userType = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_7_MainPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 8:   //  GuzzlerMobileApp.views.checkNow
                userType = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.AddMemberName("DevName");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 9:   //  GuzzlerMobileApp.views.devices
                userType = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_9_devices;
                userType.AddMemberName("IsNextEnabled");
                userType.AddMemberName("ChosenDev");
                userType.AddMemberName("DevToRemove");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 10:   //  GuzzlerMobileApp.views.regDev
                userType = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_10_regDev;
                userType.AddMemberName("DevName");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 11:   //  GuzzlerMobileApp.views.specialDev
                userType = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.AddMemberName("DeviceName");
                userType.SetIsLocalType();
                xamlType = userType;
                break;
            }
            return xamlType;
        }


        private object get_0_QuickStartTask_Number(object instance)
        {
            var that = (global::GuzzlerMobileApp.QuickStartTask)instance;
            return that.Number;
        }
        private void set_0_QuickStartTask_Number(object instance, object Value)
        {
            var that = (global::GuzzlerMobileApp.QuickStartTask)instance;
            that.Number = (global::System.Int32)Value;
        }
        private object get_1_QuickStartTask_Title(object instance)
        {
            var that = (global::GuzzlerMobileApp.QuickStartTask)instance;
            return that.Title;
        }
        private void set_1_QuickStartTask_Title(object instance, object Value)
        {
            var that = (global::GuzzlerMobileApp.QuickStartTask)instance;
            that.Title = (global::System.String)Value;
        }
        private object get_2_QuickStartTask_Description(object instance)
        {
            var that = (global::GuzzlerMobileApp.QuickStartTask)instance;
            return that.Description;
        }
        private void set_2_QuickStartTask_Description(object instance, object Value)
        {
            var that = (global::GuzzlerMobileApp.QuickStartTask)instance;
            that.Description = (global::System.String)Value;
        }
        private object get_3_QuickStartTask_ShowMinimal(object instance)
        {
            var that = (global::GuzzlerMobileApp.QuickStartTask)instance;
            return that.ShowMinimal;
        }
        private void set_3_QuickStartTask_ShowMinimal(object instance, object Value)
        {
            var that = (global::GuzzlerMobileApp.QuickStartTask)instance;
            that.ShowMinimal = (global::System.Boolean)Value;
        }
        private object get_4_checkNow_DevName(object instance)
        {
            var that = (global::GuzzlerMobileApp.views.checkNow)instance;
            return that.DevName;
        }
        private object get_5_devices_IsNextEnabled(object instance)
        {
            var that = (global::GuzzlerMobileApp.views.devices)instance;
            return that.IsNextEnabled;
        }
        private void set_5_devices_IsNextEnabled(object instance, object Value)
        {
            var that = (global::GuzzlerMobileApp.views.devices)instance;
            that.IsNextEnabled = (global::System.Boolean)Value;
        }
        private object get_6_devices_ChosenDev(object instance)
        {
            var that = (global::GuzzlerMobileApp.views.devices)instance;
            return that.ChosenDev;
        }
        private void set_6_devices_ChosenDev(object instance, object Value)
        {
            var that = (global::GuzzlerMobileApp.views.devices)instance;
            that.ChosenDev = (global::System.String)Value;
        }
        private object get_7_devices_DevToRemove(object instance)
        {
            var that = (global::GuzzlerMobileApp.views.devices)instance;
            return that.DevToRemove;
        }
        private void set_7_devices_DevToRemove(object instance, object Value)
        {
            var that = (global::GuzzlerMobileApp.views.devices)instance;
            that.DevToRemove = (global::System.String)Value;
        }
        private object get_8_regDev_DevName(object instance)
        {
            var that = (global::GuzzlerMobileApp.views.regDev)instance;
            return that.DevName;
        }
        private void set_8_regDev_DevName(object instance, object Value)
        {
            var that = (global::GuzzlerMobileApp.views.regDev)instance;
            that.DevName = (global::System.String)Value;
        }
        private object get_9_specialDev_DeviceName(object instance)
        {
            var that = (global::GuzzlerMobileApp.views.specialDev)instance;
            return that.DeviceName;
        }
        private void set_9_specialDev_DeviceName(object instance, object Value)
        {
            var that = (global::GuzzlerMobileApp.views.specialDev)instance;
            that.DeviceName = (global::System.String)Value;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlMember xamlMember = null;
            global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "GuzzlerMobileApp.QuickStartTask.Number":
                userType = (global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("GuzzlerMobileApp.QuickStartTask");
                xamlMember = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlMember(this, "Number", "Int32");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_0_QuickStartTask_Number;
                xamlMember.Setter = set_0_QuickStartTask_Number;
                break;
            case "GuzzlerMobileApp.QuickStartTask.Title":
                userType = (global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("GuzzlerMobileApp.QuickStartTask");
                xamlMember = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlMember(this, "Title", "String");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_1_QuickStartTask_Title;
                xamlMember.Setter = set_1_QuickStartTask_Title;
                break;
            case "GuzzlerMobileApp.QuickStartTask.Description":
                userType = (global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("GuzzlerMobileApp.QuickStartTask");
                xamlMember = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlMember(this, "Description", "String");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_2_QuickStartTask_Description;
                xamlMember.Setter = set_2_QuickStartTask_Description;
                break;
            case "GuzzlerMobileApp.QuickStartTask.ShowMinimal":
                userType = (global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("GuzzlerMobileApp.QuickStartTask");
                xamlMember = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlMember(this, "ShowMinimal", "Boolean");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_3_QuickStartTask_ShowMinimal;
                xamlMember.Setter = set_3_QuickStartTask_ShowMinimal;
                break;
            case "GuzzlerMobileApp.views.checkNow.DevName":
                userType = (global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("GuzzlerMobileApp.views.checkNow");
                xamlMember = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlMember(this, "DevName", "String");
                xamlMember.Getter = get_4_checkNow_DevName;
                xamlMember.SetIsReadOnly();
                break;
            case "GuzzlerMobileApp.views.devices.IsNextEnabled":
                userType = (global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("GuzzlerMobileApp.views.devices");
                xamlMember = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlMember(this, "IsNextEnabled", "Boolean");
                xamlMember.Getter = get_5_devices_IsNextEnabled;
                xamlMember.Setter = set_5_devices_IsNextEnabled;
                break;
            case "GuzzlerMobileApp.views.devices.ChosenDev":
                userType = (global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("GuzzlerMobileApp.views.devices");
                xamlMember = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlMember(this, "ChosenDev", "String");
                xamlMember.Getter = get_6_devices_ChosenDev;
                xamlMember.Setter = set_6_devices_ChosenDev;
                break;
            case "GuzzlerMobileApp.views.devices.DevToRemove":
                userType = (global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("GuzzlerMobileApp.views.devices");
                xamlMember = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlMember(this, "DevToRemove", "String");
                xamlMember.Getter = get_7_devices_DevToRemove;
                xamlMember.Setter = set_7_devices_DevToRemove;
                break;
            case "GuzzlerMobileApp.views.regDev.DevName":
                userType = (global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("GuzzlerMobileApp.views.regDev");
                xamlMember = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlMember(this, "DevName", "String");
                xamlMember.Getter = get_8_regDev_DevName;
                xamlMember.Setter = set_8_regDev_DevName;
                break;
            case "GuzzlerMobileApp.views.specialDev.DeviceName":
                userType = (global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("GuzzlerMobileApp.views.specialDev");
                xamlMember = new global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlMember(this, "DeviceName", "String");
                xamlMember.Getter = get_9_specialDev_DeviceName;
                xamlMember.Setter = set_9_specialDev_DeviceName;
                break;
            }
            return xamlMember;
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlSystemBaseType
    {
        global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::GuzzlerMobileApp.GuzzlerMobileApp_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}
