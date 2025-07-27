
using PerfumeLayte.Domain.Entity.Product;

namespace PerfumeLayte.Application.Services.Product.Querises.GetProductByID
{
    public class GetProductByID
    {
        public int ID { get; set; }

        public string Price { get; set; }

        public string Brand { get; set; }

        public string Name { get; set; }

        public string categury { get; set; }


        public string feature { get; set; }

        public string text { get; set; }

        public string ScrMain { get; set; }
        public string? PriceNew { get; set; }

        public bool isTahkfif { get; set; }


        public bool isVisite { get; set; }



        public ICollection<string> src { get; set; }


        public ICollection<CommentsDto> CommentsDto { get; set; }




    }
}
