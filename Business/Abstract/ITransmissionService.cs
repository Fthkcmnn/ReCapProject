using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITransmissionService
    {
        // Entity operations
        IResult Add(Transmission entity);
        IResult Update(Transmission entity);
        IResult Delete(Transmission entity);
        IDataResult<Transmission> GetTransmissionById(int id);
        IDataResult<IEnumerable<Transmission>> GetAll();
        
    }
}
