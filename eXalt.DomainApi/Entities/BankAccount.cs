using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXalt.DomainApi.Entities
{
    public class BankAccountComparer : IEqualityComparer<BankAccount>
    {
        public bool Equals(BankAccount? x, BankAccount? y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode([DisallowNull] BankAccount obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    public class BankAccount : IDomainEntity
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<AccountTransaction>? Transactions { get; set; }
    }
}
