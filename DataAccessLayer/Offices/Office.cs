using EntityModel.Offices.Interfaces;

namespace DataAccessLayer.Methods
{
    public class Office:IOffice
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        public Office() 
        {
        }

        public void Create(EntityModel.Offices.Office office)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public EntityModel.Offices.Office Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<EntityModel.Offices.Office> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, EntityModel.Offices.Office newOffice)
        {
            throw new NotImplementedException();
        }
    }
}
