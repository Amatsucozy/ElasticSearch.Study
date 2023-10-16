namespace ElasticSearch.API.Contracts;

public sealed class ContactExtensionValueDto
{
    public Guid ExtensionFieldId { get; set; }

    public string Value { get; set; } = string.Empty;
}
