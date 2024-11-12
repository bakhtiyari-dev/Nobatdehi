using EntityModel.Turns.Interfaces;
using DataAccessLayer;

namespace BusinessLogicLayer.BLTurns
{
    public class TurnPool:ITurnPool
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        public TurnPool()
        {
            
        }

        public void Create(EntityModel.Turns.TurnPool turnPool)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, EntityModel.Turns.TurnPool newTurnPool)
        {
            throw new NotImplementedException();
        }
    }
}
