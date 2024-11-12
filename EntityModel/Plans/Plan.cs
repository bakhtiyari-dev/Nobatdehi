using EntityModel.Offices;
using EntityModel.Turns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Plans
{
    [Table("Plans", Schema = "Plan")]
    public class Plan
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public bool Status { get; set; }

        //Relations

        public List<Plan> dependentPlans { get; set; } = new List<Plan>();
        public List<Plan> headPlans { get; set; } = new List<Plan>();

        public List<Turn> Turns { get; set; } = new List<Turn>();
        public List<OfficePlanOption> OfficePlanOptions { get; set; } = new List<OfficePlanOption>();
        public List<DesabledTurn> DesabledTurns { get; set; } = new List<DesabledTurn>();
    }
}
