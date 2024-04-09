using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Domain.PlayerAggregate.Entities;

namespace WebApp.Infrastructure.EntityConfigurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.ToTable("Players");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Email).IsRequired();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.OwnsOne(u => u.Name, navigation =>
        {
            navigation.Property(n => n.FirstName).IsRequired().HasColumnName("FirstName");
            navigation.Property(n => n.LastName).IsRequired().HasColumnName("LastName");
        });
        builder.OwnsOne(u => u.Address, navigation =>
        {
            navigation.Property(a => a.Street).IsRequired().HasColumnName("Street");
            navigation.Property(a => a.City).IsRequired().HasColumnName("City");
            navigation.Property(a => a.Country).IsRequired().HasColumnName("Country");
            navigation.Property(a => a.ZipCode).IsRequired().HasColumnName("ZipCode");
        });
        builder.Property(u => u.CreatedAt).HasDefaultValueSql("now()");
    }
}
