using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Offices
{
    public class OfficePlanOption
    {
        public int Id { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }

        public int OfficeId { get; set; }
        public int PlanId { get; set; }
        public int WeekPlanId { get; set; }
        public int TurnPoolId { get; set; }
    }
}
