using EntityModel.Turns.Interfaces;

namespace BusinessLogicLayer.BLTurns
{
    public class AvailableTurn : IAvailableTurn
    {
        private DataAccessLayer.DLTurns.AvailableTurn _dlAvailable;
        public AvailableTurn()
        {
            _dlAvailable = new DataAccessLayer.DLTurns.AvailableTurn();
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
