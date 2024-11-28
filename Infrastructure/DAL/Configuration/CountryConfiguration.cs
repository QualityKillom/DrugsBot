using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configuration;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        //Таблица
        builder.ToTable(nameof(Country));
        
        //Ключи
        builder.HasKey(c => c.Id);
        
        //Настройка колонки Name
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        //Настройка колонки Code
        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(2);
    }
}