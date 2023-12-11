using CustomerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagement.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        private const string TABLE_NAME = "Customers";
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(_ => _.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(_ => _.Cep)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
