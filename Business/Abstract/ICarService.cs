using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        bool Add(Car car);
        bool Update(Car car);
        bool Delete(Car car);

        //Car GetById(int id);
        
    }
}
