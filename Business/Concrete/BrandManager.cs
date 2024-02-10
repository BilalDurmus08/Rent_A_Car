using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InEntityFramework;
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

        public IResult AddBrand(Brand brand)
        {
            foreach (Brand br in _BrandDal.GetAll())
            {
                if (br.Id == brand.Id)
                {
                    return new ErrorResult(Messages.AddError);
                }
            }
            _BrandDal.Add(brand);
            return new SuccessResult(Messages.AddSuccess);
        }

        public IResult DeleteBrand(Brand brand)
        {
            foreach (var br in _BrandDal.GetAll())
            {
                if (br.Id == brand.Id)
                {
                    _BrandDal.Delete(brand);
                    return new SuccessResult(Messages.DeleteSuccess);
                }
            }
            return new ErrorResult(Messages.DeleteError);
        }

        public IDataResult<List<Brand>> GetAllBrands()
        {
            int nowHour = DateTime.Now.Hour;
            if (nowHour <= 18 && nowHour > 8)
            {
                return new SuccessDataResult<List<Brand>>(_BrandDal.GetAll());
            }
            return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
        }

        public IDataResult<Brand> GetBrandById(int brandId)
        {
            return new SuccessDataResult<Brand>(_BrandDal.GetAll().SingleOrDefault(p => p.Id == brandId));
        }

        public IResult UpdateBrand(Brand brand)
        {
            _BrandDal.Update(brand);
            return new SuccessResult();
        }

     
    }

}
