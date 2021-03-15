using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Core.Utilities.Results;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal() 
        {
            _cars = new List<Car>()
            {
                new Car() {Id=1, BrandId=1, ColorId=1, ModelYear=2016, DailyPrice=150, Description="Toyota Corolla" },
                new Car() {Id=2, BrandId=2, ColorId=2, ModelYear=2018, DailyPrice=175, Description="Wolkswagen Passat" },
                new Car() {Id=3, BrandId=3, ColorId=1, ModelYear=2017, DailyPrice=175, Description="Ford Focus" },
                new Car() {Id=4, BrandId=2, ColorId=3, ModelYear=2020, DailyPrice=220, Description="Wolkswagen Jetta" },
                new Car() {Id=5, BrandId=1, ColorId=1, ModelYear=2015, DailyPrice=120, Description="Toyota Auris" },
                new Car() {Id=6, BrandId=3, ColorId=4, ModelYear=2017, DailyPrice=185, Description="Ford Mondeo" },
                new Car() {Id=7, BrandId=4, ColorId=5, ModelYear=2016, DailyPrice=185, Description="Opel Astra" },
                new Car() {Id=8, BrandId=3, ColorId=4, ModelYear=2019, DailyPrice=125, Description="Ford Fiesta" },
                new Car() {Id=9, BrandId=1, ColorId=1, ModelYear=2016, DailyPrice=100, Description="Toyota Yaris" },
                new Car() {Id=10, BrandId=4, ColorId=2, ModelYear=2018, DailyPrice=115, Description="Opel Corsa" },
                new Car() {Id=11, BrandId=5, ColorId=2, ModelYear=2016, DailyPrice=100, Description="Renault Clio" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault<Car>(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault<Car>(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int Id)
        {
            return _cars.SingleOrDefault<Car>(c => c.Id == Id);
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
