using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;
using System.Net;

namespace ProductsApp.Controllers {
    public class ProductsController : ApiController
    {
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

        [HttpPost]
        public IHttpActionResult PostProduct(Product product) {
            string sqlInsert = "EXEC InsertProcedure " + product.Id
                + "," + product.Name
                + "," + product.Category
                + "," + product.Price;
            db.Database.ExecuteSqlCommand(sqlInsert);
            db.SaveChanges();
            return Ok(product);
        }

        [HttpDelete]
        public IHttpActionResult DeleteData(int id) {
            string sqlDelete = "EXEC DeleteProcedure " + id;
            db.Database.ExecuteSqlCommand(sqlDelete);
            db.SaveChanges();
            //return this.Json(new { msg = "success" });
            return Ok("success");
        }

        [HttpPut]
        public IHttpActionResult PutProduct(Product product) {
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            string sqlUpdate = "EXEC UpdateProcedure "
                + product.Id
                + "," + product.Name
                + "," + product.Category
                + "," + product.Price;
            db.Database.ExecuteSqlCommand(sqlUpdate);
            db.SaveChanges();
            return this.Json(new { msg = "success"});
    }
    }
}
