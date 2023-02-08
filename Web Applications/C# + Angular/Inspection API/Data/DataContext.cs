using InspectionAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace InspectionAPI.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        public DbSet<Inspection> Inspections { get; set; } = default!;
        public  DbSet<InspectionType> InspectionsType { get; set; } = default!;
        public DbSet<Status> Statuses { get; set; } = default!;
    }
}
