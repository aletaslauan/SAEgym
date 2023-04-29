using Microsoft.EntityFrameworkCore;
using SAEgym.Models;

namespace SAEgym.App_Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        { }

        public DataContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
    }
}