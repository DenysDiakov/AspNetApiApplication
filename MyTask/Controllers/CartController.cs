using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTask.Model;

namespace MyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        // GET: api/Cart

        [HttpGet]
        public IQueryable<ShoppingCart> Get()
        {
            ApplicationContext db = new ApplicationContext();

            var products = from p in db.Cart
                           select p;

            return products;

        }
        // GET: api/Cart/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cart
        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> Post([FromBody]ShoppingCart cart)
        {
            ApplicationContext db = new ApplicationContext();

            if (cart == null)
            {
                return BadRequest();
            }

            db.Cart.Add(cart);
            await db.SaveChangesAsync();
            return Ok(cart);
        }


        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Cart.Remove(db.Cart.FirstOrDefault(e => e.Id == id));
                db.SaveChanges();
            }

        }
    }
}
