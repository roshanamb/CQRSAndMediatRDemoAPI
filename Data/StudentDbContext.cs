using CQRSAndMediatRDemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemoAPI.Data
{
    public class StudentDbContext: DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> option) : base(option) { }

        public DbSet<StudentDetails> Students { get; set; }
    }
}
