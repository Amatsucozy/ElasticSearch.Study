using ElasticSearch.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElasticSearch.API.Infrastructure.ModelConfigs;

public sealed class ContactConfig : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable(nameof(EsDbContext.Contacts));

        builder.HasMany(c => c.ExtensionValues)
            .WithOne(ce => ce.Contact)
            .HasForeignKey(ce => ce.ContactId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
