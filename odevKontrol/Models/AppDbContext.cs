using Microsoft.EntityFrameworkCore;


namespace odevKontrol.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }  

        public DbSet<Todo> Todos { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
