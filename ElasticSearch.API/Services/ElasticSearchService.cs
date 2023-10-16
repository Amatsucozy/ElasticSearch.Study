using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Options;

namespace ElasticSearch.API.Services;

public sealed class ElasticSearchService
{
    private readonly ElasticsearchClient _elasticsearchClient;

    public ElasticSearchService(IOptions<ElasticSearchConfig> elasticSearchConfig)
    {
        var settings = new ElasticsearchClientSettings(new Uri(elasticSearchConfig.Value.Url))
            .DefaultIndex(elasticSearchConfig.Value.Index)
            .CertificateFingerprint(elasticSearchConfig.Value.Fingerprint)
            .Authentication(new ApiKey(elasticSearchConfig.Value.ApiKey));

        _elasticsearchClient = new ElasticsearchClient(settings);
    }

    public async Task CreateIndexAsync(string indexName)
    {
        var indexResponse = await _elasticsearchClient.Indices.CreateAsync(indexName);

        if (!indexResponse.IsValidResponse)
        {
            throw new Exception(indexResponse.DebugInformation);
        }
    }

    public async Task IndexAsync(string indexName, Dictionary<string, string> obj)
    {
        var indexResponse = await _elasticsearchClient.IndexAsync(obj, indexName);

        if (!indexResponse.IsValidResponse)
        {
            throw new Exception(indexResponse.DebugInformation);
        }
    }
}
