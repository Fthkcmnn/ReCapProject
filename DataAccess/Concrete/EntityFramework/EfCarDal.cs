using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : EfEntityRepositoryBase<Car, ReCarContext>, ICarDal
{
    public IEnumerable<CarDetailDTOs> GetCarDitails(Expression<Func<CarDetailDTOs, bool>>? filter = null)
    {
        using var context = new ReCarContext();
        var result = context.Car.Include(c => c.CarImage).Select(car => new CarDetailDTOs
        {
            BrandName = car.Brand.Name,
            CarID = car.CarId,
            ColorName = car.Color.Name,
            Description = car.Description,
            Fuel = car.Fuel.Name,
            Luggage = car.Luggage,
            Mileage = car.Milage,
            ModelName = car.Model.Name,
            ModelYear = car.ModelYear,
            Seats = car.Seats,
            Transmission = car.Transmission.Name
        });
        return result.ToList();
    }
}