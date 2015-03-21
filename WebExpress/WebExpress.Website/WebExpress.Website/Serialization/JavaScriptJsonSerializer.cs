using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WebExpress.Website.Serialization
{
    public class JavaScriptJsonSerializer : ISerializer<string>
    {
        private JavaScriptSerializer _serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        public static readonly JavaScriptJsonSerializer Instance = new JavaScriptJsonSerializer();

        private JavaScriptJsonSerializer()
        {
            _serializer.RegisterConverters(new System.Web.Script.Serialization.JavaScriptConverter[]{ new DateTimeJavaScriptConverter() });
        }


        public string Serialize(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return _serializer.Serialize(obj);
        }

        public object Deserialize(string input, Type targetType)
        {
            if (targetType == null)
            {
                throw new ArgumentNullException("targetType");
            }
            return _serializer.Deserialize(input, targetType);
        }
    }
}
