using ElasticSearch.API.Contracts;
using ElasticSearch.API.Core.Models;
using ElasticSearch.API.Infrastructure;
using ElasticSearch.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElasticSearch.API.Controllers;

public sealed class TenantController : BaseApiController
{
    private readonly EsDbContext _dbContext;
    private readonly ElasticSearchService _elasticSearchService;

    public TenantController(EsDbContext dbContext, ElasticSearchService elasticSearchService)
    {
        _dbContext = dbContext;
        _elasticSearchService = elasticSearchService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTenant(TenantDto tenant)
    {
        var entityEntry = _dbContext.Tenants.Add(new Tenant
        {
            Name = tenant.Name
        });

        await _dbContext.SaveChangesAsync();

        await _elasticSearchService.CreateIndexAsync(entityEntry.Entity.Id.ToString());

        return Ok();
    }

    [HttpPost]
    [Route("{tenantId}/contact-extension-fields")]
    public async Task<IActionResult> CreateExtensionField(
        Guid tenantId,
        params ContactExtensionFieldDto[] contactExtensionFields)
    {
        var tenant = await _dbContext.Tenants.FirstOrDefaultAsync(t => t.Id.Equals(tenantId));

        if (tenant is null)
        {
            return NotFound();
        }

        foreach (var contactExtensionField in contactExtensionFields)
        {
            tenant.ExtensionFields.Add(new ContactExtensionField
            {
                Name = contactExtensionField.Name,
                Type = contactExtensionField.Type,
            });
        }

        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpPost]
    [Route("{tenantId}/contacts")]
    public async Task<IActionResult> CreateContact(
        Guid tenantId,
        params ContactDto[] contacts)
    {
        var tenant = await _dbContext.Tenants.FirstOrDefaultAsync(t => t.Id.Equals(tenantId));

        if (tenant is null)
        {
            return NotFound();
        }

        foreach (var contact in contacts)
        {
            tenant.Contacts.Add(new Contact
            {
                Name = contact.Name,
                DateOfBirth = contact.DateOfBirth,
                Email = contact.Email,
                Phone = contact.Phone,
                ExtensionValues = contact.ExtensionValues
                    .Select(ev => new ContactExtensionValue
                    {
                        ExtensionFieldId = ev.ExtensionFieldId,
                        Value = ev.Value
                    })
                    .ToHashSet()
            });
        }

        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpPut]
    [Route("Sync")]
    public async Task<IActionResult> Sync()
    {
        var tenants = await _dbContext.Tenants
            .Include(t => t.Contacts)
            .ThenInclude(c => c.ExtensionValues)
            .Include(t => t.ExtensionFields)
            .ToListAsync();

        foreach (var tenant in tenants)
        {
            var syncList = tenant.Contacts.Select(c => c.ToDictionary());

            foreach (var syncObject in syncList)
            {
                await _elasticSearchService.IndexAsync(tenant.Id.ToString(), syncObject);
            }
        }

        return Ok();
    }
}
