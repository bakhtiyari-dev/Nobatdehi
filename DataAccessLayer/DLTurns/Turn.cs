using EntityModel.Turns.Interfaces;

namespace DataAccessLayer.DLTurns
{
    public class Turn:ITurn
    {
        private DatabaseContext _dbContext;
        public Turn()
        {
            _dbContext = new DatabaseContext();
        }

        public void Create(EntityModel.Turns.Turn turn)
        {
            _dbContext.turns.Add(turn);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var turn = _dbContext.turns.FirstOrDefault(x => x.Id == id);

            if (turn != null)
            {
                turn.Status = false;
                _dbContext.Update(turn);
                _dbContext.SaveChanges();
            }
        }

        public EntityModel.Turns.Turn? Get(int id)
        {
            var turn = _dbContext.turns.FirstOrDefault(x => x.Id == id);

            return turn;
        }

        public List<EntityModel.Turns.Turn>? GetAll()
        {
            return _dbContext.turns.ToList();
        }
    }
}
