namespace EntityModel.Turns.Interfaces
{
    public interface ITurn
    {
        public void Create(Turn turn);
        public void Delete(int id);
        public List<Turn>? GetAll();
        public Turn? Get(int id);
    }
}
