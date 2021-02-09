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
        public List<ProductDetailDto> GetProductDetails()
        {
            using (RPDBContext context = new RPDBContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new ProductDetailDto {CarName = car.CarName, BrandName = brand.BrandName, ColorName = color.ColorName, DailyPrice = car.DailyPrice };

                return result.ToList();
            }
        }
        

    }
}