
using Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic;
using DataAccess;

namespace Website.Common
{
    public class AuthorityHelper
    {
        private static Dictionary<string, Authority> dictAuthorities = new Dictionary<string, Authority>();
        private static IList<Authority> _authorities = new List<Authority>();
        public static void Init()
        {
            var logic = DependencyResolver.Current.GetService<AccountBussinessLogic>();
            _authorities = logic.GetAllAuthorities();

            foreach (var item in _authorities)
            {
                dictAuthorities.Add(item.Name, item);
            }
        }

        public static IList<Authority> GetAll()
        {
            return _authorities;
        }

        public static Authority Get(string authorityName)
        {
            return dictAuthorities[authorityName];
        }

        public static int GetId(string authorityName)
        {
            return dictAuthorities[authorityName].Id;
        }
        public static AuthorityType GetAuthorityType(string authorityName)
        {
            return (AuthorityType)dictAuthorities[authorityName].AuthorityType;
        }
    }

    public static class AuthorityTypeExtension
    {
        public static bool HasCandidateAuthority(this AccountType accountType, string authorityName)
        {
            var authorityType = AuthorityHelper.GetAuthorityType(authorityName);
            var mi = typeof(AuthorityType).GetMember(authorityType.ToString()).Single();
            var attribute = mi.GetCustomAttributes(typeof(CandidateAccountsAttribute), false).Single() as CandidateAccountsAttribute;
            return attribute.AccountTypes.Any(i => (i & accountType) > 0);
        }
    }
}