using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Entities;

namespace MyApp.Data.Mapping
{
    public class TransactionTypeMap : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired();

            builder.Property(t => t.Description)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(t => t.Nature)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(t => t.Signal)
               .HasMaxLength(1)
               .IsRequired();
        }
    }
}
