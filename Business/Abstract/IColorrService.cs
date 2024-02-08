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
        void AddColor(Colorr color);
        void UpdateColor(Colorr color);
        void DeleteColor(Colorr color);
        List<Colorr> GetAllColors();
        Colorr GetColorById(int id);
    }

}
