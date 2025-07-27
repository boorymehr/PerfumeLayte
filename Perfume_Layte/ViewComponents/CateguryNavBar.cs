using Microsoft.AspNetCore.Mvc;
using PerfumeLayte.Application.Interfaces.IFacadPattern;

namespace Perfume_Layte.ViewComponents
{
    public class CateguryNavBar : ViewComponent
    {
        private readonly IFacadProduct _facadProduct;

        public CateguryNavBar(IFacadProduct facadProduct)
        {
            _facadProduct = facadProduct;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Res = await _facadProduct.IListCategury.Execute();
            return View(viewName: "CateguryNavBar.cshtml", model : Res);
        }


    }
}
