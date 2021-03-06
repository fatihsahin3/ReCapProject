using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

        IResult AddTransactionalTest(Car car);
    }
}
