using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasRequired<Client>(b => b.Client)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.Id);

            modelBuilder.Entity<Booking>()
                .HasRequired<Employee>(b => b.Employee)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.Id);

            modelBuilder.Entity<Booking>()
                .HasRequired<Service>(b => b.Service)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
