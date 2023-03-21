using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXalt.DomainApi.Entities
{
    public class AccountTransaction : IDomainEntity
    {
        public int Id { get; set; }
        public int BankAccountId { get; set; }
        public int TransactionType { get; set; }
        public decimal TransactionValue { get; set; }
    }

    public enum TransactionTypes
    {
        Withdrawal = 0,
        Deposit
    }
}
