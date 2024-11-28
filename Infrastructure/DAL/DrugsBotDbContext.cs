using Domain.Entities;
using Infrastructure.DAL.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL;

public class DrugsBotDbContext : DbContext
{
    public DrugsBotDbContext(DbContextOptions<DrugsBotDbContext> options) : base(options)
    {
        
    }
    /// <summary>
    /// Таблица лекарств
    /// </summary>
    public DbSet<Drug> Drug { get; set; } 
    
    /// <summary>
    /// Таблица стран
    /// </summary>
    public DbSet<Country> Country { get; set; }
    
    /// <summary>
    /// Таблица связей препаратов с аптеками
    /// </summary>
    public DbSet<DrugItem> DrugItem { get; set; }
    
    /// <summary>
    /// Таблица аптек
    /// </summary>
    public DbSet<DrugStore> DrugStore { get; set; }
    
    /// <summary>
    /// Таблица избранных препаратов
    /// </summary>
    public DbSet<FavoriteDrug> FavoriteDrug { get; set; }
    
    /// <summary>
    /// Таблица профилей
    /// </summary>
    public DbSet<Profile> Profile{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new DrugConfiguration());
        
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        
        modelBuilder.ApplyConfiguration(new DrugItemConfiguration());
        
        modelBuilder.ApplyConfiguration(new DrugStoreConfiguration());
        
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        
        modelBuilder.ApplyConfiguration(new FavoriteDrugConfiguration());

        
    }

}