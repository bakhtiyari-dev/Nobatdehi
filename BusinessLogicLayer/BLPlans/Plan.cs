using EntityModel.Plans.Interfaces;
using DataAccessLayer;
using EntityModel.Turns;
using EntityModel.Turns.Interfaces;
using EntityModel.Plans;

namespace BusinessLogicLayer.BLPlans
{
    public class Plan:IPlan,IPlanDependency,IPlanCapacity
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

        public IEnumerable<PlanOption> GetAllPlans()
        {
            return _dlPlan.GetAllPlans();
        }


        // BLL : Plan Dependencies


        public void CreateDependency(int inDependentId, int dependentId)
        {
            _dlPlan.CreateDependency(inDependentId, dependentId);
        }

        public void DeleteDependency(int inDependentId, int dependentId)
        {
            _dlPlan.DeleteDependency(inDependentId, dependentId);
        }

        public IQueryable? GetDependency(int id)
        {
            return _dlPlan.GetDependency(id);
        }

        public IQueryable? GetAllDependencies()
        {
            return _dlPlan.GetAllDependencies();
        }

        public bool CheckConflict(int inDependentId, int dependentId)
        {
            return _dlPlan.CheckConflict(inDependentId, dependentId);
        }

        public bool CheckExist(int independentId, int dependentId)
        {
            return _dlPlan.CheckExist(independentId, dependentId);
        }


        // BLL : Capacity


        public void IncreaseCapacity(int officeId, int planId, int capacity)
        {
            _dlPlan.IncreaseCapacity(officeId, planId, capacity);
        }

        public void DecreaseCapacity(int officeId, int planId, int capacity)
        {
            _dlPlan.DecreaseCapacity(officeId, planId, capacity);
        }

        public void SetCapacity(int officeId, int planId, int capacity)
        {
            _dlPlan.SetCapacity(officeId, planId, capacity);
        }

    }
}
