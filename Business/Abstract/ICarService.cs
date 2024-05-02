using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService
{
    // Entity operations
    IResult Add(Car entity);
    IResult Update(Car entity);
    IResult Delete(Car entity);
    IDataResult<Car> GetCarById(int id);
    IDataResult<IEnumerable<Car>> GetAll();
    Task<IDataResult<IEnumerable<Car>>> GetAllAsync();
    IDataResult<IEnumerable<CarDetailDTOs>> GetCarDetails();
	IDataResult<CarDetailDTOs> GetCarDetailsById(int id);
	IDataResult<IEnumerable<CarDetailDTOs>> GetCarDetailsByDescription(string description);
}