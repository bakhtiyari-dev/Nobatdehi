using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Plans
{
    public class PlanOption
    {
        public int Id { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public string CitizenIdType { get; set; }
        public bool GeneralCreationFlag { get; set; }
        public int TurnTimeGap { get; set; }

        public int PlanId { get; set; }
    }
}
