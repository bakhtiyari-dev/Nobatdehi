namespace EntityModel.Offices.Interfaces
{
    public interface IOfficePlanOption
    {
        public void Create(OfficePlanOption officePlan);
        public void Update(int id, OfficePlanOption newOfficePlan);
        public void Delete(int id);
    }
}
