using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Domain.Entity
{
    public class BaseEntity<T>
    {
        [Key]
        public T? ID { get; set; }



        public bool isDelete { get; set; }


        public DateTime CreateData { get; set; }
    }
}
