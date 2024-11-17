using EntityModel.Turns.Interfaces;

namespace DataAccessLayer.DLTurns
{
    public class DesabledTurn : IDesabledTurn
    {
        private DatabaseContext _dbContext;
        public DesabledTurn()
        {
            _dbContext = new DatabaseContext();
        }

        public void Create(EntityModel.Turns.DesabledTurn desabledTurn)
        {
            _dbContext.desabledTurns.Add(desabledTurn);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var turn = _dbContext.desabledTurns.FirstOrDefault(turn => turn.Id == id);

            if (turn != null)
            {
                _dbContext.desabledTurns.Remove(turn);
                _dbContext.SaveChanges();
            }
        }

        public List<EntityModel.Turns.DesabledTurn> GetAll(int officeId, int planId)
        {
            throw new NotImplementedException();
        }

        public EntityModel.Turns.DesabledTurn? GetDesabledTurnsByDate(int officeId, int planId, DateOnly day)
        {
            var turns = _dbContext.desabledTurns.Where(turn => turn.Day >= day && turn.OfficeId == officeId && turn.PlanId == planId).OrderBy(turn => turn.Day).ToList();

            if (turns.Count > 0)
            {
                return turns.First();
            }

            return null;
        }
    }
}
