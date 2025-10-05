using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Quiz2.Infrastructure.Configurations;

namespace Infrastructure.Persestens;

public class AppDbContext : DbContext
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configurationBuilder = new ConfigurationBuilder();
        var config = configurationBuilder.AddJsonFile("appsettings.json").Build();
        var configSection = config.GetSection("ConnectionStrings");
        var connectionString = configSection["DbConnection"];
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CardConfigurations());
        modelBuilder.ApplyConfiguration(new TransactionConfigurations());
    }
}