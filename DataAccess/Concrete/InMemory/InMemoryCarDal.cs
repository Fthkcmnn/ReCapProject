﻿using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear=2015, DailyPrice=150, Description="Audi A3"},
                new Car{CarId=2, BrandId=1, ColorId=2, ModelYear=2016, DailyPrice=200, Description="Audi A4"},
                new Car{CarId=3, BrandId=2, ColorId=3, ModelYear=2017, DailyPrice=250, Description="BMW 3.20"},
                new Car{CarId=4, BrandId=2, ColorId=4, ModelYear=2018, DailyPrice=300, Description="BMW 5.20"},
                new Car{CarId=5, BrandId=3, ColorId=5, ModelYear=2019, DailyPrice=350, Description="Mercedes C180"},
            };
        }

        public void AddRange(IEnumerable<Car> entities)
        {
            throw new NotImplementedException();
        }

        void IEntityRepository<Car>.Add(Car entity) => _cars.Add(entity);
        void IEntityRepository<Car>.Delete(Car car) => _cars.Where(c => c.CarId == car.CarId).ToList().ForEach(c => _cars.Remove(c));
        public void Update(Car car)
        {
            Car? carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            if (carToUpdate != null)
            {
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
            }
        }
        public IEnumerable<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAllAsync(Expression<Func<Car, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
