using ElasticSearch.API.Core.Models;

namespace ElasticSearch.API.Contracts;

public sealed class ContactExtensionFieldDto
{
    public string Name { get; set; } = string.Empty;

    public DataTypes Type { get; set; }
}
