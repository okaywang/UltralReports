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
    public static class ControlTypes
    {
        //native input
        public const string NativeInputText = "nativeInputText";
        public const string NativeInputDate = "nativeInputDate";
        public const string NativeInputPassword = "nativeInputPassword";
        public const string NativeInputRadio = "nativeInputRadio";
        public const string NativeInputCheckbox = "nativeInputCheckbox";
        public const string NativeInputFile = "nativeInputFile";

        //native select
        public const string NativeSelect = "nativeSelect";
        public const string NativeSelectMultiple = "nativeSelectMultiple";

        //select2
        public const string Select2 = "select2";
        public const string Select2Multiple = "select2Multiple";

        public const string ChinaAreas = "chinaAreas";

        public const string ListItems = "listItems";

        public const string SingleItem = "singleItem";
        //public const string SimpleTextbox = "SimpleTextbox";
    }

    #region ControlType

    public interface IControl
    {
        bool IsVisible { get; }
        bool IsEnabled { get; }
        bool IsRequired { get; }
        string Name { get; }
        string Render();
    }

    public abstract class ControlBase : IControl
    {
        public virtual bool IsVisible { get { return true; } }
        public virtual bool IsEnabled { get; protected set; }
        public virtual bool IsRequired { get; protected set; }
        public abstract string Name { get; }
        public abstract string Render();
    }

    public class NativeSelect : ControlBase
    {
        private string _name;
        private NameValuePair[] _pairs;
        public NativeSelect(string name)
            : this(name, true, false) { }
        public NativeSelect(string name, bool enabled, bool required)
            : this(name, enabled, required, new NameValuePair[0]) { }
        public NativeSelect(string name, bool enabled, bool required, NameValuePair[] pairs)
        {
            _name = name;
            _pairs = pairs;
            IsEnabled = enabled;
            IsRequired = required;
        }
        public override string Name { get { return _name; } }

        public override string Render()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("<select class='form-control' name='{0}' data-bind='value:{0}'", Name);
            if (!IsEnabled)
            {
                sb.Append(" disabled");
            }
            sb.Append(">");
            sb.Append("<option value=''>未选</option>");
            foreach (var pair in _pairs)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", pair.Value, pair.Name);
            }
            sb.Append("</select>");

            if (!IsEnabled)
            {
                sb.AppendFormat("<input type='hidden' name='{0}'>", Name);
            }
            return sb.ToString();
        }
    }

    public class NativeInputText : ControlBase
    {
        private string _name;

        public NativeInputText(string name) : this(name, true) { }
        public NativeInputText(string name, bool enabled) : this(name, true, false) { }
        public NativeInputText(string name, bool enabled, bool required)
        {
            _name = name;
            IsEnabled = enabled;
            IsRequired = required;
        }

        public override string Name { get { return _name; } }

        public override string Render()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("<input class='form-control' type='text' name='{0}' data-bind='value:{0}' ", Name);
            if (!IsEnabled)
            {
                sb.Append(" disabled");
            }
            sb.Append(">");
            if (!IsEnabled)
            {
                sb.AppendFormat("<input type='hidden' name='{0}'>", Name);
            }
            return sb.ToString();
        }
    }

    public class NativeInputHidden : ControlBase
    {
        private string _name;
        public NativeInputHidden(string name) : this(name, true, false) { }
        public NativeInputHidden(string name, bool enabled, bool required)
        {
            _name = name;
            IsEnabled = enabled;
            IsRequired = required;
        }
        public override string Name { get { return _name; } }

        public override bool IsVisible { get { return false; } }

        public override string Render()
        {
            return string.Format("<input type='hidden' name='{0}' data-bind='value:{0}' />", Name);
        }
    }

    public class StatisticControl : ControlBase
    {
        private string _name;
        public StatisticControl(string name)
        {
            _name = name;
        }
        public override string Name { get { return _name; } }

        public override string Render()
        {
            return string.Format("<p class='form-control-static' name='{0}'></p>", Name);
        }
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

    public class NameValuePair
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    #endregion

    public class RequestUrlAttribute : Attribute
    {
        public RequestUrlAttribute(string requestUrl)
        {
            RequestUrl = requestUrl;
        }
        public string RequestUrl { get; private set; }
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
            var attr = prop.GetCustomAttribute<ControlTypeAttribute>();
            var isRequired = prop.GetCustomAttribute<System.ComponentModel.DataAnnotations.RequiredAttribute>() != null;
            if (attr == null)
            {
                return new NativeInputText(prop.Name, true, isRequired);
            }
            if (attr.ControlType == typeof(NativeSelect))
            {
                var source = prop.GetCustomAttributes().FirstOrDefault(i => typeof(IControlSource).IsAssignableFrom(i.GetType())) as IControlSource;
                if (source != null)
                {
                    var pairs = source.GetSource();
                    return Activator.CreateInstance(attr.ControlType, prop.Name, attr.Enabled, isRequired, pairs) as IControl;
                }
            }
            return Activator.CreateInstance(attr.ControlType, prop.Name, attr.Enabled, isRequired) as IControl;
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
            if (convertor !=null)
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