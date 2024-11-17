using PresentationLayer.Validations;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.DTO
{
    public class TurnDto
    {
        [PhoneNumber]
        public required string CitizenPhoneNumber { get; set; }
        public required string UserId { get; set; }
        [Range(1,100000)]
        public required int CitizenId { get; set; }
        [Range(1, 100000)]
        public required int PlanId { get; set; }
        [Range(1, 100000)]
        public required int OfficeId { get; set; }
    }
}
