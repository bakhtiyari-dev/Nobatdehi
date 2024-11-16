namespace PresentationLayer.DTO
{
    public class TurnFilterDto
    {
        public class TurnFilterByDate
        {
            public DateOnly FromDate { get; set; }
            public TimeOnly FromHour { get; set; }
            public DateOnly ToDate { get; set; }
            public TimeOnly ToHour { get; set; }
        }

        public class TurnFilterByOffice
        {
            public int OfficeId { get; set; }
        }

        public class TurnFilterByPlan
        {
            public int PlanId { get; set; }
        }
        
        public class TurnFilterByCitizen
        {
            public int CitizenId { get; set; }
        }
    }
}
