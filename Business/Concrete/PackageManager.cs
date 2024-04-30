using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PackageManager : IPackageService
    {
        private readonly IPackageDal _packageDal;

        public PackageManager(IPackageDal packageDal)
        {
            _packageDal = packageDal;
        }

        public IResult Add(Package entity)
        {
            _packageDal.Add(entity);
            return new SuccessResult("Package has been successfully added.");
        }

        public IResult Delete(Package entity)
        {
            _packageDal.Delete(entity);
            return new SuccessResult("Package has been successfully deleted.");
        }

        public IDataResult<IEnumerable<Package>> GetAll()
        {
            var packages = _packageDal.GetAll();
            return new SuccessDataResult<IEnumerable<Package>>(packages);
        }

        public IDataResult<Package> GetPackageById(int id)
        {
            var package = _packageDal.Get(p => p.packageID == id);
            if (package != null)
            {
                return new SuccessDataResult<Package>(package);
            }
            return new ErrorDataResult<Package>("Package not found.");
        }

        public IResult Update(Package entity)
        {
            _packageDal.Update(entity);
            return new SuccessResult("Package has been successfully updated.");
        }
    }
}
