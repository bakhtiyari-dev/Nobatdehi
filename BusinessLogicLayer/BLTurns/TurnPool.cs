using EntityModel.Turns.Interfaces;
using DataAccessLayer;
using EntityModel.Offices;

namespace BusinessLogicLayer.BLTurns
{
    public class TurnPool:ITurnPool
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
            throw new NotImplementedException();
        }

        public DateTime GetTurnTime(DateOnly day, int opoId)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, EntityModel.Turns.TurnPool newTurnPool)
        {
            throw new NotImplementedException();
        }
    }
}
