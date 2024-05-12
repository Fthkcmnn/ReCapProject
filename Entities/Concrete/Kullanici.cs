namespace Entities.Concrete
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Kullanici")]
    public partial class Kullanici : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            Araba = new HashSet<Araba>();
            Kullanici1 = new HashSet<Kullanici>();
            Kullanici11 = new HashSet<Kullanici>();
        }

        public int kullaniciID { get; set; }

        public int? yetkiID { get; set; }
        
        public int? olusturanID { get; set; }

        public int? sonDuzenleyenID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        [StringLength(50)]
        public string soyad { get; set; }

        [StringLength(50)]
        public string kullaniciAd { get; set; }

        [StringLength(50)]
        public string sifre { get; set; }

        [StringLength(100)]
        public string ePosta { get; set; }

        [StringLength(50)]
        public string telefon { get; set; }

        public bool? silindiMi { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? olusturmaTarih { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dogumTarih { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? sonDuzenlemeTarih { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Araba> Araba { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici> Kullanici1 { get; set; }

        public virtual Kullanici Kullanici2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici> Kullanici11 { get; set; }

        public virtual Kullanici Kullanici3 { get; set; }

        public virtual Yetki Yetki { get; set; }
    }
}
