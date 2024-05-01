using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TransmissionManager : ITransmissionService
    {
        private readonly ITransmissionDal _transmissionDal;

        public TransmissionManager(ITransmissionDal transmissionDal)
        {
            _transmissionDal = transmissionDal;
        }

        public IResult Add(Transmission entity)
        {
            _transmissionDal.Add(entity);
            return new SuccessResult("Transmission has been successfully added.");
        }

        public IResult Delete(Transmission entity)
        {
            _transmissionDal.Delete(entity);
            return new SuccessResult("Transmission has been successfully deleted.");
        }

        public IDataResult<IEnumerable<Transmission>> GetAll()
        {
            var transmissions = _transmissionDal.GetAll();
            return new SuccessDataResult<IEnumerable<Transmission>>(transmissions);
        }

        public IDataResult<Transmission> GetTransmissionById(int id)
        {
            var transmission = _transmissionDal.Get(t => t.TransmissionID == id);
            if (transmission != null)
            {
                return new SuccessDataResult<Transmission>(transmission);
            }
            return new ErrorDataResult<Transmission>("Transmission not found.");
        }

        public IResult Update(Transmission entity)
        {
            _transmissionDal.Update(entity);
            return new SuccessResult("Transmission has been successfully updated.");
        }
    }
}
