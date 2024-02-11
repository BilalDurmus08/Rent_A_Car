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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _CustomerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _CustomerDal = customerDal;
        }
        public IResult AddCustomer(Customer customer)
        {
            _CustomerDal.Add(customer);
            return new SuccessResult(Messages.AddSuccess);
        }

        public IDataResult<List<Customer>> GetAllCustomer()
        {
            return new SuccessDataResult<List<Customer>>(_CustomerDal.GetAll());
        }
    
    }

}
