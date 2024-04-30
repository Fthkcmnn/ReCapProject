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
        public int rentalId { get; set; }

        public int? userID { get; set; }

        public int? carID { get; set; }

        public int? customerID { get; set; }

        public int? packageID { get; set; }

        public decimal? price { get; set; }

        public DateTime? rentDate { get; set; }

        public DateTime? returnDate { get; set; }

        public virtual Car Car { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Package Package { get; set; }

        public virtual User User { get; set; }
    }
}
