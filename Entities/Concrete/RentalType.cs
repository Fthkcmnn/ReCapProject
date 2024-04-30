
namespace Entities.Concrete
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class RentalType:IEntity
    {
        public RentalType()
        {
            Packages = new HashSet<Package>();
        }

        public int rentalTypeID { get; set; }

        public string name { get; set; }

        public virtual ICollection<Package> Packages { get; set; }
    }
}
