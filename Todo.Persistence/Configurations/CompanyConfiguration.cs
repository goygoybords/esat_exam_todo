using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain;

namespace Todo.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Company");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CompanyName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Address)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasData(
            new Company { Id = 1, CompanyName = "Company1", Address = "Cebu City" },
            new Company { Id = 2, CompanyName = "Company2", Address = "Cebu City" },
            new Company { Id = 3, CompanyName = "Company3", Address = "Cebu City" }
        );

    }
}