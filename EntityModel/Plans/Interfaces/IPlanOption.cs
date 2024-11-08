namespace EntityModel.Plans.Interfaces
{
    public interface IPlanOption
    {
        public void Create(PlanOption planOption);
        public void Update(int id, PlanOption newPlanOption);
        public void Delete(int id);
    }
}
