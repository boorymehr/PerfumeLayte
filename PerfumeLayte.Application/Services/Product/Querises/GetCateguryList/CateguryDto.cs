using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Domain.Entity.Categurys;

namespace PerfumeLayte.Application.Services.Product.Querises.GetCateguryList
{
    public class CateguryDto
    {

        public int CateguryDtoID { get; set; }

        public string Name { get; set; }

        public CateguryDto ParentCategury { get; set; }
        public int? ParentCategoryId { get; set; }


        //برای نمایش زیر دسته های هر گروه
        public  List<CateguryDto> SubCategurys { get; set; }

    }
}
