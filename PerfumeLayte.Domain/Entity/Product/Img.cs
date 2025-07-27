using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Domain.Entity.Product
{
    public class Img : BaseEntity<int>
    {
        public string src { get; set; }


        public bool isMainImg { get; set; }


        public virtual Product Product { get; set; }

        public int ProductID { get; set; }
    }
}
