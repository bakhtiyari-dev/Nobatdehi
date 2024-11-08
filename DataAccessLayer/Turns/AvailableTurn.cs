using EntityModel.Turns.Interfaces;

namespace DataAccessLayer.Turns
{
    public class AvailableTurn:IAvailableTurn
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        public AvailableTurn()
        {
            
        }

        public void Create(EntityModel.Turns.AvailableTurn availableTurn)
        {
            throw new NotImplementedException();
        }

        public void Delete(DateOnly Day, TimeOnly Hour)
        {
            throw new NotImplementedException();
        }

        public List<EntityModel.Turns.AvailableTurn> GetAvailableTurns(int officeId, int planId)
        {
            throw new NotImplementedException();
        }

        public TimeOnly GetAvailableTurnsByDate(int officeId, int planId, DateOnly day)
        {
            throw new NotImplementedException();
        }
    }
}
