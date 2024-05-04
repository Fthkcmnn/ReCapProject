using Entities.DTOs;

namespace MVC.Areas.Admin.Models.AdminCarModels
{
    public class AdminCarEditViewModel
    {
        IEnumerable<CarDetailDTOs> CarDetailDTOs { get; set; }
    }
}
