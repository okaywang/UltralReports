using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE.WebService.Models
{ 
    public interface ITranslatable<TFrom, TTo>
    {
        TTo Translate(TFrom from);
    }
     
    public class BatchTranslator<TFrom, TTo> where TTo : ITranslatable<TFrom, TTo>, new()
    {
        public static ICollection<TTo> Translate(ICollection<TFrom> froms)
        {
            var tos = new List<TTo>();
            foreach (var from in froms)
            {
                var to = new TTo().Translate(from);
                tos.Add(to);
            }
            return tos;
        }
    }
}