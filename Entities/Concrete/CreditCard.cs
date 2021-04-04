using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard
    {
        public string CardHolderName { get; set; }
        public int CardNumber { get; set; }
        public int CardCvv { get; set; }
        public string ExpirationDate { get; set; }
    }
}
