using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.User.Querises.GetCartActive
{
    public class CartItemDto
    {
        public int ID { get; set; }

        public string Img { get; set; }

        public int Count { get; set; }


        public string price { get; set; }

        public string name { get; set; }
    }
}
