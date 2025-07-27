using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Domain.Entity.User
{
    public class Cart:BaseEntity<int>
    {

        public bool isFinaly { get; set; }
        public PerfumeLayte.Domain.Entity.User.User User { get; set; }
        public int UserID { get; set; }

        public string Price { get; set; }



        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
