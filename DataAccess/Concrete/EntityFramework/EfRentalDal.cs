using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCarContext>, IRentalDal
    {
        public IEnumerable<RentalDetailDTOs> GetRentalDetails(Expression<Func<RentalDetailDTOs, bool>>? filter = null)
        {
            using (var context = new ReCarContext())
            {
                var rentalDetails = context.Rental
                    .Include(r => r.User)
                    .Select(r => new RentalDetailDTOs
                    {
                        UserFirstName = r.User.FirstName,
                        UserLastName = r.User.LastName,
                        UserEmail = r.User.Email,
                        CarBrandName = r.Package.Car.Brand.Name,
                        CarModelName = r.Package.Car.Model.Name,
                        Price = r.Price.ToString(), // Assuming Price is a numeric type
                        RentDate = r.RentDate.ToString(), // Assuming RentDate is a DateTime type
                        ReturnDate = r.ReturnDate.ToString() // Assuming ReturnDate is a DateTime type
                    })
                    .ToList();

                return rentalDetails;
            }
        }



    }
}
