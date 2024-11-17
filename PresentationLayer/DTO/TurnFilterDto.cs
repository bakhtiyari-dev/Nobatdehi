namespace PresentationLayer.DTO
{
    public class TurnFilterDto
    {
        public class TurnFilterByDate
        {
            public required DateOnly FromDate { get; set; }
            public required TimeOnly FromHour { get; set; }
            public required DateOnly ToDate { get; set; }
            public required TimeOnly ToHour { get; set; }
        }

        public class TurnFilterByOffice
        {
            public required int OfficeId { get; set; }
        }

        public class TurnFilterByPlan
        {
            public required int PlanId { get; set; }
        }
        
        public class TurnFilterByCitizen
        {
            public required string CitizenId { get; set; }
        }
    }
}
