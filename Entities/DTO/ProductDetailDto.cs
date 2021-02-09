using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Dto
{
    public class ProductDetailDto : IDto
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
    }
}
