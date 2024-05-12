namespace Test.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Satis
    {
        public int satisID { get; set; }

        public int? arabaID { get; set; }

        public int? musteriID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? kiralamaTarih { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? iadeTarih { get; set; }

        [Column(TypeName = "money")]
        public decimal? ucret { get; set; }

        [StringLength(500)]
        public string aciklama { get; set; }

        public virtual Araba Araba { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
