namespace Entities.Concrete
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User:IEntity
    {
        public User()
        {
            Rentals = new HashSet<Rental>();
        }

        public int userId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string passwordSalt { get; set; }

        public string passwordHash { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
