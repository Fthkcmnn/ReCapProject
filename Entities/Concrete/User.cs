namespace Entities.Concrete
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User : IEntity
    {
        public User()
        {
            Rentals = new HashSet<Rental>();
        }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string rol { get; set; }

        public string PasswordSalt { get; set; }

        public string PasswordHash { get; set; }

        public bool isDeleted { get; set; } 

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
