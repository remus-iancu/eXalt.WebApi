using eXalt.DomainApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.PersistanceLayer.Mapping
{
    public class AccountTransactionTypeConfiguration : IEntityTypeConfiguration<AccountTransaction>
    {
        public void Configure(EntityTypeBuilder<AccountTransaction> builder)
        {
            builder.ToTable("AccountTransaction");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.BankAccountId).HasColumnName("BankAccountId");
            builder.Property(x => x.TransactionType).HasColumnName("TransactionType");
            builder.Property(x => x.TransactionValue).HasColumnName("TransactionValue");
        }
    }
}
