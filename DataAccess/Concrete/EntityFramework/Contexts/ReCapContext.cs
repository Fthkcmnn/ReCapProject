using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public partial class ReCarContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=DEVELOPERKIT;initial catalog=ReCarDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));

        }
    }

    public virtual DbSet<Brand> Brand { get; set; }
    public virtual DbSet<Car> Car { get; set; }
    public virtual DbSet<CarImage> CarImage { get; set; }
    public virtual DbSet<Color> Color { get; set; }
    public virtual DbSet<Customer> Customer { get; set; }
    public virtual DbSet<Model> Model { get; set; }
    public virtual DbSet<Package> Package { get; set; }
    public virtual DbSet<Rental> Rental { get; set; }
    public virtual DbSet<RentalType> RentalType { get; set; }
    public virtual DbSet<Transmission> Transmission { get; set; }
    public virtual DbSet<User> User { get; set; }


}
