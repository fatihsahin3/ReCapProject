using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //TestCarRentalApplication(carManager);
            TestCars(carManager);
            TestBrands(brandManager);
            TestColors(colorManager);
        }

        private static void TestCars(CarManager carManager)
        {
            foreach (var car in carManager.GetAll()) // Test Gettin All Brands in DB.
            {
                Console.WriteLine(car.CarId + "-" + car.CarName + "-" + car.DailyPrice + "-" + car.Description);
            }
        }

        private static void TestColors(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll()) // Test Gettin All Brands in DB.
            {
                Console.WriteLine(color.ColorId + "-" + color.ColorName);
            }
        }

        private static void TestBrands(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll()) // Test Gettin All Brands in DB.
            {
                Console.WriteLine(brand.BrandId + "-" + brand.BrandName);
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

            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.CarName + ", Model Year:" + car.ModelYear + ", Daily Price:" + car.DailyPrice + ", Description:" + car.Description);
            }

            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.CarName + ", Model Year:" + car.ModelYear + ", Daily Price:" + car.DailyPrice + ", Description:" + car.Description);
            }
        }
    }
}
