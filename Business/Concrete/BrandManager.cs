using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetByBrandId(int brandId)
        {
            return _brandDal.Get(b => b.BrandId == brandId);
        }
    }
}