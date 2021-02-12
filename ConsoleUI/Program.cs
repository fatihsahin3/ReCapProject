﻿using System;
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
            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + "-" + car.CarName + "-" + car.DailyPrice + "-" + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }            
        }

        private static void TestGetCarById(CarManager carManager)
        {
            var result = carManager.GetById(1);

            if (result.Success)
            {
                Console.WriteLine(result.Data.CarId + "-" + result.Data.CarName + "-" + result.Data.DailyPrice + "-" + result.Data.Description);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void TestAddCar(CarManager carManager) 
        {
            var result = carManager.Add(new Car { BrandId = 5, ColorId = 1, CarName = "Renault Megane", ModelYear = 2021, DailyPrice = 150, Description = "Renault Megane, Diesel, Automatic Transmission" });
            Console.WriteLine(result.Message);
        }

        private static void TestDeleteCar(CarManager carManager)
        {
            var result = carManager.Delete(new Car { CarId = 1004 });
            Console.WriteLine(result.Message);
        }

        private static void TestUpdateCar(CarManager carManager)
        {
            var result = carManager.Update(new Car { CarId = 11, BrandId = 5, ColorId = 2, CarName = "Renault Symbol", ModelYear = 2016, DailyPrice = 100, Description = "Renault Symbol, Diesel, Manual Transmission" });
            Console.WriteLine(result.Message);
        }

        private static void TestGetAllColors(ColorManager colorManager)
        {
            var result = colorManager.GetAll();

            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorId + "-" + color.ColorName);
            }
        }

        private static void TestGetAllBrands(BrandManager brandManager)
        {
            var result = brandManager.GetAll();

            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandId + "-" + brand.BrandName);
            }
        }

        private static void TestProductDetails(CarManager carManager)
        {
            var result = carManager.GetProductDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "-" + car.BrandName + "-" + car.ColorName + "-" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            } 
        }

        private static void TestCarRentalApplication(CarManager carManager)
        {
            Console.WriteLine("**********************************************\n" +
                              "***** Welcome to our car rent company!   *****\n" +
                              "***** You can view available cars below: *****\n" +
                              "**********************************************\n");

            var result = carManager.GetAll();

            if (result.Success)
            {
                for (int i = 0; i < result.Data.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + result.Data[i].CarName + ", Model Year:" + result.Data[i].ModelYear + ", Daily Price:" + result.Data[i].DailyPrice + ", Description:" + result.Data[i].Description + "\n------------------------------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
