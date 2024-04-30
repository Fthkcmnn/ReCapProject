using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPackageService
    {
        // Entity operations
        IResult Add(Package entity);
        IResult Update(Package entity);
        IResult Delete(Package entity);
        IDataResult<Package> GetPackageById(int id);
        IDataResult<IEnumerable<Package>> GetAll();

    }
}
