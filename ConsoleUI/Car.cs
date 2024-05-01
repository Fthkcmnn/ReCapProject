using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Car:IEntity
    {
        public int? CarId { get; set; }
        public int? BrandId { get; set; }
        public int ModelId { get; set; }
        public int TransmissionId { get; set; }
        public int? ColorId { get; set; }
        public int? FuelId { get; set; }
        public int? ModelYear { get; set; }
        public decimal? Milage { get; set; }
        public string? seats { get; set; }
        public string? Luggage { get; set; }
        public string? Description { get; set; }
    }

}
