using Core.Utilites.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult AddRental(Rental rental);
        IResult UpdateRental(Rental rental);
        IResult DeleteRental(Rental rental);
        IDataResult<List<Rental>> GetAllRentals();
        IDataResult<Rental> GetRentalById(int id);
        IResult CarDeliver(int id, DateTime deliverTime);
    }

}
