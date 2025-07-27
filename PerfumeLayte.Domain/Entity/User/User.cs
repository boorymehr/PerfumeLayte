using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Domain.Entity.Product;

namespace PerfumeLayte.Domain.Entity.User
{
    public class User : BaseEntity<int>
    {
        public string Mobile { get; set; }

        public string FullName { get; set; }


        public string CodeSmsPassword { get; set; }


        public bool isActive { get; set; }


        public string Address { get; set; }



        public string CodePost { get; set; }



        public string Password { get; set; }



        public string Email { get; set; }



        public bool isAdmin { get; set; }


        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }


        public virtual ICollection<LikeProduct> LikeProduct { get; set; }
    }
}
