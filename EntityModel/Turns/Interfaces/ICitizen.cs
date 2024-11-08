namespace EntityModel.Turns.Interfaces
{
    public interface ICitizen
    {
        public List<Citizen> GetAll();
        public Citizen Get(int id);
        public Citizen Get(string id);
    }
}
