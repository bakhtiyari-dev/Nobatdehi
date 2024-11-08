using EntityModel.Turns.Interfaces;

namespace DataAccessLayer.Turns
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
