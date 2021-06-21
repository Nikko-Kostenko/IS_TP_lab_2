using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_TP_lab2.Models
{
    public class Function
    {
        public Function()
        {
            PhoneFunction = new List<PhoneFunction>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PhoneFunction> PhoneFunction { get; set; }
    }
}
