using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configuration;

public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        //Таблица
        builder.ToTable(nameof(DrugStore));
        
        //Ключи
        builder.HasKey(ds => ds.Id);

        //Настройка колонки DrugNetwork
        builder.Property(ds => ds.DrugNetwork)
            .IsRequired()
            .HasMaxLength(100);
        
        //Настройка колонки Number
        builder.Property(ds => ds.Number)
            .IsRequired()
            .HasDefaultValue(0); 
        
        //Настройка колонки Address
        builder.Property(ds => ds.Address)
            .IsRequired()
            .HasMaxLength(255); 
    }

    
}