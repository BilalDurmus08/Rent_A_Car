using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Add(Car car)
        {
            //Some business code blocks
            //Is he/she allows to use ? 
            _CarDal.Add(car);
        }

        public void Delete(Car car)
        {
            //Some business code blocks
            //Is he/she allows to use ?   
            _CarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //Some business code blocks
            //Is he/she allows to use ? 
            return _CarDal.GetAll();
        }

        public Car GetById(int id)
        {
            //Some business code blocks
            //Is he/she allows to use ? 
            return _CarDal.GetById(id);
        }

        public void Update(Car car)
        {
            //Some business code blocks
            //Is he/she allows to use ? 
            _CarDal.Update(car);
        }

    }

}
