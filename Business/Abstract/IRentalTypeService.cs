using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalTypeService
    {
        // Entity operations
        IResult Add(RentalType entity);
        IResult Update(RentalType entity);
        IResult Delete(RentalType entity);
        IDataResult<RentalType> GetRentalTypeById(int id);
        IDataResult<IEnumerable<RentalType>> GetAll();

    }
}
