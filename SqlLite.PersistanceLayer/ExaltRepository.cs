using eXalt.DomainApi;
using eXalt.DomainApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.PersistanceLayer
{
    public class ExaltRepository : IRepository
    {
        private ExaltContext _dbContext;

        public ExaltRepository(ExaltContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTransaction(AccountTransaction transaction)
        {
            _dbContext.Add(transaction);
            _dbContext.SaveChanges();
        }

        public IEnumerable<BankAccount> BankAccounts { get { return _dbContext.BankAccounts.ToArray(); } }

        public IEnumerable<AccountTransaction> GetAccountTransactions(int accountId)
        {
            return _dbContext.AccountTransactions.Where(x => x.BankAccountId == accountId).ToArray();
        }

        public BankAccount GetBankAccount(int id)
        {
            return _dbContext.BankAccounts.FirstOrDefault(x => x.Id == id);
        }

        public void SaveBankAccount(BankAccount bankAccount)
        {
            _dbContext.Entry<BankAccount>(bankAccount).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
