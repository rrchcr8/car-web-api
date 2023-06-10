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

    public async Task<Car> CreateCarAsync(CarRequest carRequest)
    {
        var car = carRequest.Adapt<Car>();
        await _carRepository.Insert(car);
        return car;
    }
}