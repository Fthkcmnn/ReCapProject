using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User entity);

        IResult AddRange(IEnumerable<User> users);

        IResult Update(User entity);

        IResult Delete(User entity);

        IDataResult<IEnumerable<User>> GetAll();

        Task<IDataResult<IEnumerable<User>>> GetAllAsync();
        IDataResult<User> GetUserLogin(string email, string password);
        Task<IDataResult<User>> GetByIdAsync(int id);
        IDataResult<User> GetById(int id);

    }
}
