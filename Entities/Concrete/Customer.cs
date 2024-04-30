namespace Entities.Concrete
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Customer:IEntity  
    {
        public Customer()
        {
            Rentals = new HashSet<Rental>();
        }

        public int customerID { get; set; }

        [StringLength(150)]
        public string firstName { get; set; }

        [StringLength(150)]
        public string lastName { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(150)]
        public string adress { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
