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
        IDataResult<List<Rental>> GetAllRental();
        IResult CarDeliver(int id, DateTime deliverTime);
    }

}
