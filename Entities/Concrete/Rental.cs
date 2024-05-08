namespace Entities.Concrete
{
    using Core.Entities;
    using Entities.Concrete;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Rental:IEntity
    {
        public int RentalId { get; set; }

        public int? UserID { get; set; }

        public int? CustomerID { get; set; }

        public int? PackageID { get; set; }

        public decimal? Price { get; set; }

        public DateTime? RentDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Package Package { get; set; }

        public virtual User User { get; set; }
    }
}
