using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Areas.Admin.Models.AdminCarModels
{
    public class AdminCarEditViewModel
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

        public SelectListItem? Brand { get; set; }
        public SelectListItem? Model { get; set; }
        public SelectListItem? Color { get; set; }
        public SelectListItem? Transmision { get; set; }
        public SelectListItem? Fuel { get; set; }

    }
}
