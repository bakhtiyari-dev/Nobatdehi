using EntityModel.Offices.Interfaces;
using DataAccessLayer;

namespace BusinessLogicLayer.BLOffices
{
    public class Office:IOffice
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        public Office() 
        {
        }

        public void Create(EntityModel.Offices.Office office)
        {
            DataAccessLayer.DLOffices.Office dlOffice = new DataAccessLayer.DLOffices.Office();
            dlOffice.Create(office);
        }

        public void Delete(int id)
        {
            DataAccessLayer.DLOffices.Office dlOffice = new DataAccessLayer.DLOffices.Office();
            dlOffice.Delete(id);
        }

        public EntityModel.Offices.Office? Get(int id)
        {
            DataAccessLayer.DLOffices.Office dlOffice = new DataAccessLayer.DLOffices.Office();
            return dlOffice.Get(id);
        }

        public List<EntityModel.Offices.Office>? GetAll()
        {
            DataAccessLayer.DLOffices.Office dlOffice = new DataAccessLayer.DLOffices.Office();
            return dlOffice.GetAll();
        }

        public void Update(int id, EntityModel.Offices.Office newOffice)
        {
            DataAccessLayer.DLOffices.Office dlOffice = new DataAccessLayer.DLOffices.Office();
            dlOffice.Update(id, newOffice);
        }
    }
}
