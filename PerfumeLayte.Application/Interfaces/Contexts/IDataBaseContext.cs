using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Domain.Entity.Categurys;
using PerfumeLayte.Domain.Entity.Product;
using PerfumeLayte.Domain.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
          DbSet<User> User { get; set; }

         DbSet<Product> Product { get; set; }

         DbSet<Img> Img { get; set; }


        DbSet<Comments> Comments { get; set; }

         DbSet<Cart> Cart { get; set; }


         DbSet<Categury> Categuries { get; set; }

        DbSet<CartItem> CartItem { get; set; }


        DbSet<LikeProduct> LikeProduct { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
