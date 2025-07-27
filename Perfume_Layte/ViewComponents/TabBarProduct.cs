using Microsoft.AspNetCore.Mvc;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.Product.Querises.GetListProduct;

namespace Perfume_Layte.ViewComponents
{
    public class TabBarProduct : ViewComponent
    {
        private readonly IFacadProduct _facadProduct;

        public TabBarProduct(IFacadProduct facadProduct)
        {
            _facadProduct = facadProduct;
        }


        public async Task<IViewComponentResult> InvokeAsync(string Cat)
        {
            var res = await _facadProduct.IGetListProductServices.Execute(6, Cat);
            return View(viewName: "/Views/Home/TabBarProduct.cshtml", model : res);
        }


    }
}
