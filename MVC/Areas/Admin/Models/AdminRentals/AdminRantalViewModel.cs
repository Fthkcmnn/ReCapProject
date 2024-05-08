using Entities.DTOs;

namespace MVC.Areas.Admin.Models.AdminRentals
{
    public class AdminRantalViewModel
    {
        public IEnumerable<RentalDetailDTOs> Rental { get; set; }
    }
}
