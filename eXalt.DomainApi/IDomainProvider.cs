using eXalt.DomainApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXalt.DomainApi
{
    public interface IDomainProvider
    {
        BankAccount MakeDeposit(int accountId, decimal amount);
        BankAccount MakeWithdrawal(int accountId, decimal amount);
        decimal GetBalance(int accountId);
        IEnumerable<AccountTransaction> GetAccountTransactions(int accountId);
        IEnumerable<BankAccount> GetBankAccounts();
    }
}
