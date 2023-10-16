using ElasticSearch.API;
using ElasticSearch.API.Infrastructure;
using ElasticSearch.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<ElasticSearchConfig>(builder.Configuration.GetSection(ElasticSearchConfig.SectionName));
builder.Services.AddDbContext<EsDbContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
        sqlOptions => sqlOptions.MigrationsAssembly("ElasticSearch.API"));
});
builder.Services.AddSingleton<ElasticSearchService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.DbStart();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
