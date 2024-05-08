using Business.Abstract;
using Business.Constant;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Remove(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public async Task<IDataResult<IEnumerable<RentalDetailDTOs>>> GetRentalDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IEnumerable<RentalDetailDTOs>>> GetRentalDetailsByCustomerName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IEnumerable<RentalDetailDTOs>>> GetRentalDetailsByCarName(string carName)
        {
           throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<RentalDetailDTOs>> GetRentalDetails()
        {
            var result = _rentalDal.GetRentalDetails();
            return new SuccessDataResult<IEnumerable<RentalDetailDTOs>>(result);
        }

        public IDataResult<IEnumerable<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<IEnumerable<Rental>>(result);
        }
    }
}
