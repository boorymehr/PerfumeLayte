
using Microsoft.AspNetCore.Mvc;
using PerfumeLayte.Application.Services.Product.Querises.GetListProduct;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.Product.Querises.GetProductByID;
using PerfumeLayte.Application.Services.Product.Commands.AddNewProduct;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authorization;
using Perfume_Layte.Permition;


namespace Perfume_Layte.Areas.Admin.Controllers
{
    [PermisionChecker(true)]
    [Authorize]
    [Area("Admin")]
    public class HomeController : Controller
    {

        private readonly IFacadProduct _IFacadProduct;

        public HomeController(IFacadProduct IFacadProduct)
        {
            _IFacadProduct = IFacadProduct;
        }
        #region Product
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditProduct(int ProductID)
        {
            GetProductByID ListPro = await _IFacadProduct.IGetProductByIDServices.Execute(ProductID);
            TempData["ProductID"] = ProductID;
            return View(ListPro);
        }


        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductNewDto Pro, List<IFormFile> Img, IFormFile fileMain)
        {
            int ProductID = (int)TempData["ProductID"];

            
            var isProductId = await _IFacadProduct.IGetProductByIDServices.Execute(Pro.categuryID);


            List<Image> images = new List<Image>();
            string FileName = "";
            string FileNameMain = "";
            string PathFileSaveImg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/public/");
            FileNameMain = Guid.NewGuid().ToString() + fileMain.FileName;
            if (fileMain.Length > 0)
            {
                using (var fileStream = new FileStream(PathFileSaveImg + FileNameMain, FileMode.Create))
                {
                    await fileMain.CopyToAsync(fileStream);
                }
            }

            foreach (var i in Img)
            {
                FileName = Guid.NewGuid().ToString() + i.FileName;
                if (i.Length > 0)
                {
                    using (var fileStreamChild = new FileStream(PathFileSaveImg + FileName, FileMode.Create))
                    {
                        await i.CopyToAsync(fileStreamChild);
                    }
                }
                images.Add(new Image()
                {
                    src = FileName
                });
            }
            return View();
        }




        public async Task<IActionResult> PruductById(int ProductID)
        {
            GetProductByID ListPro = await _IFacadProduct.IGetProductByIDServices.Execute(ProductID);
            return View(ListPro);
        }





        public async Task<IActionResult> ListProduct(int Page = 1, string searchkey = "")
        {
            var result = new RequestGetListProductDto()
            {
                Page = Page,
                PageSize = 12,
                SearchKey = searchkey
            };
            ReslutGetListProductDto ListPro = await _IFacadProduct.IGetListProductServices.Execute(result);
            return View(ListPro);
        }


        [HttpGet]
        public async Task<IActionResult> NewProduct()
        {
            ViewBag.ListCategury = new SelectList(await _IFacadProduct.IListCategury.Execute(), "CateguryDtoID", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewProduct(ProductNewDto Pro, List<IFormFile> Img, IFormFile fileMain)
        {
            List<Image> images = new List<Image>();
            string FileName = "";
            string FileNameMain = "";
            string PathFileSaveImg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/public/");
            FileNameMain = Guid.NewGuid().ToString() + fileMain.FileName;
            if (fileMain.Length > 0)
            {
                using (var fileStream = new FileStream(PathFileSaveImg + FileNameMain, FileMode.Create))
                {
                    await fileMain.CopyToAsync(fileStream);
                }
            }

            foreach (var i in Img)
            {
                FileName = Guid.NewGuid().ToString() + i.FileName;
                if (i.Length > 0)
                {
                    using (var fileStreamChild = new FileStream(PathFileSaveImg + FileName, FileMode.Create))
                    {
                        await i.CopyToAsync(fileStreamChild);
                    }
                }
                images.Add(new Image()
                {
                    src = FileName
                });
            }
            bool Resualt = await _IFacadProduct.INewProductServices.Execute(Pro, images, FileNameMain);
            return View();
        }
        #endregion
    }
}
