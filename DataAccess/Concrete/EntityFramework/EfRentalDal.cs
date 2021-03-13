using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RPDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RPDBContext context = new RPDBContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto { Id= rental.Id, BrandName = brand.BrandName, CustomerName = user.FirstName + " " + user.LastName, RentDate = rental.RentDate.ToString("dd/MM/yyyy HH:mm:ss"), ReturnDate = ((DateTime)rental.ReturnDate).ToString("dd/MM/yyyy HH:mm:ss")};

                return result.ToList();
            }
        }
    }
}