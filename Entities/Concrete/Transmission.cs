namespace Entities.Concrete
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Transmission:IEntity
    {
        public Transmission()
        {
            Cars = new HashSet<Car>();
        }
        public int TransmissionID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
