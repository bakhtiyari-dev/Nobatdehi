using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Offices
{
    public class WeekPlan
    {
        public int Id { get; set; }
        public TimeOnly FromHour { get; set; }
        public TimeOnly ToHour { get; set; }
        public DayOfWeek MyProperty { get; set; }
        public int OfficeOptionPlanId { get; set; }
    }
}
