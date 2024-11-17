namespace EntityModel.Turns.Interfaces
{
    public interface ITurnFilter
    {
        public List<Turn>? GetTurnsByDate(DateOnly fromDate, TimeOnly fromHour, DateOnly toDate, TimeOnly toHour);
        public List<Turn>? GetAllTurnsByPlan(int planId);
        public List<Turn>? GetAllTurnsByOffice(int officeId);
        public List<Turn>? GetAllTurnsByCitizen(string citizenId);
    }
}
