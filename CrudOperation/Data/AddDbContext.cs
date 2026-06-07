using CrudOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperation.Data
{
    public class AddDbContext(DbContextOptions<AddDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
