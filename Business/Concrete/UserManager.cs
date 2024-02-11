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
        IUserDal _UserDal;
        public UserManager(IUserDal userDal)
        {
            _UserDal = userDal;
        }
        public IResult AddUser(User user)
        {
            _UserDal.Add(user);
            return new SuccessResult(Messages.AddSuccess);
        }

        public IDataResult<List<User>> GetAllUser()
        {
            return new SuccessDataResult<List<User>>(_UserDal.GetAll());
        }
    
    }

}
