using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;

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
                _carDal.Add(car);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
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
            if (car.Description.Length>2 && car.DailyPrice>0 )
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

        //public Car GetById(int id)
        //{
        //    return _carDal.GetById(id);
        //}
    }
}
