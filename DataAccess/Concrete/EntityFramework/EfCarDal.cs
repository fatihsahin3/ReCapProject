using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RPDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RPDBContext context = new RPDBContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto { Id=car.Id, BrandName = brand.BrandName, ColorName = color.ColorName, CarName = car.CarName, ModelYear = car.ModelYear, DailyPrice = car.DailyPrice };

                return result.ToList();
            }
        }
        

    }
}