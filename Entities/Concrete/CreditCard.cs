using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public byte ExpYear { get; set; }
        public string Cvv { get; set; }
        public string CardType { get; set; }
    }
}
