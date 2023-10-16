namespace ElasticSearch.API.Core.Models;

public sealed class ContactExtensionValue
{
    public string Value { get; set; } = string.Empty;

    public Guid ContactId { get; set; }

    public Contact Contact { get; set; } = default!;

    public Guid ExtensionFieldId { get; set; }

    public ContactExtensionField ExtensionField { get; set; } = default!;
}
