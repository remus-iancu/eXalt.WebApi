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
    public class BankAccountTypeConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable("BankAccount");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Balance).HasColumnName("Balance");
            builder.Ignore(x => x.Transactions);
            builder.HasMany<AccountTransaction>(x => x.Transactions);
        }
    }
}
