namespace EntityModel.Offices.Interfaces
{
    public interface IOffice
    {
        public void Create(Office office);
        public void Update(int id, Office newOffice);
        public void Delete(int id);
        public List<Office>? GetAll();
        public Office? Get(int id);
        public void AddUser(int officeId, Users.CostumIdentityUser user);
    }
}
