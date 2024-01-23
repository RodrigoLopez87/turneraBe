using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using turnera.Models;

namespace turnera.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly TurneraContext _dbContext;

    public ProductController(TurneraContext dbContext)
    {
        this._dbContext = dbContext;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var products = this._dbContext.Productos.Include(p => p.Marca).ToList();
        return Ok(products);
    }

    [HttpGet("Get/{id}")]
    public IActionResult GetById(int id)
    {
        var products = this._dbContext.Productos.FirstOrDefault(p => p.Id == id);
        return Ok(products);
    }
    
    [HttpDelete("Remove/{id}")]
    public IActionResult Remove(int id)
    {
        var product = this._dbContext.Productos.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            this._dbContext.Remove(product);
            this._dbContext.SaveChanges();
            return Ok(true);
        }
        return Ok(false);
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] Producto incomingProduct)
    {
        var existingProduct = this._dbContext.Entities.FirstOrDefault(e => e.Name == incomingProduct.Name);
        if (existingProduct != null)
        {
            
            return Ok(false);
        }
        this._dbContext.Productos.Add(incomingProduct);
        this._dbContext.SaveChanges();
        return Ok(true);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Producto incomingProduct)
    {
        var existingProduct = this._dbContext.Productos.FirstOrDefault(e => e.Id == incomingProduct.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = incomingProduct.Name;
            existingProduct.ImgUrl = incomingProduct.ImgUrl;
            existingProduct.Price = incomingProduct.Price;
            existingProduct.MarcaId = incomingProduct.MarcaId;
            this._dbContext.SaveChanges();
            return Ok(true);
        }
        
        return Ok(false);
    }
}
