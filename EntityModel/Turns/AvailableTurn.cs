using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Turns
{
    public class AvailableTurn
    {
        public int Id { get; set; }
        public DateOnly AvailableTurnDate { get; set; }
        public TimeOnly AvailableTurnTime { get; set; }

        public int TurnPoolId { get; set; }
    }
}
