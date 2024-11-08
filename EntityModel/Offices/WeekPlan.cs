using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Offices
{
    [Table("WeekPlans", Schema = "OPtion")]
    public class WeekPlan
    {
        public int Id { get; set; }
        public TimeOnly FromHour { get; set; }
        public TimeOnly ToHour { get; set; }
        public byte Day { get; set; }

        //Relations
        public OfficePlanOption OfficePlanOption { get; set; }
        
    }
}
