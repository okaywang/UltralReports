using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Rinch.Common
{
    public static class DbCommandExtensions {
        public static void SetParameters(this DbCommand cmd, object parameters) {
            if (parameters == null)
                return;

            var t = parameters.GetType();
            cmd.Parameters.Clear();
            foreach (var pi in t.GetProperties()) {
                var p = cmd.CreateParameter();
                p.ParameterName = pi.Name;
                if (p.ParameterName.StartsWith("Output", StringComparison.OrdinalIgnoreCase))
                {
                    p.Direction = System.Data.ParameterDirection.Output;
                    p.Size = 4;
                }
                p.Value = pi.GetValue(parameters, null);
                if (p.Value == null)
                    p.Value = DBNull.Value;
                cmd.Parameters.Add(p);
            }
        }

    }
}
