using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;
using WebExpress.Core.Paging;

namespace Website.Models
{
    public class PagedModel<T>
    {
        public PagedModel()
        {
            Items = new List<T>();
        }
        public List<T> Items { get; set; }
        public PagingResult PagingResult { get; set; }
    }

    //public static class Ex
    //{
    //    public static PagedModel<TTo> ToPagedModel<TFrom, TTo>(this PagedList<TFrom> pagedList) where TTo : ITranslatable<TFrom, TTo>, new()
    //    {
    //        var pagedModel = new PagedModel<TTo>();

    //        foreach (var item in pagedList)
    //        {
    //            var to = new TTo().Translate(item);
    //            pagedModel.Items.Add(to);
    //        }

    //        pagedModel.PagingResult = pagedList.PagingResult;
    //        return pagedModel;
    //    }

    //}
}