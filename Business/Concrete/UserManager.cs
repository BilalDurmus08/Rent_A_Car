using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult AddUser(User user)
        {
            foreach (User usr in _userDal.GetAll())
            {
                if (usr.Id == user.Id)
                {
                    return new ErrorResult(Messages.AddError);
                }
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.AddSuccess);
        }

        public IResult DeleteUser(User user)
        {
            foreach (var usr in _userDal.GetAll())
            {
                if (usr.Id == user.Id)
                {
                    _userDal.Delete(user);
                    return new SuccessResult(Messages.DeleteSuccess);
                }
            }
            return new ErrorResult(Messages.DeleteError);
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            int nowHour = DateTime.Now.Hour;
            if (nowHour <= 18 && nowHour > 8)
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll());
            }
            return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
        }

        public IDataResult<User> GetUserById(int id)
        {
            return new SuccessDataResult<User>(_userDal.GetAll().SingleOrDefault(usr => usr.Id == id));
        }

        public IResult UpdateUser(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
    }


}
