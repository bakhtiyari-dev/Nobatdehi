using EntityModel.Offices;
using Microsoft.AspNetCore.Mvc;

namespace EntityModel.Turns.Interfaces
{
    public interface ITurnPool
    {
        public DateTime GetTurnTime(DateOnly day, int opoId);
        public Task<string> buldturns(OfficePlanOption opoId);
        public void Update(int id, TurnPool newTurnPool);
        public void Delete(int id);
    }

    public interface ITurnChecker
    {
        
    }
}
