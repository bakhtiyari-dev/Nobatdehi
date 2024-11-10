using EntityModel.Plans.Interfaces;

namespace DataAccessLayer.DLPlans
{
    public class Plan:IPlan
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        public Plan()
        {
                
        }

        public void Create(EntityModel.Plans.Plan plan)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public EntityModel.Plans.Plan Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<EntityModel.Plans.Plan> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, EntityModel.Plans.Plan newPlan)
        {
            throw new NotImplementedException();
        }
    }
}
