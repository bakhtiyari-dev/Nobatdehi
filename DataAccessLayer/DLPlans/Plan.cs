using EntityModel.Plans.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DLPlans
{
    public class Plan:IPlan,IPlanDependency,IPlanHelper,IPlanCapacity
    {
        private DatabaseContext _dbContext;
        public Plan()
        {
                _dbContext = new DatabaseContext();
        }

        public int SetId(int officeId, int planId)
        {
            return Convert.ToInt32(officeId.ToString() + planId.ToString());
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


        // DAL : Plan Dependencies


        public void CreateDependency(int inDependentId, int dependentId)
        {
            var indep = _dbContext.Plans.FirstOrDefault(p => p.Id == inDependentId);
            var dep = _dbContext.Plans.FirstOrDefault(d => d.Id == dependentId);

            if (indep != null && dep != null)
            {
                indep.dependentPlans.Add(dep);
                dep.headPlans.Add(indep);
                _dbContext.Plans.Update(indep);
                _dbContext.Plans.Update(dep);
                _dbContext.SaveChangesAsync();
            }

        }

        public void DeleteDependency(int inDependentId, int dependentId)
        {
            var indept = _dbContext.Plans.Where(i => i.Id == inDependentId).Include(d => d.dependentPlans).Single();

            if (indept != null)
            {
                
                var dependent = indept.dependentPlans.FirstOrDefault(d => d.Id == dependentId);

                if (dependent != null)
                {   
                    indept.dependentPlans.Remove(dependent);
                    _dbContext.Plans.Update(indept);
                    _dbContext.SaveChanges();
                }
            }
        }

        public IQueryable? GetDependency(int id)
        {
            var indept = _dbContext.Plans.Where(i => i.Id == id).Include(d => d.dependentPlans).Select(s => new
            {
                s.Id,
                s.Name,
                dependencies = s.dependentPlans.Select(d => new
                {
                    d.Id,
                    d.Name
                })
            });

            return indept;
        }

        public IQueryable? GetAllDependencies()
        {
            var dependencies = _dbContext.Plans.Select(p => new
            {
                p.Id,
                p.Name,
                Dependencies = p.dependentPlans.Select(d => new
                {
                    d.Id,
                    d.Name
                })
            }).AsQueryable();

            return dependencies;
        }

        public bool CheckConflict(int independentId, int dependentId)
        {
            var indept = _dbContext.Plans.FirstOrDefault(c => c.Id == independentId);
            var dependent = _dbContext.Plans.Where(i => i.Id == dependentId).Include(d => d.dependentPlans).Single();

            if (indept == null || dependent == null)
                return false;

            var visited = new HashSet<int>();
            return !HasCycle(indept, dependent, indept.Id, visited);
        }

        // DFS algorithm
        public bool HasCycle(EntityModel.Plans.Plan plan, EntityModel.Plans.Plan dependent, int target, HashSet<int> visited)
        {
            if (dependent.Id == target)
                return false;
            visited.Add(plan.Id);

            var depend = _dbContext.Plans.Where(i => i.Id == dependent.Id).Include(d => d.dependentPlans).Single();

            foreach (var dep in depend.dependentPlans)
            {
                if (visited.Contains(dep.Id) || !HasCycle(dependent, dep, target, visited))
                {
                    return false;
                }
            }


            visited.Remove(plan.Id);
            return true;
        }

        public bool CheckExist(int independentId, int dependentId)
        {
            var indept = _dbContext.Plans.FirstOrDefault(c => c.Id == independentId);
            var dependent = _dbContext.Plans.FirstOrDefault(d => d.Id == dependentId);

            if (indept == null || dependent == null)
                return false;

            return true;
        }


        // DAL : Capacity


        public void IncreaseCapacity(int officeId, int planId, int capacity)
        {
            var officePlan = _dbContext.OfficePlanOptions.FirstOrDefault(o => o.Id == SetId(officeId, planId));

            if (officePlan != null)
            {
                officePlan.Capacity += capacity;
                _dbContext.OfficePlanOptions.Update(officePlan);
                _dbContext.SaveChanges();
            }
        }

        public void DecreaseCapacity(int officeId, int planId, int capacity)
        {
            var officePlan = _dbContext.OfficePlanOptions.FirstOrDefault(o => o.Id == SetId(officeId, planId));

            if (officePlan != null)
            {
                officePlan.Capacity -= capacity;
                if (officePlan.Capacity < 0)
                    officePlan.Capacity = 0;
                _dbContext.OfficePlanOptions.Update(officePlan);
                _dbContext.SaveChanges();
            }
        }

        public void SetCapacity(int officeId, int planId, int capacity)
        {
            var officePlan = _dbContext.OfficePlanOptions.FirstOrDefault(o => o.Id == SetId(officeId, planId));

            if (officePlan != null)
            {
                officePlan.Capacity = capacity;
                _dbContext.OfficePlanOptions.Update(officePlan);
                _dbContext.SaveChanges();
            }
        }
    }
}
