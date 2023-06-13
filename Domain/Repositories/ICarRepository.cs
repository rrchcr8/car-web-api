using Domain.Entities;

namespace Domain.Repositories;

public interface ICarRepository
{
    Task Insert(Car car);
    public Task<IEnumerable<Car>> GetCarsAsync();
}