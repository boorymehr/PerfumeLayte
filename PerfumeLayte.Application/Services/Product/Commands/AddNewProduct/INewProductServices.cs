using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Application.Services.Product.Querises.GetProductByID;

namespace PerfumeLayte.Application.Services.Product.Commands.AddNewProduct
{
    public interface INewProductServices
    {
        public Task<bool> Execute(ProductNewDto Product, List<Image> Imagers, string srcMain);
    }
}
