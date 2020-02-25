using DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB
{
    public class CarAccidentContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Accident> Accidents { get; set; }

        public CarAccidentContext()
        {

        }

        public CarAccidentContext(DbContextOptions<CarAccidentContext> dbContext): base(dbContext)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(p => p.Id);
                u.Property(p => p.Id).ValueGeneratedOnAdd();

                u.Property(p => p.Email).HasMaxLength(100);

                u.Property(p => p.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Accident>(a =>
            {
                a.HasKey(k => k.Id);
                a.Property(p => p.Id).ValueGeneratedOnAdd();

                a.Property(p => p.Address).HasMaxLength(1000);
                a.Property(p => p.GpsCoordinates).HasMaxLength(50);

                a.Property(p => p.CreatingTime).IsRequired();

                a.HasOne(p => p.User).WithMany(u => u.Accidents).HasForeignKey(p => p.UserId);
            });
        }
    }
}
