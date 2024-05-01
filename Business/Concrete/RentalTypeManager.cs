using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalTypeManager : IRentalTypeService
    {
        private readonly IRentalTypeDal _rentalTypeDal;

        public RentalTypeManager(IRentalTypeDal rentalTypeDal)
        {
            _rentalTypeDal = rentalTypeDal;
        }

        public IResult Add(RentalType entity)
        {
            _rentalTypeDal.Add(entity);
            return new SuccessResult("Rental type has been successfully added.");
        }

        public IResult Delete(RentalType entity)
        {
            _rentalTypeDal.Delete(entity);
            return new SuccessResult("Rental type has been successfully deleted.");
        }

        public IDataResult<IEnumerable<RentalType>> GetAll()
        {
            var rentalTypes = _rentalTypeDal.GetAll();
            return new SuccessDataResult<IEnumerable<RentalType>>(rentalTypes);
        }

        public IDataResult<RentalType> GetRentalTypeById(int id)
        {
            var rentalType = _rentalTypeDal.Get(rt => rt.RentalTypeID == id);
            if (rentalType != null)
            {
                return new SuccessDataResult<RentalType>(rentalType);
            }
            return new ErrorDataResult<RentalType>("Rental type not found.");
        }

        public IResult Update(RentalType entity)
        {
            _rentalTypeDal.Update(entity);
            return new SuccessResult("Rental type has been successfully updated.");
        }
    }
}
