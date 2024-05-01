using Business.Abstract;
using Business.Constant;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class FuelManager : IFuelService
    {
        IFuelDal _fuelDal;

        public FuelManager(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }

        public IResult Add(Fuel fuel)
        {
            _fuelDal.Add(fuel);
            return new SuccessResult(Messages.FuelAdded);
        }

        public IResult Delete(Fuel fuel)
        {
            _fuelDal.Delete(fuel);
            return new SuccessResult(Messages.FuelDeleted);
        }

        public IDataResult<IEnumerable<Fuel>> GetAll()
        {
            var fuels = _fuelDal.GetAll();
            return new SuccessDataResult<IEnumerable<Fuel>>(fuels, Messages.FuelsListed);
        }

        public IDataResult<Fuel> GetById(int id)
        {
            var fuel = _fuelDal.Get(f => f.FuelID == id);
            if (fuel != null)
            {
                return new SuccessDataResult<Fuel>(fuel, Messages.FuelFound);
            }
            return new ErrorDataResult<Fuel>(Messages.FuelNotFound);
        }

        public IResult Update(Fuel fuel)
        {
            _fuelDal.Update(fuel);
            return new SuccessResult(Messages.FuelUpdated);
        }
    }
}
