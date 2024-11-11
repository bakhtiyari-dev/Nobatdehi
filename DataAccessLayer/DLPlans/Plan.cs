using EntityModel.Plans.Interfaces;

namespace DataAccessLayer.DLPlans
{
    public class Plan:IPlan
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        public Plan()
        {
                
        }

        public void Create(EntityModel.Plans.Plan plan, EntityModel.Plans.PlanOption planOption)
        {
            _dbContext.Plans.Add(plan);
            _dbContext.PlanOptions.Add(planOption);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var plan = _dbContext.Plans.FirstOrDefault(o => o.Id == id);
            
            if (plan != null)
            {
                plan.Status = false;
                _dbContext.Plans.Update(plan);
                _dbContext.SaveChanges();
            }
        }

        public IQueryable? Get(int id)
        {
            var plan = _dbContext.Plans.Where(p => p.Id == id).Join(_dbContext.PlanOptions, p => p.Id, po => po.Plan.Id, (p,po) => 
            new
            {
                PlanId = p.Id,
                PlanName = p.Name,
                po.CitizenIdType,
                po.GeneralCreationFlag,
                po.FromDate,
                po.ToDate,
                p.Status
            });

            return plan;
        }

        public IQueryable? GetAll()
        {
            var plans = _dbContext.Plans.Join(_dbContext.PlanOptions, p => p.Id, po => po.Plan.Id, (p, po) =>
            new
            {
                PlanId = p.Id,
                PlanName = p.Name,
                po.CitizenIdType,
                po.GeneralCreationFlag,
                po.FromDate,
                po.ToDate,
                p.Status
            });

            return plans;
        }

        public void Update(int id, EntityModel.Plans.Plan newPlan, EntityModel.Plans.PlanOption newPlanOption)
        {
            var plan = _dbContext.Plans.FirstOrDefault(o => o.Id == id);

            if (plan != null)
            {
                var planOption = _dbContext.PlanOptions.FirstOrDefault(po => po.Plan.Id == plan.Id);
                if(planOption != null)
                {
                    plan.Name = newPlan.Name ?? plan.Name;
                    planOption.CitizenIdType = newPlanOption.CitizenIdType ?? planOption.CitizenIdType;
                    planOption.GeneralCreationFlag = newPlanOption.GeneralCreationFlag;
                    planOption.FromDate = newPlanOption.FromDate;
                    planOption.ToDate = newPlanOption.ToDate;
                    planOption.TurnTimeGap = newPlanOption.TurnTimeGap;

                    _dbContext.Plans.Update(plan);
                    _dbContext.PlanOptions.Update(planOption);
                    _dbContext.SaveChanges();
                }

            }

        }

        public bool IsExist(int id)
        {
            var result = _dbContext.Plans.FirstOrDefault(p => p.Id == id);

            if (result == null)
            {
                return false;
            }

            return true;
        }

        public EntityModel.Plans.Plan? GetPlan(int id)
        {
            return _dbContext.Plans.FirstOrDefault(p => p.Id == id);
        }

        public EntityModel.Plans.PlanOption? GetPlanOption(int id)
        {
            return _dbContext.PlanOptions.FirstOrDefault(p => p.Id == id);
        }
    }
}
