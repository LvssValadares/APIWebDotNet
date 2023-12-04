using API_WEB_CRUD.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_WEB_CRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
