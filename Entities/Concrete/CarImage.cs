namespace Entities.Concrete
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CarImage:IEntity
    {
        public int carImageID { get; set; }

        public int? carID { get; set; }

        public string imagePath { get; set; }

        public DateTime? date { get; set; }

        public virtual Car Car { get; set; }
    }
}
