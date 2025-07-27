using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Domain.Entity.User
{
    public  class CartItem : BaseEntity<int>
    {
        public virtual PerfumeLayte.Domain.Entity.Product.Product Product { get; set; }
        public int ProductId { get; set; }

        public int Count { get; set; }
        public int Price { get; set; }



        public virtual Cart Cart { get; set; }
        public int CartId { get; set; }

    }
}
