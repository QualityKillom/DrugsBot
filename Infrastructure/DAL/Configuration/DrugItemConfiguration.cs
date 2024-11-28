using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configuration;

public class DrugItemConfiguration : IEntityTypeConfiguration<DrugItem>
{
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        //Таблица 
        builder.ToTable(nameof(DrugItem));
        
        //Ключи
        builder.HasKey(di => di.Id);
        
        //Настройка к колонке Cost
        builder.Property(di => di.Cost)
            .HasPrecision(10, 2) 
            .IsRequired();

      
        //Настройка к колонке Count
        builder.Property(di => di.Count)
            .HasDefaultValue(1)
            .IsRequired();

        
        //Настройка к колонке DrugId
        builder.Property(di => di.DrugId)
            .IsRequired();

        //Настройка к колонке DrugStoreId
        builder.Property(di => di.DrugStoreId)
            .IsRequired();

        //Настройка к колонке Drug
        builder.HasOne(di => di.Drug)
            .WithMany()
            .HasForeignKey(di => di.DrugId)
            .OnDelete(DeleteBehavior.Restrict); 

        //Настройка к колонке DrugStore
        builder.HasOne(di => di.DrugStore)
            .WithMany()
            .HasForeignKey(di => di.DrugStoreId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}