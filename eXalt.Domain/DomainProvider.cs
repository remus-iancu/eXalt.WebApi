using eXalt.DomainApi;
using eXalt.DomainApi.Entities;

namespace eXalt.Domain;
public class DomainProvider : IDomainProvider
{
    private IRepository _repository;

    public DomainProvider(IRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<AccountTransaction> GetAccountTransactions(int accountId)
    {
        return _repository.GetAccountTransactions(accountId);
    }

    public decimal GetBalance(int accountId)
    {
        BankAccount bankAccount = _repository.GetBankAccount(accountId);
        return bankAccount.Balance;
    }

    public BankAccount MakeDeposit(int accountId, decimal amount)
    {
        BankAccount bankAccount = _repository.GetBankAccount(accountId);
        bankAccount.Balance += Math.Abs(amount);
        _repository.SaveBankAccount(bankAccount);

        AccountTransaction transaction = new AccountTransaction
        {
            BankAccountId = accountId,
            TransactionType = (int)TransactionTypes.Deposit,
            TransactionValue = amount
        };
        _repository.AddTransaction(transaction);

        return bankAccount;
    }

    public BankAccount MakeWithdrawal(int accountId, decimal amount)
    {
        BankAccount bankAccount = _repository.GetBankAccount(accountId);
        bankAccount.Balance -= Math.Abs(amount);
        _repository.SaveBankAccount(bankAccount);

        AccountTransaction transaction = new AccountTransaction
        {
            BankAccountId = accountId,
            TransactionType = (int)TransactionTypes.Withdrawal,
            TransactionValue = amount
        };
        _repository.AddTransaction(transaction);

        return bankAccount;
    }

    public IEnumerable<BankAccount> GetBankAccounts()
    {
        return _repository.BankAccounts;
    }
}
