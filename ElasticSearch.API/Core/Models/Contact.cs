using System.ComponentModel.DataAnnotations;

namespace ElasticSearch.API.Core.Models;

public sealed class Contact
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTimeOffset DateOfBirth { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public Guid TenantId { get; set; }

    public Tenant Tenant { get; set; } = default!;

    public HashSet<ContactExtensionValue> ExtensionValues { get; set; } = new();

    public Dictionary<string, string> ToDictionary()
    {
        var dict = new Dictionary<string, string>
        {
            { nameof(Id), Id.ToString() },
            { nameof(Name), Name },
            { nameof(DateOfBirth), DateOfBirth.ToString("yyyy-MM-dd") },
            { nameof(Email), Email },
            { nameof(Phone), Phone }
        };

        foreach (var extensionValue in ExtensionValues)
        {
            dict.Add(extensionValue.ExtensionField.Name, extensionValue.Value);
        }

        return dict;
    }
}
