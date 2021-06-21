using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_TP_lab2.Models
{
    public class PhoneShop
    {
        public int Id { get; set; }

        public int Price { get; set; }

        public int PhoneId { get; set; }

        public int ShopId { get; set; }

        public virtual Phone Phone { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
