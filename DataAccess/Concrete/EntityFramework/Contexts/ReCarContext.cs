using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class ReCarContext : DbContext
{
    //public ReCarContext(DbContextOptions<ReCarContext> options)
    //    : base(options)
    //{
    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=DEVELOPERKIT;initial catalog=ReCarDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Car>()
                .Property(e => e.Mileage)
                .HasPrecision(10, 3);

        modelBuilder.Entity<Package>()
            .Property(e => e.Price)
            .HasPrecision(19, 4);

        modelBuilder.Entity<Package>()
            .Property(e => e.Surcharge)
            .HasPrecision(19, 4);

        modelBuilder.Entity<Rental>()
            .Property(e => e.Price)
            .HasPrecision(18, 0);

        modelBuilder.Entity<User>()
            .Property(e => e.PasswordSalt)
            .IsUnicode(false);

        modelBuilder.Entity<User>()
            .Property(e => e.PasswordHash)
            .IsUnicode(false);

    }

    public virtual DbSet<Brand> Brand { get; set; }
    public virtual DbSet<Car> Car { get; set; }
    public virtual DbSet<CarImage> CarImage { get; set; }
    public virtual DbSet<Color> Color { get; set; }
    public virtual DbSet<Customer> Customer { get; set; }
    public virtual DbSet<Fuel> Fuel { get; set; }
    public virtual DbSet<Model> Model { get; set; }
    public virtual DbSet<Package> Package { get; set; }
    public virtual DbSet<Rental> Rental { get; set; }
    public virtual DbSet<RentalType> RentalType { get; set; }
    public virtual DbSet<Transmission> Transmission { get; set; }
    public virtual DbSet<User> User { get; set; }


}
