using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApiV2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ZecZecContext db;

        public ProjectController(ZecZecContext _db)
        {
            this.db = _db;
        }


        // GET: api/<ProjectController>
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            var projects = from p in db.Projects
                           select new Project
                           {
                               ProjectId = p.ProjectId,
                               ProjectName = p.ProjectName,
                               Goal = p.Goal,
                               Date = p.Date,
                               ExpireDate = p.ExpireDate,
                               MemberId = p.MemberId,
                               RoleId = p.RoleId,
                               Description = p.Description,
                               Thumbnail = p.Thumbnail,
                               Discount = p.Discount,
                               AccumulatedAmount = p.AccumulatedAmount,
                               Products = (from product in db.Products
                                           where product.ProjectId == p.ProjectId
                                           select new Product
                                           {
                                               ProductId = product.ProductId,
                                               Price = product.Price,
                                               ProductName = product.ProductName,
                                               ProductDescription = product.ProductDescription,
                                               Quantity = product.Quantity,
                                               Inventory = product.Inventory,
                                               Date = product.Date,
                                               ExpireDate = product.ExpireDate,
                                               Thumbnail = product.Thumbnail,
                                               Carts = product.Carts,
                                           }).ToList()
                           };

            return projects;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProjectController>
        [HttpPost]
        //public async Task<IActionResult> Post([FromBody] Project value ,[FromForm] IFormFile img)
        public IActionResult Post([FromBody] Project value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid project data.");
            }
            //if (img != null)
            //{
            //    var filePath = Path.Combine("path/to/save", img.FileName);

            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await img.CopyToAsync(stream);
            //    }
            //    value.Thumbnail = filePath;
            //    // 設置文件路徑或其他需要的屬性
            //    // productCreateDto.ThumbnailPath = filePath;
            //}
            db.Add(value);
            db.SaveChanges();
            return Ok(value);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Project value)
        {
            Project? p = db.Projects.FirstOrDefault(x => x.ProjectId == id);
            if (p == null)
            {
                return NotFound("Project not found.");
            }
                p.ProjectName = value.ProjectName;
                p.Description = value.Description;
                //status;
                p.Goal = value.Goal;
                p.Date = value.Date;
                p.ExpireDate = value.ExpireDate;
                db.SaveChanges();
                return Ok(value);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
