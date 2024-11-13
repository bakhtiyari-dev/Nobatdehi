using EntityModel.Turns;

namespace EntityModel.Turns.Interfaces
{
    public interface ICitizen
    {
        public Citizen? Get(int id);
        public List<Citizen>? GetCitizensById(string id);
        public List<Citizen>? GetAllCitizens();
    }
}
