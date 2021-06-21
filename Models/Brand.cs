using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_TP_lab2.Models
{
    public class Brand
    {
        public Brand()
        {
            Phones = new List<Phone>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
    }
}
