using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Application.Services.Product.Commands.AddNewCategury;
using PerfumeLayte.Application.Services.Product.Commands.AddNewProduct;
using PerfumeLayte.Application.Services.Product.Querises.GetCateguryById;
using PerfumeLayte.Application.Services.Product.Querises.GetCateguryList;
using PerfumeLayte.Application.Services.Product.Querises.GetCateguryMain;
using PerfumeLayte.Application.Services.Product.Querises.GetListProduct;
using PerfumeLayte.Application.Services.Product.Querises.GetProductByID;
using PerfumeLayte.Application.Services.Product.Querises.GetProductListForSite;

namespace PerfumeLayte.Application.Interfaces.IFacadPattern
{
    public interface IFacadProduct
    {
        public IGetListProductServices IGetListProductServices { get;}
        public IGetProductForSiteService IGetProductForSiteService { get; }
        public IGetProductByIDServices IGetProductByIDServices { get; }
         public IGetCateguryMain IGetCateguryMain { get; }
        public IAddCateguryServises IAddCateguryServises { get; }
        public INewProductServices INewProductServices { get; }


        public IListCategury IListCategury { get; }
    }
}
