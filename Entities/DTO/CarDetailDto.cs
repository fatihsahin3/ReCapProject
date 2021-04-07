using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Dto
{
    public class CarDetailDto : IDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public int MinCreditScore { get; set; }
    }
}
