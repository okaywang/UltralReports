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
    public interface ISourceControl
    {
        NameValuePair[] Source { get; set; }
    }
    public class NativeSelect : ControlBase, ISourceControl
    {
        private string _name;
        public NativeSelect(string name)
            : this(name, true, false) { }
        public NativeSelect(string name, bool enabled, bool required)
        {
            _name = name;
            IsEnabled = enabled;
            IsRequired = required;
        }
        public override string Name { get { return _name; } }

        public string SelectedValue { get; set; }

        public NameValuePair[] Source { get; set; }

        public override string Render()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("<select class='form-control' name='{0}' data-value-field='Value' data-text-field='Name' data-bind='value:{0},source:{0}s'", Name);
            if (!IsEnabled)
            {
                sb.Append(" disabled");
            }
            sb.Append(">");
            sb.Append("<option value=''> </option>");
            if (Source != null)
            {
                foreach (var pair in Source)
                {
                    sb.AppendFormat("<option value='{0}' {1}>{2}</option>", pair.Value, this.SelectedValue == pair.Value ? "selected='selected'" : "", pair.Name);
                }
            }
            sb.Append("</select>");

            if (!IsEnabled)
            {
                sb.AppendFormat("<input type='hidden' name='{0}'>", Name);
            }
            return sb.ToString();
        }
    }

    public class NativeRadios : ControlBase, ISourceControl
    {
        private string _name;
        public NativeRadios(string name)
            : this(name, true, false) { }
        public NativeRadios(string name, bool enabled, bool required)
        {
            _name = name;
            IsEnabled = enabled;
            IsRequired = required;
        }
        public override string Name { get { return _name; } }

        public NameValuePair[] Source { get; set; }

        public override string Render()
        {
            var sb = new StringBuilder();

            if (Source != null)
            {
                foreach (var pair in Source)
                {
                    sb.AppendFormat("<input type='radio' name='{0}' data-bind='checked:{0}' value='{1}' ", Name, pair.Value);
                    if (!IsEnabled)
                    {
                        sb.Append(" disabled");
                    }
                    sb.Append("/>");
                    sb.Append(pair.Name);
                }
            }

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
            sb.Append("/>");
            if (!IsEnabled)
            {
                sb.AppendFormat("<input type='hidden' name='{0}'>", Name);
            }
            return sb.ToString();
        }
    }

    public class NativeTextarea : ControlBase
    {
        private string _name;

        public NativeTextarea(string name) : this(name, true) { }
        public NativeTextarea(string name, bool enabled) : this(name, true, false) { }
        public NativeTextarea(string name, bool enabled, bool required)
        {
            _name = name;
            IsEnabled = enabled;
            IsRequired = required;
        }

        public override string Name { get { return _name; } }

        public override string Render()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("<textarea class='form-control' name='{0}' data-bind='value:{0}' ", Name);
            if (!IsEnabled)
            {
                sb.Append(" disabled");
            }
            sb.Append("></textarea>");
            if (!IsEnabled)
            {
                sb.AppendFormat("<input name='{0}'>", Name);
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

    #endregion


}