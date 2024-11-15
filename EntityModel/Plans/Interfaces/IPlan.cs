namespace EntityModel.Plans.Interfaces
{
    public interface IPlan
    {
        public  void Create(Plan plan, PlanOption planOption);
        public void Update(int id, Plan newPlan, PlanOption newPlanOption);
        public void Delete(int id);
        public IQueryable? GetAll();
        public IEnumerable<PlanOption> GetAllPlans();
        public IQueryable? Get(int id);
        public bool IsExist(int id);
        public Plan? GetPlan(int id);
        public PlanOption? GetPlanOption(int id);
    }
}
