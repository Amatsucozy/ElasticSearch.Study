using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ElasticSearch.API.Infrastructure;

public sealed class DbContextFactory : IDesignTimeDbContextFactory<EsDbContext>
{
    // dotnet ef migrations add -c EsDbContext -p ../ElasticSearch.API.csproj EsDbContext-
    public EsDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<EsDbContext>()
            .UseSqlServer(DbDefaults.ConnectionString,
                sqlBuilder => { sqlBuilder.MigrationsAssembly(typeof(EsDbContext).Assembly.GetName().Name); })
            .Options;

        return new EsDbContext(options);
    }
}
