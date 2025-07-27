using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Comman;
using PerfumeLayte.Domain.Entity.Categurys;
using PerfumeLayte.Domain.Entity.Product;
using PerfumeLayte.Domain.Entity.Slider;
using PerfumeLayte.Domain.Entity.User;

namespace PerfumeLayte.Persistence.Context
{
    public class Context: DbContext,IDataBaseContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }
        

        

        public DbSet<User> User { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Img> Img { get; set; }



        public DbSet<Comments> Comments { get; set; }

        public DbSet<Cart> Cart { get; set; }



       public DbSet<CartItem> CartItem { get; set; }


        public DbSet<Categury> Categuries { get; set; }

        public DbSet<LikeProduct> LikeProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<LikeProduct>()
           .HasOne(lp => lp.User)
           .WithMany(u => u.LikeProduct)
           .HasForeignKey(lp => lp.UserID);

            modelBuilder.Entity<LikeProduct>()
                .HasOne(lp => lp.Product)
                .WithMany(p => p.LikeProduct)
                .HasForeignKey(lp => lp.ProductID);



            modelBuilder.Entity<Product>()
           .HasMany(e => e.Imgs)
           .WithOne(e =>  e.Product)
            .HasForeignKey(e => e.ProductID)
           .HasPrincipalKey(e => e.ID);

            modelBuilder.Entity<Product>()
         .HasMany(e => e.LikeProduct)
         .WithOne(e => e.Product)
          .HasForeignKey(e => e.ProductID)
         .HasPrincipalKey(e => e.ID);

            modelBuilder.Entity<Categury>()
        .HasMany(e => e.Products)
        .WithOne(e => e.Categury)
         .HasForeignKey(e => e.CateguryID)
        .HasPrincipalKey(e => e.ID);


            modelBuilder.Entity<Categury>()
                       .HasOne(s => s.ParentCategury)
                       .WithMany(m => m.SubCategurys)
                       .HasForeignKey(e => e.ParentCategoryId);




            modelBuilder.Entity<User>()
          .HasMany(e => e.Comments)
          .WithOne(e => e.User)
           .HasForeignKey(e => e.UserID)
          .HasPrincipalKey(e => e.ID);



            modelBuilder.Entity<User>()
        .HasMany(e => e.LikeProduct)
        .WithOne(e => e.User)
         .HasForeignKey(e => e.UserID)
        .HasPrincipalKey(e => e.ID);





            modelBuilder.Entity<User>()
        .HasMany(e => e.Cart)
        .WithOne(e => e.User)
         .HasForeignKey(e => e.UserID)
        .HasPrincipalKey(e => e.ID);

            modelBuilder.Entity<Cart>()
        .HasMany(e => e.CartItem)
        .WithOne(e => e.Cart)
         .HasForeignKey(e => e.CartId)
        .HasPrincipalKey(e => e.ID);


           

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
