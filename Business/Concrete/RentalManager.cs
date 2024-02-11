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
    public class RentalManager : IRentalService
    {
        IRentalDal _RentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _RentalDal = rentalDal;
        }
        public IResult AddRental(Rental rental)
        {
            foreach (var item in _RentalDal.GetAll())
            {
               
                if ((item.Id == rental.Id) || (item.ReturnDate == null && item.CarId == rental.CarId))
                {
                    return new ErrorResult(Messages.AddError);
                }
           
            }

            _RentalDal.Add(rental);
            return new SuccessResult(Messages.AddSuccess);
        }

        public IDataResult<List<Rental>> GetAllRental()
        {
            return new SuccessDataResult<List<Rental>>(_RentalDal.GetAll());
        }

        public IResult CarDeliver(int id, DateTime deliverTime)
        {
            using (Rent_A_CarContext context = new Rent_A_CarContext())
            {
                var item = context.Rentals.FirstOrDefault(x => x.Id == id);
                if (item == null || item.ReturnDate != null)
                {
                    return new ErrorResult(Messages.UpdateError);
                }
                item.ReturnDate = deliverTime;
                context.SaveChanges();
                return new SuccessResult(Messages.ReturnCar);
            }
        }


    }

}
