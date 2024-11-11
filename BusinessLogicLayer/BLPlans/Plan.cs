using EntityModel.Plans.Interfaces;
using DataAccessLayer;

namespace BusinessLogicLayer.BLPlans
{
    public class Plan:IPlan
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        private DataAccessLayer.DLPlans.Plan _dlPlan;
        public Plan()
        {
            _dlPlan = new DataAccessLayer.DLPlans.Plan();
        }

        public void Create(EntityModel.Plans.Plan plan, EntityModel.Plans.PlanOption planOption)
        {
            _dlPlan.Create(plan, planOption);
        }

        public void Delete(int id)
        {
            _dlPlan.Delete(id);
        }

        public IQueryable? Get(int id)
        {
            return _dlPlan.Get(id);
        }

        public IQueryable? GetAll()
        {
            return _dlPlan.GetAll();
        }

        public void Update(int id, EntityModel.Plans.Plan newPlan, EntityModel.Plans.PlanOption newPlanOption)
        {
            _dlPlan.Update(id, newPlan, newPlanOption);
        }

        public bool IsExist(int id)
        {
            return _dlPlan.IsExist(id);
        }

        public EntityModel.Plans.Plan? GetPlan(int id)
        {
            return _dlPlan.GetPlan(id);
        }

        public EntityModel.Plans.PlanOption? GetPlanOption(int id)
        {
            return _dlPlan.GetPlanOption(id);
        }
    }
}
