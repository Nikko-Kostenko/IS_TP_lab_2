using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_TP_lab2.Models
{
    public class PhoneFunction
    {
        public int Id { get; set; }

        public int PhoneId { get; set; }

        public int FunctId { get; set; }

        public virtual Phone Phone { get; set; }

        public virtual Function Function { get; set; }
    }
}
