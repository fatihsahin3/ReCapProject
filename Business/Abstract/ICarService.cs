﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dto;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColorId(int brandId, int colorId);
        IDataResult<List<CarDetailDto>> GetByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetByColorId(int colorId);
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        
        IResult AddTransactionalTest(Car car);
    }
}
