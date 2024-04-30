using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IModelService
    {
        IResult Add(Model entity);
        IResult Delete(Model entity);
        IResult Update(Model entity);
        IDataResult<Model> GetById(int id);
        IDataResult<IEnumerable<Model>> GetAll();
    }
}
