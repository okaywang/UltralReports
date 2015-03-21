using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
}