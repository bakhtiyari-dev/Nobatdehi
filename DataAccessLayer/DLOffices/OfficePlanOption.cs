using DataAccessLayer.DLPlans;
using DataAccessLayer.Migrations;
using EntityModel.Offices.Interfaces;

namespace DataAccessLayer.DLOffices
{
    public class OfficePlanOption : IOfficePlanOption
    {
        private DatabaseContext _databaseContext;
        public OfficePlanOption() 
        {
            _databaseContext = new DatabaseContext();
        }

        public int SetId(int officeId, int planId)
        {
            return Convert.ToInt32(officeId.ToString() + planId.ToString());
        }

        public void Create(int officeId, int planId, EntityModel.Offices.OfficePlanOption officePlan)
        {
            var office = _databaseContext.Offices.FirstOrDefault(o => o.Id == officeId);
            var plan = _databaseContext.Plans.FirstOrDefault(p => p.Id == planId);

            if (office != null && plan != null)
            {
                officePlan.Id = SetId(officeId, planId);
                officePlan.Office = office;
                officePlan.Plan = plan;

                plan.OfficePlanOptions.Add(officePlan);
                office.OfficePlanOptions.Add(officePlan);
                _databaseContext.OfficePlanOptions.Add(officePlan);

                _databaseContext.Plans.Update(plan);
                _databaseContext.Offices.Update(office);
                _databaseContext.SaveChanges();
            }
        }

        public void Delete(int officeId, int planId)
        {
            var result = _databaseContext.OfficePlanOptions.FirstOrDefault(o => o.Id == SetId(officeId, planId));

            if (result != null) 
            {
                result.Status = false;
                _databaseContext.OfficePlanOptions.Update(result);
                _databaseContext.SaveChanges(); 
            }

        }

        public EntityModel.Offices.OfficePlanOption? Get(int officeId, int planId)
        {
            return _databaseContext.OfficePlanOptions.FirstOrDefault(o => o.Id == SetId(officeId, planId));
        }

        public List<EntityModel.Offices.OfficePlanOption>? GetAll()
        {
             return _databaseContext.OfficePlanOptions.ToList();
        }

        public void Update(int officeId, int planId, EntityModel.Offices.OfficePlanOption newOfficePlan)
        {
            var officePlan = _databaseContext.OfficePlanOptions.FirstOrDefault(o => o.Id == SetId(officeId, planId));

            if (officePlan != null)
            {
                officePlan.Id = SetId(officeId, planId);
                officePlan.FromDate = newOfficePlan.FromDate;
                officePlan.ToDate = newOfficePlan.ToDate;
                officePlan.Capacity = newOfficePlan.Capacity;

                _databaseContext.OfficePlanOptions.Update(officePlan);
                _databaseContext.SaveChanges();
            }
        }
    }
}
