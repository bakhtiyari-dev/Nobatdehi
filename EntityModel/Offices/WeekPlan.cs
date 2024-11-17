using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Offices
{
    [Table("WeekPlans", Schema = "OPtion")]
    public class WeekPlan
    {
        public int Id { get; set; }
        public required TimeOnly SaterdayFirstHour { get; set; }
        public required TimeOnly SaterdayLasttHour { get; set; }

        public required TimeOnly SundayFirstHour { get; set; }
        public required TimeOnly SundayLasttHour { get; set; }

        public required TimeOnly MondayFirstHour { get; set; }
        public required TimeOnly MondayLasttHour { get; set; }

        public required TimeOnly tuesdayFirstHour { get; set; }
        public required TimeOnly tuesdayLasttHour { get; set; }

        public required TimeOnly wednesdayFirstHour { get; set; }
        public required TimeOnly wednesdayLasttHour { get; set; }

        public required TimeOnly thursdayFirstHour { get; set; }
        public required TimeOnly thursdayLasttHour { get; set; }

        public required TimeOnly fridayFirstHour { get; set; }
        public required TimeOnly fridayLasttHour { get; set; }

        //Relations

        public int OfficePlanOptionId { get; set; }
        public OfficePlanOption OfficePlanOption { get; set; }
    }
}
