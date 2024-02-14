using Core.Utilites.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult AddBrand(Brand brand);
        IResult UpdateBrand(Brand brand);
        IResult DeleteBrand(int id);
        IDataResult<List<Brand>> GetAllBrands();
        IDataResult<Brand> GetBrandById(int id);

    }

}
