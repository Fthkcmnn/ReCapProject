using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult("Brand has been successfully added.");
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult("Brand has been successfully deleted.");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var brands = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(brands);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var brand = _brandDal.Get(b => b.BrandID == id);
            if (brand != null)
            {
                return new SuccessDataResult<Brand>(brand);
            }
            return new ErrorDataResult<Brand>("Brand not found.");
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult("Brand has been successfully updated.");
        }
    }
}
