using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configuration;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        //Таблица
        builder.ToTable(nameof(Profile));
        
        //Ключи
        builder.HasKey(p=> p.Id);
        
        //Настройки колонки ExternalId
        builder.Property(p=> p.ExternalId)
            .IsRequired()
            .HasMaxLength(255);
        
        //Настройка колонки Email
        builder.Property(p => p.Email)
            .IsRequired();


    }
}