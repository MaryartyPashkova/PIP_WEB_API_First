using Microsoft.EntityFrameworkCore;

namespace SampleWebApplication.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext>  options) : base(options) { 

        }
        public DbSet<Students> Students { get; set; } = null;
    }
}
