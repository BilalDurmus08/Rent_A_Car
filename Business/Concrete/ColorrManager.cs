using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
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

        public IResult AddColor(Colorr color)
        {
            foreach (Colorr clr in _colorrDal.GetAll())
            {
                if (clr.Id == color.Id)
                {
                    return new ErrorResult(Messages.AddError);
                }
            }
            _colorrDal.Add(color);
            return new SuccessResult(Messages.AddSuccess);
        }

        public IResult DeleteColor(Colorr color)
        {
            foreach (var clr in _colorrDal.GetAll())
            {
                if (clr.Id == color.Id)
                {
                    _colorrDal.Delete(color);
                    return new SuccessResult(Messages.DeleteSuccess);
                }
            }
            return new ErrorResult(Messages.DeleteError);
        }

        public IDataResult<List<Colorr>> GetAllColors()
        {
            int nowHour = DateTime.Now.Hour;
            if (nowHour <= 18 && nowHour > 8)
            {
                return new SuccessDataResult<List<Colorr>>(_colorrDal.GetAll());
            }
            return new ErrorDataResult<List<Colorr>>(Messages.MaintenanceTime);
        }

        public IDataResult<Colorr> GetColorById(int id)
        {
            return new SuccessDataResult<Colorr>(_colorrDal.GetAll().SingleOrDefault(cl => cl.Id == id));
        }

        public IResult UpdateColor(Colorr color)
        {
            _colorrDal.Update(color);
            return new SuccessResult();
        }

    }

}
