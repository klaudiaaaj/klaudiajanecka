using Microsoft.EntityFrameworkCore;
using Sloths.Models;
using System.Reflection;

public class SlothDbContetxt : DbContext
{
    public SlothDbContetxt(DbContextOptions<SlothDbContetxt> context) : base(context)
    {

    }
    public DbSet<Sloth> Sloth { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder
         .ApplyConfigurationsFromAssembly(GetType().Assembly);
}