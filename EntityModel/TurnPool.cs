using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class TurnPool
    {
        
        public int Id { get; set; }
        public int OfficePlanOptionId { get; set; }

        public List<AvailableTurn> AvailableTurns { get; set; }
    }
}
