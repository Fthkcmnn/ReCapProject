namespace Entities.Concrete
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Color:IEntity
    {
        public Color()
        {
            Cars = new HashSet<Car>();
        }

        public int colorId { get; set; }

        public string name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
