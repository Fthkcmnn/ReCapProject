using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult("Color has been successfully added.");
        }

        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult("Color has been successfully deleted.");
        }

       public async Task<IDataResult<IEnumerable<Color>>> GetAllAsync()
        {
            var colors = await _colorDal.GetAllAsync();
            return new SuccessDataResult<IEnumerable<Color>>(colors);
        }

        public async Task<IEnumerable<Color>> GetColorByName(string name)
        {
            return await _colorDal.GetAllAsync(color => color.Name.ToLower() == name.ToLower());
        }


        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult("Color has been successfully updated.");
        }
    }
}
