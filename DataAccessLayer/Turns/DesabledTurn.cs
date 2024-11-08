using EntityModel.Turns.Interfaces;

namespace DataAccessLayer.Turns
{
    public class DesabledTurn : IDesabledTurn
    {
        private DatabaseContext dbContext = new DatabaseContext();
        public DesabledTurn()
        {

        }

        public void Create(EntityModel.Turns.DesabledTurn desabledTurn)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<EntityModel.Turns.DesabledTurn> GetAll(int officeId, int planId)
        {
            throw new NotImplementedException();
        }

        public TimeOnly GetDesabledTurnsByDate(int officeId, int planId, DateOnly day)
        {
            throw new NotImplementedException();
        }
    }
}
