﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProductsApp.Models {
    public class ProductsDbContext : DbContext {
        public ProductsDbContext() :base("name=ProductsAppConnection") {

        }
        public DbSet<Product> Products { get; set; }
    }
}