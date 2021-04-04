using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment
    {
        public Rental Rental { get; set; }
        public CreditCard CreditCard { get; set; }
        public int Amount { get; set; }
    }
}
