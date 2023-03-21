using eXalt.DomainApi.Entities;

namespace eXalt.DomainApi
{
    public interface IRepository
    {
        void SaveBankAccount(BankAccount bankAccount);
        void AddTransaction(AccountTransaction transaction);
        BankAccount GetBankAccount(int id);
        IEnumerable<AccountTransaction> GetAccountTransactions(int accountId);
        IEnumerable<BankAccount> BankAccounts { get; }
    }
}