namespace Entities.Concrete
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Brand:IEntity
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
            Models = new HashSet<Model>();
        }

        public int BrandID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
