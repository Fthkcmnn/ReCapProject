using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Test.Context
{
    public partial class ArabaContext : DbContext
    {
        public ArabaContext()
            : base("name=ArabaContext")
        {
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Araba>()
                .Property(e => e.gunlukUcret)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Araba)
                .WithOptional(e => e.Kullanici)
                .HasForeignKey(e => e.olusturanID);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Kullanici1)
                .WithOptional(e => e.Kullanici2)
                .HasForeignKey(e => e.olusturanID);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Kullanici11)
                .WithOptional(e => e.Kullanici3)
                .HasForeignKey(e => e.sonDuzenleyenID);

            modelBuilder.Entity<Satis>()
                .Property(e => e.ucret)
                .HasPrecision(19, 4);
        }
    }
}
