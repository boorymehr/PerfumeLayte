using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Domain.Entity.Product;

namespace PerfumeLayte.Domain.Entity.User
{
     public class LikeProduct : BaseEntity<int>
    {

        public virtual PerfumeLayte.Domain.Entity.Product.Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }


        public virtual PerfumeLayte.Domain.Entity.User.User User { get; set; }
        public int UserID { get; set; }
    }
}
