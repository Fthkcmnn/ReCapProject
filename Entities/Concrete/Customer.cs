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

        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
