using ElasticSearch.API.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ElasticSearch.API.Infrastructure;

public sealed class EsDbContext : DbContext
{
    public EsDbContext(DbContextOptions<EsDbContext> options) : base(options)
    {
    }

    public DbSet<Tenant> Tenants { get; set; }

    public DbSet<Contact> Contacts { get; set; }

    public DbSet<ContactExtensionField> ContactExtensionFields { get; set; }

    public DbSet<ContactExtensionValue> ContactExtensionValues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EsDbContext).Assembly);
        modelBuilder.HasDefaultSchema(DbDefaults.Schemas.Default);
    }
}
