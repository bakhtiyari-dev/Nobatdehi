using EntityModel.Turns.Interfaces;

namespace DataAccessLayer.DLTurns
{
    public class TurnFilter : ITurnFilter
    {
        private DatabaseContext _dbContext;
        public TurnFilter()
        {
            _dbContext = new DatabaseContext();
        }

        public List<EntityModel.Turns.Turn>? GetAllTurnsByCitizen(string citizenId)
        {
            return _dbContext.turns.Where(t => t.CitizenId.ToString() == citizenId || t.Citizen.Passport == citizenId || t.Citizen.ExclusiveCode == citizenId || t.Citizen.UniqCode == citizenId || t.Citizen.HouseholdCode == citizenId).ToList();
        }

        public List<EntityModel.Turns.Turn>? GetAllTurnsByOffice(int officeId)
        {
            return _dbContext.turns.Where(t => t.OfficeId == officeId).ToList();
        }

        public List<EntityModel.Turns.Turn>? GetAllTurnsByPlan(int planId)
        {
            return _dbContext.turns.Where(t => t.PlanId == planId).ToList();
        }

        public List<EntityModel.Turns.Turn>? GetTurnsByDate(DateOnly fromDate, TimeOnly fromHour, DateOnly toDate, TimeOnly toHour)
        {
            DateTime fromDateTime = fromDate.ToDateTime(fromHour);
            DateTime toDateTime = toDate.ToDateTime(toHour);

            return _dbContext.turns.Where(t => t.TurnTime >= fromDateTime && t.TurnTime <= toDateTime).ToList();
        }
    }
}
