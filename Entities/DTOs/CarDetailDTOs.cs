using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;
namespace Entities.DTOs
{
    public class CarDetailDTOs : IDtos
    {
        public int CarID { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal? Mileage { get; set; }
        public string? Transmission { get; set; }
        public decimal PerHourRate { get; set; }
        public decimal PerDayRate { get; set; }
        public decimal PerWeekRate { get; set; }
        public decimal PerMounthRate { get; set; }
        public decimal? Surcharge { get; set; }
        public string? Seats { get; set; }
        public string? Luggage { get; set; }
        public string? Fuel { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }
}
