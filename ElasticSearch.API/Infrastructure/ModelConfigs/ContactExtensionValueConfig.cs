using ElasticSearch.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElasticSearch.API.Infrastructure.ModelConfigs;

public class ContactExtensionValueConfig : IEntityTypeConfiguration<ContactExtensionValue>
{
    public void Configure(EntityTypeBuilder<ContactExtensionValue> builder)
    {
        builder.ToTable(nameof(EsDbContext.ContactExtensionValues));

        builder.HasKey(c => new { c.ContactId, c.ExtensionFieldId });
    }
}
