namespace Test.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Araba")]
    public partial class Araba
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Araba()
        {
            Satis = new HashSet<Satis>();
        }

        public int arabaID { get; set; }

        public int? markaID { get; set; }

        public int? modelID { get; set; }

        public int? arabaResimID { get; set; }

        public int? olusturanID { get; set; }

        public int? renkID { get; set; }

        public int? kapiSayisi { get; set; }

        public int? bagajGenislik { get; set; }

        public int? koltukSayisi { get; set; }

        [StringLength(500)]
        public string aciklama { get; set; }

        [Column(TypeName = "money")]
        public decimal? gunlukUcret { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? kayitTarih { get; set; }

        public virtual ArabaResim ArabaResim { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Marka Marka { get; set; }

        public virtual Model Model { get; set; }

        public virtual Renk Renk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satis> Satis { get; set; }
    }
}
