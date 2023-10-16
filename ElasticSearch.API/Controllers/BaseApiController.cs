using Microsoft.AspNetCore.Mvc;

namespace ElasticSearch.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
}
