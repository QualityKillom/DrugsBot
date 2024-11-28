using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configuration;

public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        //Таблица
        builder.ToTable(nameof(Drug));
        
        //Ключи
        builder.HasKey(d=> d.Id);

        //Настройка колонки Name
        builder.Property(d=> d.Name)
            .IsRequired()
            .HasMaxLength(150);

        //Настройка колонки Manufacture
        builder.Property(d=> d.Manufacturer)
            .IsRequired()
            .HasMaxLength(100); 

        //Настройка колонки CountryCodeId
        builder.Property(d=> d.CountryCodeId)
            .IsRequired()
            .HasMaxLength(3) 
            .IsUnicode(false); 

        //Настройка колонки Country
        builder.Property(d=> d.Country)
            .IsRequired();
    }
}
