using FitnessLub.BL.Model;
using Microsoft.EntityFrameworkCore;


namespace FitnessLub.BL.Controller
{
    public class FitnessContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=fitnesslubdb;Trusted_Connection=True;");
        }
    }
}
