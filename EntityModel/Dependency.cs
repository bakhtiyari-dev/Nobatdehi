using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class Dependency
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int OptionPlanId { get; set; }
    }
}
