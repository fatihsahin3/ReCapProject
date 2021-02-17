using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.Dto;
using DataAccess.Concrete.EntityFramework;
using Core.Utilities.Results;
using Business.Constraints;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (ValidateCarData(car))
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }

            return new ErrorResult(Messages.CarDataInvalid);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult Update(Car car)
        {
            if (ValidateCarData(car))
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }

            return new ErrorResult(Messages.CarDataInvalid);
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == Id), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour > 22 || DateTime.Now.Hour < 8)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour > 22 || DateTime.Now.Hour < 8)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<ProductDetailDto>>(_carDal.GetProductDetails(), Messages.CarsListed);
        }

        private bool ValidateCarData(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
