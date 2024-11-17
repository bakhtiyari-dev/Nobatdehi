using PresentationLayer.Validations;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.DTO
{
    public class PlanDto
    {
        [MaxLength(100)]
        public required string Name { get; set; }
    }

    public class PlanOptionDto
    {
        [Required]
        public DateOnly FromDate { get; set; }
        [Required]
        public DateOnly ToDate { get; set; }
        [CitizenCodeType]
        public required string CitizenIdType { get; set; }
        [Required]
        public bool GeneralCreationFlag { get; set; }
        [Range(1, 60)]
        public int TurnTimeGap { get; set; }
    }

    public class uPlanDto
    {
        [MaxLength(100)]
        public string? Name { get; set; }
    }

    public class uPlanOptionDto
    {
        public DateOnly? FromDate { get; set; }
        public DateOnly? ToDate { get; set; }
        [CitizenCodeType]
        public string? CitizenIdType { get; set; }
        public bool? GeneralCreationFlag { get; set; }
        [Range(1, 60)]
        public int? TurnTimeGap { get; set; }
    }
}
