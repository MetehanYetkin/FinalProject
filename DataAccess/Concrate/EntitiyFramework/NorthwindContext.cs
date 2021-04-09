using Core.Entities.Concrate;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrate.EntitiyFramework
{//Context : DB tabloları ile proje classlarını ilişkilendirmek.
  public class NorthwindContext:DbContext//EntitiyFramworkten gelen bir classtır.
    {
        //Benim metodum hangi veri tabanı tablosu ile ilişkilendireceğimi söyleyen kısım

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True");

        }
        public DbSet<Product> Products  { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
