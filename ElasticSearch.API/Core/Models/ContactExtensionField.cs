using System.ComponentModel.DataAnnotations;

namespace ElasticSearch.API.Core.Models;

public sealed class ContactExtensionField
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DataTypes Type { get; set; }

    public Guid TenantId { get; set; }

    public Tenant Tenant { get; set; } = default!;

    public HashSet<ContactExtensionValue> ExtensionValues { get; set; } = new();
}
