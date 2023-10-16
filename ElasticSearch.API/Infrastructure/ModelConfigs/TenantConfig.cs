using ElasticSearch.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElasticSearch.API.Infrastructure.ModelConfigs;

public sealed class TenantConfig : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable(nameof(EsDbContext.Tenants));

        builder.HasMany(t => t.Contacts)
            .WithOne(c => c.Tenant)
            .HasForeignKey(c => c.TenantId);

        builder.HasMany(t => t.ExtensionFields)
            .WithOne(ce => ce.Tenant)
            .HasForeignKey(ce => ce.TenantId);
    }
}
