namespace Entities.Concrete
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CarImage:IEntity
    {
        public int CarImageID { get; set; }

        public int? CarID { get; set; }

        public string ImagePath { get; set; }

        public DateTime? Date { get; set; }

        public virtual Car Car { get; set; }
    }
}
