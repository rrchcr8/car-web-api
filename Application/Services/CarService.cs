using Application.DTO;
using Domain.Entities;
using Domain.Repositories;
using Mapster;

namespace Application.Common.Interface;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<Car?> CreateCarAsync(CarRequest carRequest)
    {
        var car = carRequest.Adapt<Car>();
        //- Logic to avoid insert duplicate records.
        List<Car> cars = (await _carRepository.GetCarsAsync()).ToList();
        if (!cars.Any(c => c.Model.Equals(car.Model) 
        && c.Name.Equals(car.Name) 
        && c.Year.Equals(car.Year)))
        {
            await _carRepository.Insert(car);
            return car;
        }
        else 
        {
            return null;
        }
        
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        return await _carRepository.GetCarsAsync();
    }
}