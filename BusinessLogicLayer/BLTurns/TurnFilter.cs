using EntityModel.Turns.Interfaces;

namespace BusinessLogicLayer.BLTurns
{
    public class TurnFilter : ITurnFilter
    {
        private DataAccessLayer.DLTurns.TurnFilter _dlFilter;
        public TurnFilter()
        {
            _dlFilter = new DataAccessLayer.DLTurns.TurnFilter();
        }

        public List<EntityModel.Turns.Turn>? GetAllTurnsByCitizen(string citizenId)
        {
            return _dlFilter.GetAllTurnsByCitizen(citizenId);
        }

        public List<EntityModel.Turns.Turn>? GetAllTurnsByOffice(int officeId)
        {
            return _dlFilter.GetAllTurnsByOffice(officeId);
        }

        public List<EntityModel.Turns.Turn>? GetAllTurnsByPlan(int planId)
        {
            return _dlFilter.GetAllTurnsByPlan(planId);
        }

        public List<EntityModel.Turns.Turn>? GetTurnsByDate(DateOnly fromDate, TimeOnly fromHour, DateOnly toDate, TimeOnly toHour)
        {
            return _dlFilter.GetTurnsByDate(fromDate, fromHour, toDate, toHour);
        }
    }
}
