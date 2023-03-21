


namespace eXalt.Domain.Tests
{
    public class DomainProviderTest
    {
        [Fact]
        public void MakeDepositReturnsTheCorrectNewBalance()
        {
            // Arrange
            var repository = A.Fake<IRepository>();
            var domainProvider = new DomainProvider(repository);
            int accountId = 1;
            A.CallTo(() => repository.GetBankAccount(accountId)).Returns(new BankAccount { Id = 1, Balance = 1000M });
            // Act
            var accountChanged = domainProvider.MakeDeposit(accountId, 300M);
            // Assert
            Assert.Equal(1300M, accountChanged.Balance);
        }

        [Fact]
        public void MakeWithdrawalReturnsTheCorrectNewBalance()
        {
            // Arrange
            var repository = A.Fake<IRepository>();
            var domainProvider = new DomainProvider(repository);
            int accountId = 1;
            A.CallTo(() => repository.GetBankAccount(accountId)).Returns(new BankAccount { Id = 1, Balance = 1000M });
            // Act
            var accountChanged = domainProvider.MakeWithdrawal(accountId, 300M);
            // Assert
            Assert.Equal(700M, accountChanged.Balance);
        }

        [Fact]
        public void GetAccountTransactionsReturnsTheCorrectCount()
        {
            // Arrange
            var repository = A.Fake<IRepository>();
            var domainProvider = new DomainProvider(repository);
            int accountId = 1;
            var fakeTransactions = A.CollectionOfDummy<AccountTransaction>(3).AsEnumerable();
            A.CallTo(() => repository.GetAccountTransactions(accountId)).Returns(fakeTransactions);
            // Act
            var transactions = domainProvider.GetAccountTransactions(accountId);
            // Assert
            Assert.Equal(3, transactions.Count());
        }

        [Fact]
        public void GetCurrentBalanceReturnsCorrectBalance()
        {
            // Arrange
            var repository = A.Fake<IRepository>();
            var domainProvider = new DomainProvider(repository);
            int accountId = 1;
            A.CallTo(() => repository.GetBankAccount(accountId)).Returns(new BankAccount { Id = 1, Balance = 3576.48M });
            // Act
            decimal balance = domainProvider.GetBalance(accountId);
            // Assert
            Assert.Equal(3576.48M, balance);
        }
    }
}