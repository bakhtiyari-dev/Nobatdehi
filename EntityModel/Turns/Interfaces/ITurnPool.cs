using EntityModel.Offices;

namespace EntityModel.Turns.Interfaces
{
    public interface ITurnPool
    {
        public DateTime GetTurnTime(DateOnly day, OfficePlanOption opo);
        public Task<string> buldturns(OfficePlanOption opoId);
        public void Update(int id, TurnPool newTurnPool);
        public void Delete(int id);
        public bool isOpoExist(int id);
    }
}
