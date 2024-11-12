namespace EntityModel.Offices.Interfaces
{
    public interface IOfficePlanOption
    {
        public void Create(int officeId, int planId, OfficePlanOption officePlan);
        public void Update(int officeId, int planId, OfficePlanOption newOfficePlan);
        public void Delete(int officeId, int planId);
        public OfficePlanOption? Get(int officeId, int planId);
        public List<OfficePlanOption>? GetAll();
    }
}
