using System.Diagnostics;
using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation.Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private ICarDal? _carDal;

    /// <summary>
    ///     Represents a manager class for handling car-related operations.
    /// </summary>
    public CarManager(ICarDal carRepository)
    {
        _carDal = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
    }

    [ValidationAspect(typeof(CarValidator))]
    public IResult Add(Car car)
    {
        try
        {
            _carDal?.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }

    public IResult Delete(Car car)
    {
        _carDal?.Delete(car);
        return new SuccessResult(Messages.CarDeleted);
    }

    public IResult Update(Car car)
    {
        _carDal?.Update(car);
        return new SuccessResult(Messages.Updated);
    }

    public IDataResult<Car> GetCarById(int id)
    {
        var result = _carDal?.Get(car => car.CarId == id);
        if (result is null)
        {
            return new ErrorDataResult<Car>(result, Messages.Null);
        }
        return new SuccessDataResult<Car>(result, Messages.CarsListed);
    }

    public IDataResult<IEnumerable<CarDetailDTOs>> GetCarDetailsByDescription(string description)
    {
        try
        {
            var result = _carDal.GetCarDitails(cd => cd.Description.ToUpper() == description.ToUpper());
            return new SuccessDataResult<IEnumerable<CarDetailDTOs>>(result);
        }
        catch (Exception ex)
        {
            // Hata durumunda daha kapsamlý bir hata yönetimi saðlayabilirsiniz.
            // Örneðin, loglama yapabilirsiniz.
            // Ayrýca, Exception'ý sadece hata iletisiyle deðil, tamamýyla dönmeniz daha iyidir.
            return new ErrorDataResult<IEnumerable<CarDetailDTOs>>(
                message: "Bir hata oluþtu. Detaylar için loglarý kontrol edin.");
        }
    }

    public IDataResult<IEnumerable<CarDetailDTOs>> GetCarDetails()
    {
        try
        {
            var result = _carDal.GetCarDitails();
            return new SuccessDataResult<IEnumerable<CarDetailDTOs>>(result);
        }
        catch (Exception ex)
        {
            return new ErrorDataResult<IEnumerable<CarDetailDTOs>>(
                message: Messages.ExMessage);
        }
    }

    public IDataResult<IEnumerable<Car>> GetAll()
    {
        var resutl = _carDal?.GetAll();
        return new SuccessDataResult<IEnumerable<Car>>(resutl, Messages.CarsListed);
    }

    public async Task<IDataResult<IEnumerable<Car>>> GetAllAsync()
    {
        try
        {
            var result = await _carDal.GetAllAsync();
            return new SuccessDataResult<IEnumerable<Car>>(result);
        }
        catch (Exception ex)
        {
            return new ErrorDataResult<IEnumerable<Car>>(
                message: Messages.ExMessage);
        }
    }


}