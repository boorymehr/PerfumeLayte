using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Application.Interfaces.Contexts;

namespace PerfumeLayte.Application.Services.Product.Commands.EditProductByID
{
    class EditProduct : IEditProduct
    {
        private readonly IDataBaseContext _context;
        public EditProduct(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Execute(EditProductDto Pro, string MainSrc, List<string> Scr)
        {
            int ID = Pro.ProductID;
            var pro = await _context.Product.FindAsync(ID);

            if(Pro != null)
            {
                try
                {
                    PerfumeLayte.Domain.Entity.Product.Product Product = new Domain.Entity.Product.Product();
                    Product.Name = Pro.Name;
                    Product.Brand = Pro.Brand;
                    Product.Voluome = Pro.Voluome;
                    Product.Feacher = Pro.Feacher;
                    Product.isTahkfif = Pro.isTahkfif;
                    Product.CreateData = DateTime.Now;
                    Product.PriceNew = Pro.PriceNew;
                    Product.isVisite = Pro.isVisite;
                    Product.ScrMain = MainSrc;
                    Product.Price = pro.Price;
                    Product.CateguryID = 1;
                    _context.Product.Update(Product);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
                
            }
            return false;
        }
    }
}
