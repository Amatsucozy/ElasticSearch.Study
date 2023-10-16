namespace ElasticSearch.API;

public sealed class ElasticSearchConfig
{
    public const string SectionName = "ElasticSearch";

    public required string Url { get; set; }

    public required string Index { get; set; }

    public required string ApiKey { get; set; }

    public required string Fingerprint { get; set; }
}
