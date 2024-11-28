using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configuration;

public class FavoriteDrugConfiguration : IEntityTypeConfiguration<FavoriteDrug>
{
    public void Configure(EntityTypeBuilder<FavoriteDrug> builder)
    {
        //Таблица
        builder.ToTable(nameof(FavoriteDrug));
        
        //Ключи
        builder.HasKey(fd=> fd.Id);
        
        //Настройки колонки Profile
        builder.Property(fd=> fd.Profile)
            .IsRequired();
        
        //Настройка колонки ExternalId
        builder.Property(fd=>fd.ExternalUserId)
            .IsRequired();
        
        //Настройка колонки DrugId
        builder.Property(fd=>fd.DrugId)
            .IsRequired();
        
        //Настройки колонки Drug
        builder.Property(fd=>fd.Drug)
            .IsRequired();

    }
}