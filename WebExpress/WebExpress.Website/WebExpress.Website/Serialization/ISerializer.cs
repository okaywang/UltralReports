using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Website.Serialization
{
    public interface ISerializer<TResult>
    {
        TResult Serialize(object obj);

        object Deserialize(TResult input, Type targetType);
    }
}
