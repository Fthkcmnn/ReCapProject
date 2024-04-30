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
    public async Task<IEnumerable<CarDetailDTOs>> GetCarDitailsAsync(Expression<Func<CarDetailDTOs, bool>>? filter = null)
    {
        using var context = new ReCarContext();
        var result = context.Car.Select(car => new CarDetailDTOs
        {
            CarId = car.CarId,
            CarName = car.Description,
            BrandName = context.Brand.SingleOrDefault(brand => brand.brandID == car.BrandId).name,
            ColorName = context.Color.SingleOrDefault(color => color.colorId == car.ColorId).name
        });
        return await result.ToListAsync();
    }
}