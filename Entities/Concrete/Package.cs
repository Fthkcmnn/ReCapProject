namespace Entities.Concrete
{
    using Core.Entities;
    using Entities.Concrete;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Package:IEntity
    {
        public Package()
        {
            Rentals = new HashSet<Rental>();
        }

        public int packageID { get; set; }

        public decimal? price { get; set; }

        public int? rentalTypeID { get; set; }

        public int? carID { get; set; }

        public decimal? surcharge { get; set; }

        public virtual Car Car { get; set; }

        public virtual RentalType RentalType { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
