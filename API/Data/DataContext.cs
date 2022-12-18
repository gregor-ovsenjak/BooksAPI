using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        // name of the table 
        public DbSet<Book> Books { get; set; }

    }
}
