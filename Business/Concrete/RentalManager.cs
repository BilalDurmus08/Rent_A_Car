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
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult AddRental(Rental rental)
        {
            foreach (Rental rnt in _rentalDal.GetAll())
            {
                if (rnt.Id == rental.Id)
                {
                    return new ErrorResult(Messages.AddError);
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.AddSuccess);
        }

        public IResult DeleteRental(Rental rental)
        {
            foreach (var rnt in _rentalDal.GetAll())
            {
                if (rnt.Id == rental.Id)
                {
                    _rentalDal.Delete(rental);
                    return new SuccessResult(Messages.DeleteSuccess);
                }
            }
            return new ErrorResult(Messages.DeleteError);
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            int nowHour = DateTime.Now.Hour;
            if (nowHour <= 18 && nowHour > 8)
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            }
            return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetAll().SingleOrDefault(rnt => rnt.Id == id));
        }

        public IResult UpdateRental(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
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
