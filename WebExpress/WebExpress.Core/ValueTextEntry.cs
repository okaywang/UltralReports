using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    //public class ValueTextEntry : IValueTextEntry
    //{
    //    public int Value { get; set; }

    //    public string Text { get; set; }
    //}


    public class NameValuePair
    {
        public NameValuePair()
        {

        }

        public NameValuePair(string name,string value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
