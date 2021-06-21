using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Pcart.Models
{
    public class CartContext : DbContext
    {
        public CartContext() : base("name=CartConnection")
        {

        }
        public DbSet<ProductDetails> Dsproducts { get; set; }
        public DbSet<UserDetails> Dsusers { get; set; }
    }
}