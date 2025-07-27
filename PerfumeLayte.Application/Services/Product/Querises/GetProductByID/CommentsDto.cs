using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Querises.GetProductByID
{
    public class CommentsDto
    {
        public int Stars { get; set; }
        public string Title { get; set; }
        public bool isVisite { get; set; }

        public string UserName { get; set; }
        public string MainText { get; set; }
    }
}
