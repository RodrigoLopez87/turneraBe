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

    [HttpGet("Get/{id}")]
    public IActionResult GetById(int id)
    {
        var entity = this._dbContext.Entities.FirstOrDefault(e => e.Id == id);
        return Ok(entity);
    }
    
    [HttpDelete("Remove/{id}")]
    public IActionResult Remove(int id)
    {
        var entity = this._dbContext.Entities.FirstOrDefault(e => e.Id == id);
        if (entity != null)
        {
            this._dbContext.Remove(entity);
            this._dbContext.SaveChanges();
            return Ok(true);
        }
        return Ok(false);
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] Entity incomingEntity)
    {
        var existingEntity = this._dbContext.Entities.FirstOrDefault(e => e.Name == incomingEntity.Name);
        if (existingEntity != null)
        {
            
            return Ok(false);
        }
        this._dbContext.Entities.Add(incomingEntity);
        this._dbContext.SaveChanges();
        return Ok(true);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Entity incomingEntity)
    {
        var existingEntity = this._dbContext.Entities.FirstOrDefault(e => e.Id == incomingEntity.Id);
        if (existingEntity != null)
        {
            existingEntity.Name = incomingEntity.Name;
            existingEntity.LogoUrl = incomingEntity.LogoUrl;
            existingEntity.MainPageMessage = incomingEntity.MainPageMessage;
            existingEntity.UrlIdentifier = incomingEntity.UrlIdentifier;
            this._dbContext.SaveChanges();
            return Ok(true);
        }
        
        return Ok(false);
    }
}
