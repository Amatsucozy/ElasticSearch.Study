namespace ElasticSearch.API.Infrastructure;

public static class DbDefaults
{
    public const string ConnectionString =
        "Server=localhost;Database=ElasticSearchBase;User ID=sa;Password=123456;TrustServerCertificate=True;";

    public static class Schemas
    {
        public const string Default = "es";
    }
}
