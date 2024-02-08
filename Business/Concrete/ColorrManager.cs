using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InEntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorrManager : IColorrService
    {
        IColorrDal _colorrDal;
        public ColorrManager(IColorrDal colorrDal)
        {
            _colorrDal = colorrDal;
        }

        public void AddColor(Colorr color)
        {
            foreach (Colorr clr in _colorrDal.GetAll())
            {
                if (clr.Id == color.Id)
                {
                    Console.WriteLine("It Already exist. The Brand couldn't Added");
                    return;
                }
            }
            _colorrDal.Add(color);
        }

        public void DeleteColor(Colorr color)
        {
            foreach (var clr in _colorrDal.GetAll())
            {
                if (clr.Id == color.Id)
                {
                    _colorrDal.Delete(color);
                    return;
                }
            }
            Console.WriteLine("The Color is not exist.");
        }

        public List<Colorr> GetAllColors()
        {
            return _colorrDal.GetAll();
        }

        public Colorr GetColorById(int id)
        {
            return _colorrDal.GetAll().SingleOrDefault(cl => cl.Id == id);
        }

        public void UpdateColor(Colorr color)
        {
            _colorrDal.Update(color);
        }

    }

}
