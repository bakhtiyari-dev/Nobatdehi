using EntityModel.Turns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BLTurns
{
    public class TurnFilter : ITurnFilter
    {
        private DataAccessLayer.DLTurns.TurnFilter _dlFilter;
        public TurnFilter()
        {
            _dlFilter = new DataAccessLayer.DLTurns.TurnFilter(); 
        }

        public List<EntityModel.Turns.Turn>? GetAllTurnsByCitizen(int citizenId)
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
