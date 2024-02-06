using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InEntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (Rent_A_CarContext context = new Rent_A_CarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }

        }

        public void Delete(Car entity)
        {
            using (Rent_A_CarContext context = new Rent_A_CarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (Rent_A_CarContext context = new Rent_A_CarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (Rent_A_CarContext context = new Rent_A_CarContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }

        }

        public void Update(Car entity)
        {
            using (Rent_A_CarContext context = new Rent_A_CarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    
    }

}
