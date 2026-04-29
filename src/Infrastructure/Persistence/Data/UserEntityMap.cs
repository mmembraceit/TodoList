using Domain.Entities;
using Infrastructure.Persistence.Data.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data;

public class UserEntityMap : BaseMap<UserEntity>
{
    public override void Configure(EntityTypeBuilder<UserEntity> entity)
    {
        base.Configure(entity);

        entity.ToTable("users");

        entity.Property(x => x.Email)
            .HasMaxLength(256)
            .IsRequired();

        entity.Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(x => x.DateOfBirth)
            .IsRequired();

        entity.Property(x => x.IsAdmin)
            .IsRequired();

        entity.OwnsOne(x => x.PhoneNumber, phoneNumberBuilder =>
        {
            phoneNumberBuilder.Property(phoneNumber => phoneNumber.CountryCode)
                .HasColumnName("phone_country_code")
                .HasMaxLength(10);

            phoneNumberBuilder.Property(phoneNumber => phoneNumber.Number)
                .HasColumnName("phone_number")
                .HasMaxLength(32);
        });

        entity.HasIndex(x => x.Email).IsUnique();
    }
}
