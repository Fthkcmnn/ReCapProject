using System.Diagnostics;
using DataAccess.Abstract;
using Entities.Concrete;

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

    public void Add(Car car)
    {
        if (car.Description.Length <= 2)
            Console.WriteLine("Araba A��klamas� 2 karakterden uzun olam�");
        else if (car.DailyPrice <= 0)
            Console.WriteLine("Araban�n g�nl�k fiyat� 0'dan b�y�k olmal�");
        else
            try
            {
                _carDal?.Add(car);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw new Exception(exception.Message);
            }
    }

    public void Delete(Car car)
    {
        _carDal?.Delete(car);
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        var test = await _carDal?.GetAllAsync();
        return test;
    }

    public void Update(Car car)
    {
        _carDal?.Update(car);
    }

    public Car GetCarById(int id)
    {
        return _carDal?.Get(car => car.CarId == id) ?? throw new InvalidOperationException
        {
            HelpLink = string.Empty,
            HResult = 0,
            Source = null
        };
    }

    public Car GetCarByDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("A��klama bo� olamaz.", nameof(description));

        Debug.Assert(_carDal != null, nameof(_carDal) + " != null");
        var car = _carDal.Get(car => car.Description == description);

        if (car == null) throw new Exception($"A��klamas� '{description}' olan araba bulunamad�.");

        return car;
    }

    public void AddRange(IEnumerable<Car> entites)
    {
        _carDal.AddRange(entites);
    }
}