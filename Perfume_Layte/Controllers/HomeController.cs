using System.Diagnostics;
using Perfume_Layte.Models;
using Microsoft.AspNetCore.Mvc;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Services.User.Querises.GetUsers;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.Product.Querises.GetListProduct;

namespace Perfume_Layte.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IFacadProduct _facadProduct;

        public HomeController(IFacadProduct facadProduct)
        {
            _facadProduct = facadProduct;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["CateguryParentNulls"] = await _facadProduct.IGetCateguryMain.GetCateguryMainLayout();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
