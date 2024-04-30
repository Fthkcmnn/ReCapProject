namespace Entities.Concrete
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Model:IEntity
    {
        public Model()
        {
            Cars = new HashSet<Car>();
        }

        public int modelID { get; set; }

        public int? brandID { get; set; }

        public int? name { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
