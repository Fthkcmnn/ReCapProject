using Business.Abstract;
using Business.Constant;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult AddRange(IEnumerable<User> users)
        {
            _userDal.AddRange(users);
            return new SuccessResult(Messages.UsersAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<IEnumerable<User>> GetAll()
        {
            var result = _userDal.GetAll(u => u.isDeleted == false);
            return new SuccessDataResult<IEnumerable<User>>(result);
        }

        public async Task<IDataResult<IEnumerable<User>>> GetAllAsync()
        {
            return new SuccessDataResult<IEnumerable<User>>(await _userDal.GetAllAsync(u => u.isDeleted == false));
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.UserId == id && u.isDeleted == false);
            if (result is null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(result);
        }

        public async Task<IDataResult<User>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<User>(await _userDal.GetAsync(u => u.UserId == id && u.isDeleted == false));
        }

        public IDataResult<User> GetUserLogin(string email, string password)
        {
            var result = _userDal.Get(u => u.Email.ToLower() == email.ToLower() && u.PasswordSalt.ToLower() == password.ToLower() && u.isDeleted == false);
            if (result.UserId == 0)
            {
                return new ErrorDataResult<User>(result);
            }
            return new SuccessDataResult<User>(result);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
