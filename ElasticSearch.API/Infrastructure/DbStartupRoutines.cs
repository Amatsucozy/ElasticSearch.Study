using Microsoft.EntityFrameworkCore;

namespace ElasticSearch.API.Infrastructure;

public static class DbStartupRoutines
{
    public static void DbStart(this IApplicationBuilder applicationBuilder)
    {
        using var scope = applicationBuilder.ApplicationServices.CreateScope();
        using var esDbContext = scope.ServiceProvider.GetRequiredService<EsDbContext>();

        if (esDbContext.Database.GetPendingMigrations().Any()) esDbContext.Database.Migrate();
    }
}
