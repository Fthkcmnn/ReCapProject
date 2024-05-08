using Business.Abstract;
using Business.Constant;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<IEnumerable<Customer>> GetAll()
        {
            var result = _customerDal.GetAll(c => c.isDeleted == false);
            return new SuccessDataResult<IEnumerable<Customer>>(result);
        }

        public async Task<IDataResult<IEnumerable<Customer>>> GetAllAsync()
        {
            var result = await _customerDal.GetAllAsync(c => c.isDeleted == false);
            return new SuccessDataResult<IEnumerable<Customer>>(result);
        }

        public IDataResult<Customer> GetCustomerById(int id)
        {
            var result = _customerDal.Get(c => c.CustomerID == id && c.isDeleted == false);
            return new SuccessDataResult<Customer>(result);
        }

        public IDataResult<Customer> GetCustomerLogin(string email, string password)
        {
            var result = _customerDal.Get(c => c.Email.ToLower() == email.ToLower() && c.Password.ToLower() == password.ToLower() && c.isDeleted == false);
            if (result.CustomerID == 0 )
            {
                return new ErrorDataResult<Customer>(result);
            }
            return new SuccessDataResult<Customer>(result);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
