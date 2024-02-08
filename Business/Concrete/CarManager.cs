using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;
        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public void AddCar(Car car)
        {
            foreach (var item in _CarDal.GetAll())
            {
                if(item.Id == car.Id) 
                {
                    Console.WriteLine("Id Already exist. The Car couldn't Added");
                    return;
                }
            }
            _CarDal.Add(car);
        }

        public List<CarDetailDto> carDetailDtos()
        {
           return _CarDal.GetCarDetailDtos();
        }

        public void DeleteCar(Car car)
        {
            foreach (var Car in _CarDal.GetAll())
            {
                if (Car.Id == car.Id)
                {
                    _CarDal.Delete(car);
                    return;
                }
            }
            Console.WriteLine("The car is not exist.");
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }


        public List<Car> GetCarsByColorId(int colorId)
        {
            return _CarDal.GetAll().Where(p => p.ColorId == colorId).ToList();
        }

        public List<Car> GetCarsyByBrandId(int brandId)
        {
            return _CarDal.GetAll().Where(p => p.BrandId == brandId).ToList();    
        }

        public void UpdateCar(Car car)
        {
            _CarDal.Update(car);
        }
    }

}
