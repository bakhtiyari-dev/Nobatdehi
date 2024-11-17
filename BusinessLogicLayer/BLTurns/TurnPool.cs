using EntityModel.Offices;
using EntityModel.Turns.Interfaces;

namespace BusinessLogicLayer.BLTurns
{
    public class TurnPool : ITurnPool
    {
        private DataAccessLayer.DLTurns.TurnPool _dlPool;
        public TurnPool()
        {
            _dlPool = new DataAccessLayer.DLTurns.TurnPool();
        }

        public async Task<string> buldturns(OfficePlanOption opo)
        {
            return await _dlPool.buldturns(opo);
        }

        public void Delete(int id)
        {
            _dlPool.Delete(id);
        }

        public DateTime GetTurnTime(DateOnly day, OfficePlanOption opo)
        {
            return _dlPool.GetTurnTime(day, opo);
        }

        public bool isOpoExist(int id)
        {
            return _dlPool.isOpoExist(id);
        }

        public void Update(int id, EntityModel.Turns.TurnPool newTurnPool)
        {
            throw new NotImplementedException();
        }
    }
}
