using CrudOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperation.Data
{
    public class AddDbContext(DbContextOptions<AddDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
