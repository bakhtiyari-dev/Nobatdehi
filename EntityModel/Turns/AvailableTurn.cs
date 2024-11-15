using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Turns
{
    [Table("AvailableTurns", Schema = "Turn")]
    public class AvailableTurn
    {
        public int Id { get; set; }
        public DateOnly AvailableTurnDate { get; set; }
        public TimeOnly AvailableTurnTime { get; set; }

        //Relations

        public int TurnPoolId { get; set; }
        public TurnPool TurnPool { get; set; }

    }
}
