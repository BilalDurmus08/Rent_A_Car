using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _BrandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _BrandDal = brandDal;
        }

        public void AddBrand(Brand brand)
        {
            foreach (Brand br in _BrandDal.GetAll())
            {
                if (br.Id == brand.Id)
                {
                    Console.WriteLine("It Already exist. The Brand couldn't Added");
                    return;
                }
            }
            _BrandDal.Add(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            foreach (var br in _BrandDal.GetAll())
            {
                if (br.Id == brand.Id)
                {
                    _BrandDal.Delete(brand);
                    return;
                }
            }
            Console.WriteLine("The brand is not exist.");
        }

        public List<Brand> GetAllBrands()
        {
            return _BrandDal.GetAll();
        }

        public Brand GetBrandById(int brandId)
        {
            return _BrandDal.GetAll().SingleOrDefault(p => p.Id == brandId);
        }

        public void UpdateBrand(Brand brand)
        {
            _BrandDal.Update(brand);
        }

     
    }

}
