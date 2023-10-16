namespace ElasticSearch.API.Contracts;

public sealed class ContactDto
{
    public string Name { get; set; } = string.Empty;

    public DateTimeOffset DateOfBirth { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public HashSet<ContactExtensionValueDto> ExtensionValues { get; set; } = new();
}
