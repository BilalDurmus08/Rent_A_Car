using Core.Utilites.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult AddUser(User user);
        IResult UpdateUser(User user);
        IResult DeleteUser(User user);
        IDataResult<List<User>> GetAllUsers();
        IDataResult<User> GetUserById(int id);
    }
        
}
