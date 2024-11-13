using Swashbuckle.AspNetCore.Annotations;

namespace PresentationLayer.DTO
{
    public class WeekPlanDto
    {
        [SwaggerParameter(Description = "First hour for Saturday")]
        public required  TimeOnly SaterdayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Saturday")]
        public required  TimeOnly SaterdayLasttHour { get; set; }
                
        [SwaggerParameter(Description = "First hour for Sunday")]
        public required  TimeOnly SundayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Sunday")]
        public required  TimeOnly SundayLasttHour { get; set; }
               
        [SwaggerParameter(Description = "First hour for Monday")]
        public required  TimeOnly MondayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Monday")]
        public required  TimeOnly MondayLasttHour { get; set; }
              
        [SwaggerParameter(Description = "First hour for Tuesday")]
        public required  TimeOnly tuesdayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Tuesday")]
        public required  TimeOnly tuesdayLasttHour { get; set; }
              
        [SwaggerParameter(Description = "First hour for Wednesday")]
        public required  TimeOnly wednesdayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Wednesday")]
        public required  TimeOnly wednesdayLasttHour { get; set; }
               
        [SwaggerParameter(Description = "First hour for Thursday")]
        public required  TimeOnly thursdayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Thursday")]
        public required  TimeOnly thursdayLasttHour { get; set; }
              
        [SwaggerParameter(Description = "First hour for Friday")]
        public required  TimeOnly fridayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Friday")]
        public required  TimeOnly fridayLasttHour { get; set; }
    }

    public class uWeekPlanDto
    {
        [SwaggerParameter(Description = "First hour for Saturday")]
        public TimeOnly? SaterdayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Saturday")]
        public TimeOnly? SaterdayLasttHour { get; set; }

        [SwaggerParameter(Description = "First hour for Sunday")]
        public TimeOnly? SundayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Sunday")]
        public TimeOnly? SundayLasttHour { get; set; }

        [SwaggerParameter(Description = "First hour for Monday")]
        public TimeOnly? MondayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Monday")]
        public TimeOnly? MondayLasttHour { get; set; }

        [SwaggerParameter(Description = "First hour for Tuesday")]
        public TimeOnly? tuesdayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Tuesday")]
        public TimeOnly? tuesdayLasttHour { get; set; }

        [SwaggerParameter(Description = "First hour for Wednesday")]
        public TimeOnly? wednesdayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Wednesday")]
        public TimeOnly? wednesdayLasttHour { get; set; }

        [SwaggerParameter(Description = "First hour for Thursday")]
        public TimeOnly? thursdayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Thursday")]
        public TimeOnly? thursdayLasttHour { get; set; }

        [SwaggerParameter(Description = "First hour for Friday")]
        public TimeOnly? fridayFirstHour { get; set; }
        [SwaggerParameter(Description = "Last hour for Friday")]
        public TimeOnly? fridayLasttHour { get; set; }
    }
}
