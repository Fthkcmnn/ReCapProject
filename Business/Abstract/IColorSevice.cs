using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IColorService
{
    
    IResult Add(Color entity);
    IResult Update(Color entity);
    IResult Delete(Color entity);
    Task<IDataResult<IEnumerable<Color>>> GetAllAsync();
    Task<IEnumerable<Color>> GetColorByName(string name);

}