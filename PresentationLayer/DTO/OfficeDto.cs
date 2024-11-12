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

    public class opoDto
    {
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        [Required]
        [Range(0, 99999)]
        public int Capacity { get; set; }
    }

    public class uopoDto
    {
        public DateOnly? FromDate { get; set; }
        public DateOnly? ToDate { get; set; }
        [Required]
        [Range(0, 99999)]
        public int? Capacity { get; set; }
    }


}
