using PresentationLayer.Validations;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.DTO
{
    public class TurnDto
    {
        [PhoneNumber]
        public string CitizenPhoneNumber { get; set; }
        public string UserId { get; set; }
        [CitizenCode]
        public int CitizenId { get; set; }
        public int PlanId { get; set; }
        public int OfficeId { get; set; }
    }
}
