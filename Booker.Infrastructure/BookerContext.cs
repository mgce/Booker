using System.Data.Entity;
using Booker.Core.Domain;

namespace Booker.Infrastructure
{
    public class BookerContext : DbContext
    {
        public BookerContext() : base("BookerContextConnectionString")
        {        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ExternalLogin> Logins { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasRequired(b => b.Client)
                .WithMany(c => c.Bookings);

            //modelBuilder.Entity<Client>()
            //    .HasMany(c => c.Bookings)
            //    .WithOptional();

            modelBuilder.Entity<Booking>()
                .HasRequired(b => b.Employee)
                .WithMany(e => e.Bookings);

            //modelBuilder.Entity<Employee>()
            //  .HasMany(e => e.Bookings)
            //  .WithOptional();

            modelBuilder.Entity<Booking>()
                .HasRequired(b => b.Service)
                .WithMany(s => s.Bookings);

            //modelBuilder.Entity<Service>()
            // .HasMany(s => s.Bookings)
            // .WithOptional();

            base.OnModelCreating(modelBuilder);
        }
    }
}
