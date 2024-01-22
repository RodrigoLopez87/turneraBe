using Microsoft.AspNetCore.Mvc;
using turnera.Models;

namespace turnera.Controllers;

[ApiController]
[Route("[controller]")]
public class EntityController : ControllerBase
{
    private readonly TurneraContext _dbContext;

    public EntityController(TurneraContext dbContext)
    {
        this._dbContext = dbContext;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var entities = this._dbContext.Entities.ToList();
        return Ok(entities);
    }
}
