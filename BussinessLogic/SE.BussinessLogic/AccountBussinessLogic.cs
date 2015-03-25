using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace BussinessLogic
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

        /// <summary>
        /// 账号查询
        /// </summary>
        public PagedList<Account> Search(AccountSearchCriteria criteria)
        {
            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<Account>(i => i.Id, SortOrder.Descending));
            }
            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }
            var query = PrimaryRepository.Table;

            query = query.OrderBy<Account>(criteria.OrderByFields);
            var result = new PagedList<Account>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
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
