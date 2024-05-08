using Entities.DTOs;

namespace MVC.Models.CarModels
{
	public class CarDetayViewModel
	{
		public CarDetailDTOs? CarDetail { get; set; }
		public List<CarDetailDTOs?> CarDetails { get; set; }
	}
}
