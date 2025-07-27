using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Services.Product.Querises.GetProductByID;
using PerfumeLayte.Domain.Entity.Product;

namespace PerfumeLayte.Application.Services.Product.Commands.AddNewProduct
{
    public class NewProductServices : INewProductServices
    {
        private readonly IDataBaseContext _context;
        public NewProductServices(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Execute(ProductNewDto Product,List<Image> Image,string srcMain)
        {
           try
            {
                PerfumeLayte.Domain.Entity.Product.Product Pro = new PerfumeLayte.Domain.Entity.Product.Product();
                Pro.Name = Product.Name;
                Pro.Brand = Product.Brand;
                Pro.Voluome = Product.Text;
                Pro.Feacher = Product.Feature;
                Pro.isTahkfif = Product.isTahkfif;
                Pro.CreateData = DateTime.Now;
                Pro.PriceNew = Product.PriceNew;
                Pro.isVisite = Product.isVisite;
                Pro.ScrMain = srcMain;
                Pro.Price = Product.Price;
                Pro.CateguryID = Product.categuryID;
               await _context.Product.AddAsync(Pro);
                List<PerfumeLayte.Domain.Entity.Product.Img> Imgs = new List<Img>();

                foreach (var images in Image)
                {
                    Img imageProduct = new Img(); 
                    imageProduct.src = images.src;
                    imageProduct.Product = Pro;
                    Imgs.Add(imageProduct);
                }
                await _context.Img.AddRangeAsync(Imgs);
               
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }

        }
    }
}
