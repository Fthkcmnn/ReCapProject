using Core.Entities;
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
        public string? Seats { get; set; }
        public string? Luggage { get; set; }
        public string? Fuel { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }
}
