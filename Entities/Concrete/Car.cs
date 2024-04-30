using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int TransmissionKindId { get; set; }
        public int ColorId { get; set; }
        public int FuelKindId { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public float Milage { get; set; }
        public string Seats { get; set; }
        public string Luggage { get; set; }
        public string Description { get; set; }
    }

}
