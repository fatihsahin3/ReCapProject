using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //TestCarRentalApplication(carManager); // Test Car Rental Application
            //TestGetAllCars(carManager); //Test getting all cars in DB.
            //TestGetCarById(carManager); //Test getting a car by ID.
            //TestAddCar(carManager); //Test adding a car into DB.
            //TestDeleteCar(carManager); //Test deleting a car from DB.
            //TestUpdateCar(carManager); //Test updating a car in DB.
            //TestGetAllBrands(brandManager); // Test getting all brands in DB.
            //TestGetAllColors(colorManager); // Test getting all colors in DB.
            TestProductDetails(carManager); // Test getting all details based on predefined DTO class.
        }

        private static void TestGetAllCars(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + "-" + car.CarName + "-" + car.DailyPrice + "-" + car.Description);
            }
        }

        private static void TestGetCarById(CarManager carManager)
        {
            Car car = carManager.GetById(9);
            Console.WriteLine(car.CarId + "-" + car.CarName + "-" + car.DailyPrice + "-" + car.Description);

        }

        private static void TestAddCar(CarManager carManager) 
        {
            if (carManager.Add(new Car { BrandId = 5, ColorId = 1, CarName = "Renault Megane", ModelYear = 2021, DailyPrice = 150, Description = "Renault Megane, Diesel, Automatic Transmission" }))
            {
                Console.WriteLine("Car was added into DB successfully!");
            }
            else
            {
                Console.WriteLine("Car could not be added into DB!");
            }
        }

        private static void TestDeleteCar(CarManager carManager)
        {
            if (carManager.Delete(new Car { CarId = 1003 }))
            {
                Console.WriteLine("Car was deleted from DB successfully!");
            }
            else
            {
                Console.WriteLine("Car could not be deleted!");
            }
        }

        private static void TestUpdateCar(CarManager carManager)
        {
            if (carManager.Update(new Car { CarId = 1004, BrandId = 5, ColorId = 2, CarName = "Renault Symbol", ModelYear = 2016, DailyPrice = 100, Description = "Renault Symbol, Diesel, Manual Transmission" }))
            {
                Console.WriteLine("Car was updated successfully!");
            }
            else
            {
                Console.WriteLine("Car could not be updated!");
            }
        }

        private static void TestGetAllColors(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + "-" + color.ColorName);
            }
        }

        private static void TestGetAllBrands(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + "-" + brand.BrandName);
            }
        }

        private static void TestProductDetails(CarManager carManager)
        {
            foreach (var car in carManager.GetProductDetails())
            {
                Console.WriteLine(car.CarName + "-" + car.BrandName + "-" + car.ColorName + "-" + car.DailyPrice);
            }
        }

        private static void TestCarRentalApplication(CarManager carManager)
        {
            Console.WriteLine("**********************************************\n" +
                              "***** Welcome to our car rent company!   *****\n" +
                              "***** You can view available cars below: *****\n" +
                              "**********************************************\n");

            for (int i = 0; i < carManager.GetAll().Count; i++)
            {
                Console.WriteLine(i + 1 + ") " + carManager.GetAll()[i].CarName + ", Model Year:" + carManager.GetAll()[i].ModelYear + ", Daily Price:" + carManager.GetAll()[i].DailyPrice + ", Description:" + carManager.GetAll()[i].Description + "\n------------------------------------------------------------------------------------------------------------");
                //Console.WriteLine((i + 1) + ") " + carManager.GetById(i + 1).CarName + ", Model Year:" + carManager.GetById(i + 1).ModelYear + ", Daily Price:" + carManager.GetById(i + 1).DailyPrice + ", Description:" + carManager.GetAll()[i].Description + "\n------------------------------------------------------------------------------------------------------------");
            }

            //foreach (var car in carManager.GetCarsByBrandId(3))
            //{
            //    Console.WriteLine(car.CarName + ", Model Year:" + car.ModelYear + ", Daily Price:" + car.DailyPrice + ", Description:" + car.Description);
            //}

            //foreach (var car in carManager.GetCarsByColorId(1))
            //{
            //    Console.WriteLine(car.CarName + ", Model Year:" + car.ModelYear + ", Daily Price:" + car.DailyPrice + ", Description:" + car.Description);
            //}
        }
    }
}
