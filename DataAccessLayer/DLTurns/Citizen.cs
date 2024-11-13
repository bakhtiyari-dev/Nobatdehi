using EntityModel.Turns.Interfaces;
using EntityModel.Turns;

namespace DataAccessLayer.DLTurns
{
    public class Citizen: ICitizen
    {
        private DatabaseContext _dbContext;
        public Citizen()
        {
            _dbContext = new DatabaseContext();
        }



        // DAL : Citizen


        public List<EntityModel.Turns.Citizen>? GetCitizensById(string id)
        {
            var citizens = _dbContext.citizens.Where(c => c.Id.ToString() == id || c.ExclusiveCode == id || c.Passport == id || c.UniqCode == id || c.HouseholdCode == id).ToList();

            return citizens;
        }

        public List<EntityModel.Turns.Citizen>? GetAllCitizens()
        {
            return _dbContext.citizens.ToList();
        }
    }
}
