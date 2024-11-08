using EntityModel.Offices;
using EntityModel.Turns;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Plans
{
    [Table("Plans", Schema = "Plan")]
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        //Relations

        public List<Plan> dependentPlans { get; set; }
        public List<Turn> Turns { get; set; }
        public List<OfficePlanOption> OfficePlanOptions { get; set; }
        public List<DesabledTurn> DesabledTurns { get; set; }
    }
}
