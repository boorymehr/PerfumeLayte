using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Domain.Entity.Categurys;
using PerfumeLayte.Domain.Entity.User;

namespace PerfumeLayte.Domain.Entity.Product
{
    public class Product:BaseEntity<int>
    {
        public string Price { get; set; }

        public string Brand { get; set; }

        public string Name { get; set; }



        public string Feacher { get; set; }


        public string Voluome { get; set; }


        public string? PriceNew { get; set; }


        public bool isTahkfif { get; set; }



        public string ScrMain { get; set; }


        public bool isVisite { get; set; }


        public Categury Categury { get; set; }

        public int CateguryID { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<Img> Imgs { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }


        public virtual ICollection<LikeProduct> LikeProduct { get; set; }

    }
}
