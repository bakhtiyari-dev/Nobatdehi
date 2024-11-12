using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Plans
{
    [Table("PlanOptions", Schema = "Option")]
    public class PlanOption
    {
        [Key]
        public int Id { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        [MaxLength(12)]
        [MinLength(6)]
        public string CitizenIdType { get; set; }
        public bool GeneralCreationFlag { get; set; }
        [Range(1, 60)]
        public int TurnTimeGap { get; set; }

        //Relations

        public Plan Plan { get; set; }
        
    }
}
