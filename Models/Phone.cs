using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_TP_lab2.Models
{
    public class Phone
    {
        public Phone()
        {
            PhoneFunctions = new List<PhoneFunction>();

            PhoneShops = new List<PhoneShop>();

            PhoneWishlists = new List<PhoneWishlist>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<PhoneShop> PhoneShops { get; set; }

        public virtual ICollection<PhoneWishlist> PhoneWishlists { get; set; }

        public virtual ICollection<PhoneFunction> PhoneFunctions { get; set; }
    }
}
