using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<OrderBuy> OrdersBuy { get; set; }

        public DbSet<OrderSell> OrdersSell { get; set; }
        public StoreContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<Product>()
                 .HasMany(p => p.OrdersSell)
                 .WithOne(o => o.Product)
                 */

            /*  modelBuilder.Entity<Product>(p =>
              {
                  p.HasKey(prod => prod.ProductId);
                  p.Property(prod => prod.ProductId).ValueGeneratedOnAdd();
              });

              modelBuilder.Entity<OrderBuy>(o =>
              {
                  o.HasKey(order => order.Id);
                  o.Property(order => order.Id).ValueGeneratedOnAdd();
              });


              modelBuilder.Entity<OrderSell>(o =>
              {
                  o.HasKey(order => order.Id);
                  o.Property(order => order.Id).ValueGeneratedOnAdd();
              });*/



            modelBuilder.Entity<OrderSell>()
                .HasOne(o => o.Product)
                .WithMany(p => p.OrdersSell)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<OrderBuy>()
               .HasOne(o => o.Product)
               .WithMany(p => p.OrdersBuy)
               .HasForeignKey(p => p.ProductId);



           /* modelBuilder.Entity<Product>()
                .HasMany(p => p.OrdersBuy)
                .WithOne(o => o.Product)
                .HasForeignKey(o => o.ProductId);*/

           /* modelBuilder.Entity<OrderBuy>()
                .HasOne(ob => ob.OrderSell)
                .WithOne(os => os.OrderBuy)
                .HasForeignKey<OrderSell>(o => o.OrderBuyId);*/

        }
    }
}
