using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Domain.Entity.Slider
{
    public class Slider : BaseEntity<int>
    {
        public string src { get; set; }



        public string Url { get; set; }



        public bool isMain { get; set; }
    }
}
