using EntityModel.Offices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DLOffices
{
    public class OfficePlanOption : IOfficePlanOption
    {
        private DatabaseContext _databaseContext;
        public OfficePlanOption()
        {
            _databaseContext = new DatabaseContext();
        }

        public void Create(int officeId, int planId, EntityModel.Offices.OfficePlanOption officePlan)
        {
            var office = _databaseContext.Offices.FirstOrDefault(o => o.Id == officeId);
            var plan = _databaseContext.Plans.FirstOrDefault(p => p.Id == planId);

            if (office != null && plan != null)
            {
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
            var result = _databaseContext.OfficePlanOptions.FirstOrDefault(o => o.Office.Id == officeId && o.Plan.Id == planId);

            if (result != null)
            {
                result.Status = false;
                _databaseContext.OfficePlanOptions.Update(result);
                _databaseContext.SaveChanges();
            }

        }

        public EntityModel.Offices.OfficePlanOption? Get(int officeId, int planId)
        {
            return _databaseContext.OfficePlanOptions.Include(o => o.Office).Include(o => o.Plan).FirstOrDefault(o => o.Office.Id == officeId && o.Plan.Id == planId);
        }

        public List<EntityModel.Offices.OfficePlanOption>? GetAll()
        {
            return _databaseContext.OfficePlanOptions.ToList();
        }

        public void Update(int officeId, int planId, EntityModel.Offices.OfficePlanOption newOfficePlan)
        {
            var officePlan = _databaseContext.OfficePlanOptions.FirstOrDefault(o => o.Office.Id == officeId && o.Plan.Id == planId);

            if (officePlan != null)
            {
                officePlan.FromDate = newOfficePlan.FromDate;
                officePlan.ToDate = newOfficePlan.ToDate;
                officePlan.Capacity = newOfficePlan.Capacity;

                _databaseContext.OfficePlanOptions.Update(officePlan);
                _databaseContext.SaveChanges();
            }
        }
    }
}
