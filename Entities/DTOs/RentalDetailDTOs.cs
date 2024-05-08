using Entities.Concrete;

namespace Entities.DTOs
{
    public class RentalDetailDTOs
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string CarBrandName { get; set; }
        public string CarModelName { get; set; }
        public string Price { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
