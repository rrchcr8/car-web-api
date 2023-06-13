using Application.Common.Interface;
using Application.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        
        [HttpGet("all/")]

        public async Task<IActionResult> GetCars()
        {
            var owners = await _carService.GetAllCarsAsync();

            return Ok(owners);
        }

        [HttpPost("add/")]
        public async Task<IActionResult> CreateCar([FromBody] CarRequest carRequest )
        {
            var car = await _carService.CreateCarAsync(carRequest);           
            return Ok(car);
        }
    }
}
