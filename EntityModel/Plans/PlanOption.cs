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
        public string CitizenIdType { get; set; }
        public bool GeneralCreationFlag { get; set; }
        public int TurnTimeGap { get; set; }

        //Relations

        public Plan Plan { get; set; }
        
    }
}
