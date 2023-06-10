using Domain;
using Domain.Entities;
using Domain.Repositories;
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

        public async Task Insert(Car car) 
        {
            _appDbContext.Cars.Add(car);
            _appDbContext.SaveChanges();
        } 

    }
}
