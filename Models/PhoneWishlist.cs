using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_TP_lab2.Models
{
    public class PhoneWishlist
    {
        public int Id { get; set; }

        public int WishlistId { get; set; }

        public int PhoneId { get; set; }

        public virtual Phone Phone { get; set; }

        public virtual Wishlist Wishlist { get; set; }
    }
}
