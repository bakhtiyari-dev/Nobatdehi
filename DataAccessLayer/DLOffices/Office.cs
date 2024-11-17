using EntityModel.Offices.Interfaces;

namespace DataAccessLayer.DLOffices
{
    public class Office:IOffice
    {
        private DatabaseContext _dbContext = new DatabaseContext();

        public int Id { get; internal set; }
        public string City { get; internal set; }

        public Office() 
        {
        }


        public void Create(EntityModel.Offices.Office office)
        {
            _dbContext.Offices.Add(office);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var office = _dbContext.Offices.FirstOrDefault(o => o.Id == id);
            if (office != null) 
            {
                office.Status = false;
                _dbContext.Offices.Update(office);
                _dbContext.SaveChanges();
            }
        }

        public EntityModel.Offices.Office? Get(int id)
        {
            var office = _dbContext.Offices.FirstOrDefault(o => o.Id == id);

            return office;
        }

        public List<EntityModel.Offices.Office>? GetAll()
        {
            var offices = _dbContext.Offices.ToList();
            return offices;
        }

        public void Update(int id, EntityModel.Offices.Office newOffice)
        {
            var office = _dbContext.Offices.FirstOrDefault(o => o.Id == id);
            if (office != null)
            {
                office.PhoneNumber = newOffice.PhoneNumber;
                office.City = newOffice.City;
                _dbContext.Offices.Update(office);
                _dbContext.SaveChanges();
            }
        }
        
        public void AddUser(int officeId, EntityModel.Users.CostumIdentityUser user)
        {
            var office = _dbContext.Offices.FirstOrDefault(o => o.Id == officeId);

            office.Users.Add(user);
            _dbContext.Update(office);
            _dbContext.SaveChanges();
        }
    }
}
