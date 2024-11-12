using EntityModel.Turns.Interfaces;
using DataAccessLayer;

namespace BusinessLogicLayer.BLTurns
{
    public class Turn:ITurn
    {
        private DatabaseContext _dbContext=new DatabaseContext();
        public Turn()
        {
            
        }

        public void Create(EntityModel.Turns.Turn turn)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public EntityModel.Turns.Turn Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<EntityModel.Turns.Turn> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, EntityModel.Turns.Turn newTurn)
        {
            throw new NotImplementedException();
        }
    }
}
