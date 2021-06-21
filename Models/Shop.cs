using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_TP_lab2.Models
{
    public class Shop
    {
        public Shop()
        {
            PhoneShop = new List<PhoneShop>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PhoneShop> PhoneShop { get; set; }
    }
}
