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
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult AddCustomer(Customer customer)
        {
            foreach (Customer cust in _customerDal.GetAll())
            {
                if (cust.UserId == customer.UserId)
                {
                    return new ErrorResult(Messages.AddError);
                }
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.AddSuccess);
        }

        public IResult DeleteCustomer(Customer customer)
        {
            foreach (var cust in _customerDal.GetAll())
            {
                if (cust.UserId == customer.UserId)
                {
                    _customerDal.Delete(customer);
                    return new SuccessResult(Messages.DeleteSuccess);
                }
            }
            return new ErrorResult(Messages.DeleteError);
        }

        public IDataResult<List<Customer>> GetAllCustomers()
        {
            int nowHour = DateTime.Now.Hour;
            if (nowHour <= 18 && nowHour > 8)
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
            }
            return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
        }

        public IDataResult<Customer> GetCustomerById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.GetAll().SingleOrDefault(cust => cust.UserId == id));
        }

        public IResult UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }
    }


}
