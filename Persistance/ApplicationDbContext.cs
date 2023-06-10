using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance;

public class ApplicationDbContext:DbContext
{
    public DbSet<Car> Cars { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
    }
    public override int SaveChanges()
    {

        return base.SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //  optionsBuilder.UseSqlite("basededatos.db");
    }
}
