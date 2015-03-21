using UR.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace UR.BussinessLogic
{
    public class AccountBussinessLogic : BussinessLogicBase<Account>
    {
        private EfRepository<Authority> _authorityRepository;
        private EfRepository<AccountAuthority> _accountAuthorityRepository;
        public AccountBussinessLogic(EfRepository<Account> accountRepository, EfRepository<Authority> authorityRepository, EfRepository<AccountAuthority> accountAuthorityRepository)
            : base(accountRepository)
        {
            _authorityRepository = authorityRepository;
            _accountAuthorityRepository = accountAuthorityRepository;
        }

        public Account GetAccountByLoginName(string loginName)
        {
            var entity = PrimaryRepository.Table.FirstOrDefault(p => p.LoginName == loginName);
            return entity;
        }

        public IList<Authority> GetAllAuthorities()
        {
            return _authorityRepository.Table.ToList();
        }

        public bool HasAuthority(int accountId, string authorityName)
        {
            return PrimaryRepository.Table.Where(i => i.Id == accountId && i.AccountAuthorities.Any(p => p.Authority.Name == authorityName)).Any();
        }

        public void DeleteAccountAuthority(AccountAuthority entity)
        {
            _accountAuthorityRepository.Delete(entity);
        }

    }
}
