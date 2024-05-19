using Microsoft.AspNetCore.Mvc;
using WebApiV2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ZecZecContext db;
        public ProductController(ZecZecContext _db)
        {
            this.db = _db;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return db.Products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid product data.");
            }
            db.Add(value);
            db.SaveChanges();
            return Ok(value);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product value)
        {
            Product? p = db.Products.FirstOrDefault(x => x.ProductId == id);
            if (p == null)
            {
                return NotFound("Project not found.");
            }
            p.Price = value.Price;
            p.ProductName = value.ProductName;
            p.ProductDescription = value.ProductDescription;
            //status;
            p.Quantity = value.Quantity;
            p.Inventory = value.Inventory;
            p.Date = value.Date;
            p.ExpireDate = value.ExpireDate;
            db.SaveChanges();
            return Ok(value);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
