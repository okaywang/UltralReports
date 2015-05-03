using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using WebExpress.Core;

namespace Website.Common
{
    public class RequestUrlAttribute : Attribute
    {
        public RequestUrlAttribute(string requestUrl)
        {
            RequestUrl = requestUrl;
        }
        public string RequestUrl { get; private set; }
    }

    public class HelpTextAttribute : Attribute
    {
        public HelpTextAttribute(string help)
        {
            this.HelpText = help;
        }
        public string HelpText { get; private set; }
    }

    public class ControlTypeAttribute : Attribute
    {
        private Type _controlType;
        private bool _enabled;
        public ControlTypeAttribute(Type controlType)
            : this(controlType, true) { }
        public ControlTypeAttribute(Type controlType, bool enabled)
        {
            _controlType = controlType;
            _enabled = enabled;
        }
        public Type ControlType { get { return _controlType; } }

        public bool Enabled { get { return _enabled; } }
    }

    public interface IControlSource
    {
        NameValuePair[] GetSource();
    }

    public class EnumControlSourceAttribute : Attribute, IControlSource
    {
        private Type _enumType;
        public EnumControlSourceAttribute(Type enumType)
        {
            _enumType = enumType;
        }
        public NameValuePair[] GetSource()
        {
            var items = Enum.GetValues(_enumType);
            var pairs = new List<NameValuePair>();
            foreach (var item in items)
            {
                var enumItem = item as Enum;
                var mi = _enumType.GetMember(item.ToString()).Single();
                pairs.Add(new NameValuePair { Name = mi.GetDisplayName(), Value = Convert.ToInt32(enumItem).ToString() });
            }
            return pairs.ToArray();
        }
    }

    //public class DisplayTextAttribute : Attribute
    //{
    //    private string _displayText;
    //    public DisplayTextAttribute(string displayText)
    //    {
    //        _displayText = displayText;
    //    }
    //    public string DisplayText
    //    {
    //        get { return _displayText; }
    //    }
    //}

    //public class DisplayFormatAttribute : Attribute
    //{
    //    private string _formatString;
    //    public DisplayFormatAttribute(string formatString)
    //    {
    //        _formatString = formatString;
    //    }
    //    public string FormatString
    //    {
    //        get { return _formatString; }
    //    }
    //}
    public class ValueConvertorAttribute : Attribute, IValueConvertor
    {
        private Type _convertType;
        public ValueConvertorAttribute(Type convertType)
        {
            _convertType = convertType;
        }

        public object Convert(object value)
        {
            var convertor = System.Activator.CreateInstance(_convertType) as IValueConvertor;
            return convertor.Convert(value);
        }
    }

    public interface IValueConvertor
    {
        object Convert(object value);
    }
    public static class RcExtenstion
    {
        public static string GetDisplayName(this MemberInfo prop)
        {
            if (prop == null)
            {
                return string.Empty;
            }
            var attr = prop.GetCustomAttribute<DisplayNameAttribute>();
            if (attr != null)
            {
                return attr.DisplayName;
            }
            var attr2 = prop.GetCustomAttribute<DisplayTextAttribute>();
            if (attr2 != null)
            {
                return attr2.DisplayText;
            }
            return prop.Name;
        }

        public static string GetRequestUrl(this MemberInfo prop)
        {
            if (prop == null)
            {
                return string.Empty;
            }
            var attr = prop.GetCustomAttribute<RequestUrlAttribute>();
            if (attr == null)
            {
                return string.Empty;
            }
            return attr.RequestUrl;
        }

        //public static string GetDisplayName(this MemberInfo mi)
        //{
        //    if (prop == null)
        //    {
        //        return string.Empty;
        //    }
        //    var attr = prop.GetCustomAttribute<DisplayNameAttribute>();
        //    if (attr == null)
        //    {
        //        return prop.Name;
        //    }
        //    return attr.DisplayName;
        //}

        public static IControl GetControl(this PropertyInfo prop)
        {
            ControlBase control = null;
            var attr = prop.GetCustomAttribute<ControlTypeAttribute>();
            var isRequired = prop.GetCustomAttribute<System.ComponentModel.DataAnnotations.RequiredAttribute>() != null;
            if (attr == null)
            {
                return new NativeInputText(prop.Name, true, isRequired);
            }
            if (typeof(ISourceControl).IsAssignableFrom(typeof(NativeSelect)))
            {
                var source = prop.GetCustomAttributes().FirstOrDefault(i => typeof(IControlSource).IsAssignableFrom(i.GetType())) as IControlSource;
                if (source != null)
                {
                    var pairs = source.GetSource();
                    var instance = Activator.CreateInstance(attr.ControlType, prop.Name, attr.Enabled, isRequired) as ISourceControl;
                    instance.Source = pairs;
                    control = instance as ControlBase;
                }
            }
            if (control == null)
            {
                control = Activator.CreateInstance(attr.ControlType, prop.Name, attr.Enabled, isRequired) as ControlBase;
            }

            var attrHelp = prop.GetCustomAttribute<HelpTextAttribute>();
            if (attrHelp != null)
            {
                control.HelpText = attrHelp.HelpText;
            }
            return control;
        }

        public static string GetFormatedString(this PropertyInfo item, object obj)
        {
            var result = item.GetValue(obj);
            if (result is Enum)
            {
                var prop = result.GetType().GetField(result.ToString());
                return prop.GetDisplayName();
            }
            var convertor = item.GetCustomAttribute<ValueConvertorAttribute>();
            if (convertor != null)
            {
                result = (convertor as IValueConvertor).Convert(obj);
            }
            var attr = item.GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayFormatAttribute>();
            if (attr != null)
            {
                return string.Format(attr.DataFormatString, result);
            }
            return result == null ? string.Empty : result.ToString();
        }
    }
}