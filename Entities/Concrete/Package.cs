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
            Rental = new HashSet<Rental>();
        }

        public int PackageID { get; set; }

        public decimal? Price { get; set; }

        public int? RentalTypeID { get; set; }

        public int? CarID { get; set; }

        public decimal? Surcharge { get; set; }

        public virtual Car Car { get; set; }

        public virtual RentalType RentalType { get; set; }

        public virtual ICollection<Rental> Rental { get; set; }
    }
}
