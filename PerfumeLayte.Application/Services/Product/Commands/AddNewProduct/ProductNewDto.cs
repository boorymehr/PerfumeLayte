using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Commands.AddNewProduct
{
    public class ProductNewDto
    {
        public string Price { get; set; }

        public string Brand { get; set; }

        public string Name { get; set; }



        public string Feature { get; set; }

        public string Text { get; set; }


        public string? PriceNew { get; set; }

        public bool isTahkfif { get; set; }

        public int categuryID { get; set; }
        public bool isVisite { get; set; }


    }
}
