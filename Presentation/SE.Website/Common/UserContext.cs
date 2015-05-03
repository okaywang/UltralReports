
using Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic;

namespace Website.Common
{
    public class UserContext
    {
        private static readonly UserContext Empty = new UserContext();

        private const string CurrentUserContextCacheKey = "UserContext";

        public static UserContext Current
        {
            get
            {
                if (HttpContext.Current.Items[CurrentUserContextCacheKey] == null)
                {
                    var user = HttpContext.Current.User.Identity;
                    var bllAccount = DependencyResolver.Current.GetService<AccountBussinessLogic>();
                    var account = bllAccount.GetAccountByLoginName(user.Name);
                    if (account == null)
                    {
                        return UserContext.Empty;
                    }

                    var userContext = new UserContext
                    {
                        Id = account.Id,
                        Name = account.LoginName,
                        AccountType = account.AccountType,
                        MajorId = account.MajorId
                    };

                    if (userContext.AccountType == AccountType.GeneralUser)
                    {
                        //userContext.Shop = account.Shop;
                    }

                    HttpContext.Current.Items[CurrentUserContextCacheKey] = userContext;
                }
                return HttpContext.Current.Items[CurrentUserContextCacheKey] as UserContext;
            }
        }

        public bool HasAuthority(string authorityName)
        {
            if (this == UserContext.Empty)
            {
                return false;
            }
            var bllAccount = DependencyResolver.Current.GetService<AccountBussinessLogic>();
            return bllAccount.HasAuthority(UserContext.Current.Id, authorityName);
        }

        public int Id { get; set; }

        public AccountType AccountType { get; set; }

        public int? MajorId { get; set; }

        public string Name { get; set; }

        //public UserContextModel UserContextModel
        //{
        //    get
        //    {
        //        return new UserContextModel(this.AccountType, this.Id, this.Gallery == null ? 0 : this.Gallery.Id);
        //    }
        //}
    }
}