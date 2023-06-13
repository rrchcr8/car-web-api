using Application.DTO;
using Domain.Entities;

namespace Application.Common.Interface;

public interface ICarService
{
    Task<Car> CreateCarAsync(CarRequest carRequest);
    Task<IEnumerable<Car>> GetAllCarsAsync();
}