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
            //ColorTEST();
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsyByBrandId(50);
            foreach (var item in result.Data)
            {
                Console.WriteLine("BrandId: " + item.BrandId + " Name: " + item.CarName);
            }

        }

        private static void ColorTEST()
        {
            ColorrManager colorrManager = new ColorrManager(new EfColorrDal());
            colorrManager.AddColor(new Colorr() { ColorName = "Purple", Id = 107 });
            foreach (var item in colorrManager.GetAllColors())
            {
                Console.WriteLine("ColorName: " + item.ColorName + " Color Id: " + item.Id);
            }
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
            var result = carManager.carDetailDtos();
            foreach (CarDetailDto carDetail in result.Data)
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
            var result = carManager.GetAll();
            if(result.Success == true)
            {
                foreach (Car car in result.Data)
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
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }

        private static void GetCarsByBrandIdTEST()
        {
            CarManager carManager2 = new CarManager(new EfCarDal());
            var result = carManager2.GetCarsyByBrandId(50);
            
            foreach (Car car in result.Data)
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
            var result = carManager1.GetCarsByColorId(102);
            
            foreach (Car car in result.Data)
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
