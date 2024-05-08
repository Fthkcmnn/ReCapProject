using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Web.Mvc;
namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : EfEntityRepositoryBase<Car, ReCarContext>, ICarDal
{
    public IEnumerable<CarDetailDTOs> GetCarDitails(Expression<Func<CarDetailDTOs, bool>>? filter = null)
    {
        using var context = new ReCarContext();

        IQueryable<CarDetailDTOs> query = context.Car.Include(c => c.CarImage).Where(car => car.isDeleted == false)
                                                     .Select(car => new CarDetailDTOs
                                                     {
                                                         BrandName = car.Brand.Name,
                                                         CarID = car.CarId,
                                                         ColorName = car.Color.Name,
                                                         Description = car.Description,
                                                         Fuel = car.Fuel.Name,
                                                         Luggage = car.Luggage,
                                                         Mileage = car.Mileage,
                                                         ModelName = car.Model.Name,
                                                         ModelYear = car.ModelYear,
                                                         Surcharge = car.Package.Select(p => p.Surcharge).FirstOrDefault().Value,
                                                         PerHourRate = car.Package.FirstOrDefault(p => p.RentalTypeID == 3).Price.Value,
                                                         PerDayRate = car.Package.FirstOrDefault(p => p.RentalTypeID == 1).Price.Value,
                                                         PerWeekRate = car.Package.FirstOrDefault(p => p.RentalTypeID == 2).Price.Value,
                                                         PerMounthRate = car.Package.FirstOrDefault(p => p.RentalTypeID == 6).Price.Value,
                                                         ImagePath = car.CarImage.Select(ci => ci.imagePath).FirstOrDefault(),
                                                         Transmission = car.Transmission.Name,
                                                         Seats = car.Seats
                                                     });
        if (filter != null) query = query.Where(filter);
        var result = query.ToList();
        return result;
    }

    public CarDetailDTOs GetCarDitail(Expression<Func<CarDetailDTOs, bool>>? filter = null)
    {
        using var context = new ReCarContext();

        var result = context.Car.Include(c => c.CarImage).Where(car => car.isDeleted == false)
                                .Select(car => new CarDetailDTOs
                                {
                                    BrandName = car.Brand.Name,
                                    CarID = car.CarId,
                                    ColorName = car.Color.Name,
                                    Description = car.Description,
                                    Fuel = car.Fuel.Name,
                                    Luggage = car.Luggage,
                                    Mileage = car.Mileage,
                                    ModelName = car.Model.Name,
                                    ModelYear = car.ModelYear,
                                    Surcharge = car.Package.Select(p => p.Surcharge).FirstOrDefault().Value,
                                    PerHourRate = car.Package.FirstOrDefault(p => p.RentalTypeID == 3).Price.Value,
                                    ImagePath = car.CarImage.Select(ci => ci.imagePath).FirstOrDefault(),
                                    Transmission = car.Transmission.Name,
                                    Seats = car.Seats
                                }).Where(filter).SingleOrDefault();
        return result;
    }

    public CarDetailEditDTO GetCarDitailEdit(Expression<Func<CarDetailEditDTO, bool>>? filter = null)
    {
        //Bir şey ancak bu kadar kötü yazılabilir.

        using var context = new ReCarContext();

        var result = context.Car.Include(c => c.CarImage).Where(car => car.isDeleted == false)
                                .Select(car => new CarDetailEditDTO
                                {
                                    CarID = car.CarId,
                                    Description = car.Description,
                                    Mileage = car.Mileage,
                                    ModelYear = car.ModelYear,
                                    Luggage = car.Luggage,
                                    PerHourRate = car.Package.FirstOrDefault(p => p.RentalTypeID == 3).Price.Value,
                                    ImagePath = car.CarImage.Select(ci => ci.imagePath).FirstOrDefault(),
                                    Surcharge = car.Package.Select(p => p.Surcharge).FirstOrDefault().Value,
                                    Brand = context.Brand.ToList(),
                                    Model = context.Model.ToList(),
                                    Color = context.Color.ToList(),
                                    Fuel = context.Fuel.ToList(),
                                    Seats = car.Seats,
                                    Transmision = context.Transmission.ToList()
                                }).Where(filter).FirstOrDefault();
        return result;
    }
}