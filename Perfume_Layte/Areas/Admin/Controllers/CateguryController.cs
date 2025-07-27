using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Perfume_Layte.Permition;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.Product.Commands.AddNewCategury;
using PerfumeLayte.Application.Services.Product.Querises.GetCateguryList;

namespace Perfume_Layte.Areas.Admin.Controllers
{
    [PermisionChecker(true)]
    [Authorize]
    [Area("Admin")]
    public class CateguryController : Controller
    {
        private readonly IFacadProduct _IFacadProduct;

        public CateguryController(IFacadProduct IFacadProduct)
        {
            _IFacadProduct = IFacadProduct;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ListData = await _IFacadProduct.IListCategury.Execute();
            return View(ListData);
        }



        [HttpGet]
        public async Task<IActionResult> AddCategury(int ID)
        {
                ViewData["ParentCategury"] = ID;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddCategury(string ID, CateguryAddDto CateguryDto)
        {
            var ParendID = Convert.ToInt32(ID);
            var res = await _IFacadProduct.IAddCateguryServises.AddCategury(ParendID, CateguryDto);
            return View();
        }
    }
}
