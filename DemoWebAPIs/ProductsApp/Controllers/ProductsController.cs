using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;

namespace ProductsApp.Controllers {
    public class ProductsController : ApiController
    {
        //Product[] products = new Product[] {
        //    new Product{Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1},
        //    new Product{Id = 2, Name = "Yo-Yo", Category = "Toys", Price = 8.20M},
        //    new Product{Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M}
        //};
        private ProductsDbContext db = new ProductsDbContext();
        public IEnumerable<Product> GetAllProducts() {
            var products = from P in db.Products
                           where P.Id > 0
                           select P;
            return (IEnumerable<Product>) products.ToList();
        }

        public IHttpActionResult GetProduct(int id) {
            var products = from P in db.Products
                           where P.Id > 0
                           select P;
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        //POST Method to Insert Data into the Database
        //[HttpPost]
        //public IHttpActionResult PostData(Product product) {
        //    ProductsDbContext db = new ProductsDbContext();
        //    if (ModelState.IsValid) {
        //        db.Products.Add(product);
        //        db.SaveChanges();
        //        Console.WriteLine(product.Id);
        //        return this.Json(new { msg = "success" });
        //    }
        //    return Ok(product);
        //    return this.Json(new { msg = "failed!" });
        //}

        [HttpPost]
        public IHttpActionResult PostData(Product product) {
            try {
                ProductsDbContext db = new ProductsDbContext();
                db.Products.Add(product);
                db.SaveChanges();
                return this.Json(new { msg = "success" });
            } catch (SqlException ex) {
                Console.Write(ex);
            }
            return this.Json(new { msg = "fail" });
        }

        [HttpDelete]
        public IHttpActionResult DeleteData(int id) {

            return this.Json(new { msg = "Deleted!" });
        }
    }
}
