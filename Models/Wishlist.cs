using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_TP_lab2.Models
{
    public class Wishlist
    {
        public Wishlist()
        {
            PhoneWishlist = new List<PhoneWishlist>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<PhoneWishlist> PhoneWishlist { get; set; }
    }
}
