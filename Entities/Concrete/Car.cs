using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public Car()
        {
            CarImage = new HashSet<CarImage>();
            Package = new HashSet<Package>();
        }
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int TransmissionId { get; set; }
        public int ColorId { get; set; }
        public int FuelId { get; set; }
        public int ModelYear { get; set; }
        public decimal? Milage { get; set; }
        public string? Seats { get; set; }
        public string? Luggage { get; set; }
        public string? Description { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Color Color { get; set; }

        public virtual Fuel Fuel { get; set; }

        public virtual Model Model { get; set; }

        public virtual Transmission Transmission { get; set; }
        public virtual ICollection<CarImage> CarImage { get; set; }

        public virtual ICollection<Package> Package { get; set; }

    }

}
