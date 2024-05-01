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

        public int ModelID { get; set; }

        public int BrandID { get; set; }

        public string Name { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
