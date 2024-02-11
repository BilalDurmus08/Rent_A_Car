using Core.DataAccess.EntitFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InEntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, Rent_A_CarContext>, IRentalDal
    {

    }

}
