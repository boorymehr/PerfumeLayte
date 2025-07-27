using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.Product.Commands.AddNewCategury;
using PerfumeLayte.Application.Services.Product.Commands.AddNewProduct;
using PerfumeLayte.Application.Services.Product.Querises.GetCateguryById;
using PerfumeLayte.Application.Services.Product.Querises.GetCateguryList;
using PerfumeLayte.Application.Services.Product.Querises.GetCateguryMain;
using PerfumeLayte.Application.Services.Product.Querises.GetListProduct;
using PerfumeLayte.Application.Services.Product.Querises.GetProductByID;
using PerfumeLayte.Application.Services.Product.Querises.GetProductListForSite;

namespace PerfumeLayte.Application.Services.Product.FacadProduct
{
    public class FacadProduct : IFacadProduct
    {
        private GetCategutyById GetCategutyById;
        private  IDataBaseContext _context;
        public FacadProduct(IDataBaseContext context)
        {
            _context = context;
            GetCategutyById = new GetCategutyById(_context);
        }
        public IGetListProductServices _IGetListProductServices;
        public IGetListProductServices IGetListProductServices { get
            {
                return _IGetListProductServices = _IGetListProductServices ?? new GetListProductServices(_context);
            } 
        }


        public IGetProductByIDServices _IGetProductByIDServices;
        public IGetProductByIDServices IGetProductByIDServices
        {
            get
            {
                return _IGetProductByIDServices = _IGetProductByIDServices ?? new GetProductByIDServices(_context);
            }
        }

        public IGetProductForSiteService _IGetProductForSiteService;
        public IGetProductForSiteService IGetProductForSiteService
        {
            get
            {
                return _IGetProductForSiteService = _IGetProductForSiteService ?? new GetProductForSiteService(_context);
            }
        }
       
        public INewProductServices _INewProductServices;
        public INewProductServices INewProductServices
        {
            get
            {
                return _INewProductServices = _INewProductServices ?? new NewProductServices(_context);
            }
        }
        public IAddCateguryServises _IAddCateguryServises;
        public IAddCateguryServises IAddCateguryServises
        {
            get
            {
                return _IAddCateguryServises = _IAddCateguryServises ?? new AddCateguryServises(_context, GetCategutyById);
            }
        }
        public IListCategury _IListCategury;
        public IListCategury IListCategury
        {
            get
            {
                return _IListCategury = _IListCategury ?? new ListCategury(_context);
            }
        }
        public IGetCateguryMain _IGetCateguryMain;
        public IGetCateguryMain IGetCateguryMain
        {
            get
            {
                return _IGetCateguryMain = _IGetCateguryMain ?? new GetCateguryMain(_context);
            }
        }
    }
}
