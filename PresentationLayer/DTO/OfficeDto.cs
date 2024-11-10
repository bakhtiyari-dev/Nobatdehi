using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.DTO
{
    public class OfficeDto
    {
        public string City { get; set; }
        [MaxLength(13)]
        [MinLength(10)]
        public string PhoneNumber { get; set; }
    }
}
