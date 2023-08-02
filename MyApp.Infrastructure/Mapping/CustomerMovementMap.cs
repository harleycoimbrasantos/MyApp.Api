using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Entities;

namespace MyApp.Data.Mapping
{
    public class CustomerMovementMap : IEntityTypeConfiguration<CustomerMovement>
    {
        public void Configure(EntityTypeBuilder<CustomerMovement> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.HasKey(customerMovement => new
            {
                customerMovement.Id
            });

            builder.HasOne(customerMovement => customerMovement.TransactionType)
               .WithMany(transactionType => transactionType.CustomerMovement)
               .HasForeignKey(customerMovement => customerMovement.TransactionTypeId);
        }
    }
}
