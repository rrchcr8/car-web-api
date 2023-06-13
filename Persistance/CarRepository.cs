using Domain;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            _appDbContext = applicationDbContext;

        }
        //private static readonly List<Car> _cars = new List<Car>();

        

        public async Task Insert(Car car) 
        {
             await _appDbContext.Cars.AddAsync(car);
            _appDbContext.SaveChanges();
         //   _cars.Add(car);    
        }

        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            return await _appDbContext.Cars.ToListAsync();
        }
    }
}
