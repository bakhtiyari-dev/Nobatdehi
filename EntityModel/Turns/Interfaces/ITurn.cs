namespace EntityModel.Turns.Interfaces
{
    public interface ITurn
    {
        public void Create(Turn turn);
        public void Update(int id, Turn newTurn);
        public void Delete(int id);
        public List<Turn> GetAll();
        public Turn Get(int id);
    }
}
