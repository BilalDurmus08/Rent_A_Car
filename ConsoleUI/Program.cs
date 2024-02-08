using Business.Concrete;
using DataAccess.Concrete.InEntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetAllCarsTEST();
            //GetCarsByIdTEST();
            //GetCarsByBrandIdTEST();
            //CarDetailDtoTEST();
            //BrandGetAllTEST();

        }

        private static void BrandGetAllTEST()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var br in brandManager.GetAllBrands())
            {
                Console.WriteLine("Brand Name: " + br.BrandName + " Brand Id: " + br.Id);
            }
        }

        private static void CarDetailDtoTEST()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (CarDetailDto carDetail in carManager.carDetailDtos())
            {
                Console.WriteLine("CarName: " + carDetail.CarName +
                                  "\nBrandName: " + carDetail.BrandName +
                                  "\nColorName: " + carDetail.ColorName +
                                  "\nDailyPrice: " + carDetail.DailyPrice);
                Console.WriteLine("-----------------------------------");
            }
        }

        private static void GetAllCarsTEST()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Id: " + car.Id +
                                  "\nBrandId: " + car.BrandId +
                                  "\nColorId: " + car.ColorId +
                                  "\nModelYear: " + car.ModelYear +
                                  "\nDailyPrice: " + car.DailyPrice +
                                  "\nCarName: " + car.CarName);
                Console.WriteLine("-----------------------------------");
            }
        }

        private static void GetCarsByBrandIdTEST()
        {
            CarManager carManager2 = new CarManager(new EfCarDal());
            List<Car> byBrand = carManager2.GetCarsyByBrandId(50);
            Console.WriteLine("****************");
            Console.WriteLine("****************");
            Console.WriteLine("****************");
            foreach (Car car in byBrand)
            {
                Console.WriteLine("Id: " + car.Id +
                                "\nBrandId: " + car.BrandId +
                                "\nColorId: " + car.ColorId +
                                "\nModelYear: " + car.ModelYear +
                                "\nDailyPrice: " + car.DailyPrice);
                Console.WriteLine("-----------------------------------");
            }
        }

        private static void GetCarsByIdTEST()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());

            List<Car> byColor = carManager1.GetCarsByColorId(102);
            foreach (Car car in byColor)
            {
                Console.WriteLine("Id: " + car.Id +
                                "\nBrandId: " + car.BrandId +
                                "\nColorId: " + car.ColorId +
                                "\nModelYear: " + car.ModelYear +
                                "\nDailyPrice: " + car.DailyPrice);
                Console.WriteLine("-----------------------------------");
            }
        }
    }

}
