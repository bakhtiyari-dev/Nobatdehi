using EntityModel.Offices.Interfaces;

namespace BusinessLogicLayer.BLOffices
{
    public class Office : IOffice
    {
        DataAccessLayer.DLOffices.Office _dlOffice;
        public Office()
        {
            _dlOffice = new DataAccessLayer.DLOffices.Office();
        }

        public void Create(EntityModel.Offices.Office office)
        {
            _dlOffice.Create(office);
        }

        public void Delete(int id)
        {
            _dlOffice.Delete(id);
        }

        public EntityModel.Offices.Office? Get(int id)
        {
            return _dlOffice.Get(id);
        }

        public List<EntityModel.Offices.Office>? GetAll()
        {
            return _dlOffice.GetAll();
        }

        public void Update(int id, EntityModel.Offices.Office newOffice)
        {
            _dlOffice.Update(id, newOffice);
        }

        public void AddUser(int officeId, EntityModel.Users.CostumIdentityUser user)
        {
            _dlOffice.AddUser(officeId, user);
        }
    }
}
