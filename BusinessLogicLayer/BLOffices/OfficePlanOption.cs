using EntityModel.Offices.Interfaces;
using EntityModel.Plans;

namespace BusinessLogicLayer.BLOffices
{
    public class OfficePlanOption : IOfficePlanOption
    {
        DataAccessLayer.DLOffices.OfficePlanOption _dlOPO;
        public OfficePlanOption()
        {
            _dlOPO = new DataAccessLayer.DLOffices.OfficePlanOption();
        }
        public void Create(EntityModel.Offices.Office office, Plan plan, EntityModel.Offices.OfficePlanOption officePlan)
        {
            _dlOPO.Create(office, plan, officePlan);
        }

        public void Delete(int officeId, int planId)
        {
            _dlOPO.Delete(officeId, planId);
        }

        public EntityModel.Offices.OfficePlanOption? Get(int officeId, int planId)
        {
            return _dlOPO.Get(officeId, planId);
        }

        public List<EntityModel.Offices.OfficePlanOption>? GetAll()
        {
            return _dlOPO.GetAll();
        }

        public void Update(int officeId, int planId, EntityModel.Offices.OfficePlanOption newOfficePlan)
        {
            _dlOPO.Update(officeId, planId, newOfficePlan);
        }
    }
}
