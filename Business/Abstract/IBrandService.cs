using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetByBrandId(int brandId);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
