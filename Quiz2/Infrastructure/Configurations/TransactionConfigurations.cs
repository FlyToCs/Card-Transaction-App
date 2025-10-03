using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz2.Entities;

namespace Quiz2.Infrastructure.Configurations;

public class TransactionConfigurations : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.DestinationAccount)
            .WithMany(x => x.DestinationTransactions)
            .HasForeignKey(x => x.DestinationAccountId)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

        builder.HasOne(x => x.SourceAccount)
            .WithMany(x => x.SourceTransactions)
            .HasForeignKey(x => x.SourceAccountId)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);



    }
}