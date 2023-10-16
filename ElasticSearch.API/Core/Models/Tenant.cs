using System.ComponentModel.DataAnnotations;

namespace ElasticSearch.API.Core.Models;

public sealed class Tenant
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public HashSet<Contact> Contacts { get; set; } = new();

    public HashSet<ContactExtensionField> ExtensionFields { get; set; } = new();
}
