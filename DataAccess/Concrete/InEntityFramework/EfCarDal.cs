using Core.DataAccess;
using Core.DataAccess.EntitFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InEntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Rent_A_CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (Rent_A_CarContext context = new Rent_A_CarContext())
            {
                var result = from cl in context.Colors
                             join c in context.Cars
                             on cl.Id equals c.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                             };
               return result.ToList();
            }
            
        }
    
    }

}
