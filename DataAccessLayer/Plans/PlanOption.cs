using EntityModel.Plans.Interfaces;

namespace DataAccessLayer.Plans
{
    public class PlanOption:IPlanOption
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        public PlanOption()
        {
                
        }
        public void Create(EntityModel.Plans.PlanOption planOption)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, EntityModel.Plans.PlanOption newPlanOption)
        {
            throw new NotImplementedException();
        }
    }
}
