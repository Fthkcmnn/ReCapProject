using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities.DTOs
{
    public class CarDetailEditDTO : IDtos
    {
        public int CarID { get; set; }
        public int brandID { get; set; }
        public int modelID { get; set; }
        public int colorID { get; set; }
        public int transmissionID { get; set; }
        public int fuelID { get; set; }
        public string Description { get; set; }
        public decimal? Mileage { get; set; }
        public int ModelYear { get; set; }
        public decimal PerHourRate { get; set; }
        public decimal PerDayRate { get; set; }
        public decimal PerWeekRate { get; set; }
        public decimal PerMounthRate { get; set; }
        public decimal? Surcharge { get; set; }
        public string? Seats { get; set; }
        public string Luggage { get; set; }
        public string? ImagePath { get; set; }

        public List<Brand>? Brand { get; set; }
        public List<Model>? Model { get; set; }
        public List<Color>? Color { get; set; }
        public List<Transmission>? Transmision { get; set; }
        public List<Fuel>? Fuel { get; set; }

    }
}
