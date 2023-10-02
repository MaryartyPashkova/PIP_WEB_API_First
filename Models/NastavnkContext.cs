using Microsoft.EntityFrameworkCore;

//namespace StudentBase.Models
namespace SampleWebApplication.Models
{
    public class NastavnkContext : DbContext
    {
        public NastavnkContext(DbContextOptions<NastavnkContext> options) : base(options)
        {

        }
        public DbSet<Nastavnik> Nastavnik { get; set; } = null;
    }
}
