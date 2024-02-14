using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
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

        public IResult AddCar(Car car)
        {
            foreach (var item in _CarDal.GetAll())
            {
                if(item.Id == car.Id) 
                {
                    return new ErrorResult(Messages.AddError);
                }
            }
            _CarDal.Add(car);
            return new SuccessResult(Messages.AddSuccess);
        }

        public IDataResult<List<CarDetailDto>> carDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetailDtos());
        }

        public IResult DeleteCar(Car car)
        {
            foreach (var Car in _CarDal.GetAll())
            {
                if (Car.Id == car.Id)
                {
                    _CarDal.Delete(car);
                    return new SuccessResult(Messages.DeleteSuccess);
                }
            }
            return new ErrorResult(Messages.DeleteError);
        }

        public IDataResult<List<Car>> GetAll()
        {
            int nowHour= DateTime.Now.Hour;
            if(nowHour <= 18 && nowHour > 8)
            {
                return new SuccessDataResult<List<Car>>(_CarDal.GetAll(),Messages.GetSuccess);
            }
            return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
        }


        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll().Where(p => p.ColorId == colorId).ToList());
        }

        public IDataResult<List<Car>> GetCarsyByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll().Where(p => p.BrandId == brandId).ToList());    
        }

        public IResult UpdateCar(Car car)
        {
            if (car == null)
            {
                return new ErrorResult(Messages.IsNull);
            }
            _CarDal.Update(car);
            return new SuccessResult();
        }
    }

}
