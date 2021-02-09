using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.Dto;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public bool Add(Car car)
        {
            if (ValidateCarName(car))
            {
                if (_carDal.Add(car) > 0) // Check if car was added into DB successfully.
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Car car)
        {
            if (_carDal.Delete(car) > 0) // Check if car was added into DB successfully.
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Car car)
        {
            if (_carDal.Update(car) > 0) // Check if car was added into DB successfully.
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        private bool ValidateCarName(Car car)
        {
            if (car.CarName.Length>2 && car.DailyPrice>0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int Id)
        {
            return _carDal.Get(c => c.CarId == Id);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _carDal.GetProductDetails();
        }

    }
}
