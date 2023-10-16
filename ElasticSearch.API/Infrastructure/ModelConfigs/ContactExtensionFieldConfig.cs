using ElasticSearch.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElasticSearch.API.Infrastructure.ModelConfigs;

public sealed class ContactExtensionFieldConfig : IEntityTypeConfiguration<ContactExtensionField>
{
    public void Configure(EntityTypeBuilder<ContactExtensionField> builder)
    {
        builder.ToTable(nameof(EsDbContext.ContactExtensionFields));

        builder.HasIndex(cef => new { cef.Id, cef.Name })
            .IsUnique();

        builder.HasMany(c => c.ExtensionValues)
            .WithOne(ce => ce.ExtensionField)
            .HasForeignKey(ce => ce.ExtensionFieldId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
