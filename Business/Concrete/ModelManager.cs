using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        private readonly IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public IResult Add(Model entity)
        {
            _modelDal.Add(entity);
            return new SuccessResult("Model has been successfully added.");
        }

        public IResult Delete(Model entity)
        {
            _modelDal.Delete(entity);
            return new SuccessResult("Model has been successfully deleted.");
        }

        public IDataResult<Model> GetById(int id)
        {
            var model = _modelDal.Get(m => m.modelID == id);
            if (model != null)
            {
                return new SuccessDataResult<Model>(model);
            }
            return new ErrorDataResult<Model>("Model not found.");
        }

        public IDataResult<IEnumerable<Model>> GetAll()
        {
            var models = _modelDal.GetAll();
            return new SuccessDataResult<IEnumerable<Model>>(models);
        }

        public IResult Update(Model entity)
        {
            _modelDal.Update(entity);
            return new SuccessResult("Model has been successfully updated.");
        }
    }
}
