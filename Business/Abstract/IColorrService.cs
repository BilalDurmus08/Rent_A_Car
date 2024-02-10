using Core.Utilites.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorrService
    {
        IResult AddColor(Colorr color);
        IResult UpdateColor(Colorr color);
        IResult DeleteColor(Colorr color);
        IDataResult<List<Colorr>> GetAllColors();
        IDataResult<Colorr> GetColorById(int id);
    }

}
