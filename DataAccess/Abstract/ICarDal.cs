using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface ICarDal : IEntityRepository<Car>
{
    IEnumerable<CarDetailDTOs> GetCarDitails(Expression<Func<CarDetailDTOs, bool>>? filter = null);
	CarDetailDTOs GetCarDitail(Expression<Func<CarDetailDTOs, bool>>? filter = null);
}