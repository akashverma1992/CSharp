using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsApp.Models;
using System.Data.Entity;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[] {
            new Product{Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1},
            new Product{Id = 2, Name = "Yo-Yo", Category = "Toys", Price = 8.20M},
            new Product{Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M}
        };

        public IEnumerable<Product> GetAllProducts() {
            return products;
        }

        public IHttpActionResult GetProduct(int id) {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult PostData(Product product) {
            ProductsDbContext db = new ProductsDbContext();
            if (ModelState.IsValid) {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToRoute("Index", null);
            }
            //return Ok(product);
            return this.Json(new { msg = "Success" });
        }
    }
}
