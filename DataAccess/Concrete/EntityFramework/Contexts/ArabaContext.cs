using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entities.Concrete
{
    public partial class ArabaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=FATIH\\SQLEXPRESS;initial catalog=ArabaKiralamaDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));

            }
        }

        public virtual DbSet<Araba> Araba { get; set; }
        public virtual DbSet<ArabaResim> ArabaResim { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Marka> Marka { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Renk> Renk { get; set; }
        public virtual DbSet<Satis> Satis { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Araba>()
         .Property(e => e.gunlukUcret)
         .HasPrecision(19, 4);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Araba)
                .WithOne(e => e.Kullanici)
                .HasForeignKey(e => e.olusturanID);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Kullanici1)
                .WithOne(e => e.Kullanici2)
                .HasForeignKey(e => e.olusturanID);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Kullanici11)
                .WithOne(e => e.Kullanici3)
                .HasForeignKey(e => e.sonDuzenleyenID);

            modelBuilder.Entity<Satis>()
                .Property(e => e.ucret)
                .HasPrecision(19, 4);
        }
    }
}
