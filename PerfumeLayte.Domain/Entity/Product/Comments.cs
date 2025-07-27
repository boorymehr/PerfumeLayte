using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Domain.Entity.User;

namespace PerfumeLayte.Domain.Entity.Product
{
    public class Comments : BaseEntity<int>
    {

        public int Stars { get; set; }

        public bool isVisite { get; set; }
        public string Title { get; set; }

        public string MainText { get; set; }


        public virtual PerfumeLayte.Domain.Entity.User.User User { get; set; }
        public int UserID { get; set; }


        public virtual Product Product { get; set; }
        public int ProductID { get; set; }
    }
}
