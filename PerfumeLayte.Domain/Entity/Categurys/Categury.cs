using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Domain.Entity.Product;

namespace PerfumeLayte.Domain.Entity.Categurys
{
    public class Categury : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual Categury ParentCategury { get; set; }
        public int? ParentCategoryId { get; set; }


        //برای نمایش زیر دسته های هر گروه
        public virtual ICollection<Categury> SubCategurys { get; set; }



        public virtual ICollection<PerfumeLayte.Domain.Entity.Product.Product> Products { get; set; }

    }
}
