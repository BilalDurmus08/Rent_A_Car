
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
        public IResult AddColor(Colorr color);
        public IResult DeleteColor(Colorr color);
        public IDataResult<List<Colorr>> GetAllColors();
        public IDataResult<Colorr> GetColorById(int id);
        public IResult UpdateColor(Colorr color);
    }
}