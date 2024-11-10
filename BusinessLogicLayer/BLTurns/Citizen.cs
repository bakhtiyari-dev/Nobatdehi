using EntityModel.Turns.Interfaces;
using DataAccessLayer;

namespace BusinessLogicLayer.BLTurns
{
    public class Citizen:ICitizen
    {
        private DatabaseContext _databaseContext=new DatabaseContext();
        public Citizen()
        {
            
        }

        public EntityModel.Turns.Citizen Get(int id)
        {
            throw new NotImplementedException();
        }

        public EntityModel.Turns.Citizen Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<EntityModel.Turns.Citizen> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
