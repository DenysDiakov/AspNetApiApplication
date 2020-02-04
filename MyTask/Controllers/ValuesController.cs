using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTask.Model;

namespace MyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        // GET api/values
        [HttpGet]
        public IQueryable<Product> Get()
        {
            ApplicationContext db = new ApplicationContext();

            var products = from p in db.Product
                           select p;

            return products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }


        // POST: api/Cart

        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody]Product product)
        {
            ApplicationContext db = new ApplicationContext();

            if (product == null)
            {
                return BadRequest();
            }

            db.Product.Add(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Product.Remove(db.Product.FirstOrDefault(e => e.Id == id));
                db.SaveChanges();
            }

        }
    }
}
