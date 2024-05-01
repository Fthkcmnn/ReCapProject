using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace MVC.Models.CarModels
{
    public class CarIndexViewModel
    {

        public List<CarDetailDTOs>? CarDetails { get; set; }
    }
}
