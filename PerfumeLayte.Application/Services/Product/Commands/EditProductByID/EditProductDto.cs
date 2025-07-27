using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Domain.Entity.Categurys;
using PerfumeLayte.Domain.Entity.Product;
using PerfumeLayte.Domain.Entity.User;

namespace PerfumeLayte.Application.Services.Product.Commands.EditProductByID
{
    public class EditProductDto
    {
        public int ProductID { get; set; }
        public string Price { get; set; }

        public string Brand { get; set; }

        public string Name { get; set; }



        public string Feacher { get; set; }


        public string Voluome { get; set; }


        public string? PriceNew { get; set; }


        public bool isTahkfif { get; set; }



        public string ScrMain { get; set; }


        public bool isVisite { get; set; }


    }
}
