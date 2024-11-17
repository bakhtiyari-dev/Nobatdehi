using EntityModel.Offices;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Turns
{
    [Table("TurnPools", Schema = "Turn")]
    public class TurnPool
    {
        public int Id { get; set; }

        //Relations

        public int OfficePlanOptionId { get; set; }
        public OfficePlanOption OfficePlanOption { get; set; }
        public List<AvailableTurn> AvailableTurns { get; set; } = new List<AvailableTurn>();
    }
}
