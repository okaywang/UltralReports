using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Types
{
    public enum AccountType
    {
        AdminUser = 1,
        GeneralUser = 2,
    }

    [Flags]
    public enum AuthorityType
    {
        [CandidateAccounts(AccountType.AdminUser)]
        Administration = 1,

        [CandidateAccounts(AccountType.GeneralUser)]
        Bussiness = 2,

        [CandidateAccounts(AccountType.AdminUser, AccountType.GeneralUser)]
        AdministrationAndBussiness = Administration | Bussiness
    }

    public class CandidateAccountsAttribute : Attribute
    {
        public CandidateAccountsAttribute(params AccountType[] types)
        {
            AccountTypes = types;
        }

        public AccountType[] AccountTypes { get; private set; }
    }
}
