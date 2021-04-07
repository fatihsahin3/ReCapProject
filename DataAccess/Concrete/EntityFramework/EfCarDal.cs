using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RPDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RPDBContext context = new RPDBContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto { Id = car.Id, BrandId=car.BrandId, BrandName = brand.BrandName, ColorId=car.ColorId, ColorName = color.ColorName, CarName = car.CarName, ModelYear = car.ModelYear, DailyPrice = car.DailyPrice, Description=car.Description, MinCreditScore=car.MinCreditScore };

                return result.ToList();
            }
        }
    }
}