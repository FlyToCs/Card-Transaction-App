using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz2.Entities;

namespace Quiz2.Infrastructure.Configurations
{
    internal class CardConfigurations : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.DestinationTransactions)
                .WithOne(x => x.DestinationAccount)
                .HasForeignKey(x => x.SourceAccountId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            builder.HasMany(x => x.SourceTransactions)
                .WithOne(x => x.SourceAccount)
                .HasForeignKey(x => x.SourceAccountId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            builder.Property(x => x.CardNumber).HasMaxLength(16);

        }
    }
}
