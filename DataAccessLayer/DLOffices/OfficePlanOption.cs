using EntityModel.Offices;
using EntityModel.Offices.Interfaces;
using EntityModel.Plans;
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

        public void Create(EntityModel.Offices.Office office, EntityModel.Plans.Plan plan, EntityModel.Offices.OfficePlanOption officePlan)
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
            var result = _databaseContext.OfficePlanOptions.FirstOrDefault(o => o.Office.Id == officeId && o.Plan.Id == planId);

            return result;
        }

        public List<EntityModel.Offices.OfficePlanOption>? GetAll()
        {
            var result = _databaseContext.OfficePlanOptions.Include(opo => opo.Office).Include(opo => opo.Plan).Select(opo => new EntityModel.Offices.OfficePlanOption
            {
                Id = opo.Id,
                Capacity = opo.Capacity,
                Status = opo.Status,
                FromDate = opo.FromDate,
                ToDate = opo.ToDate,

                Office = new EntityModel.Offices.Office {
                    Id = opo.Office.Id,
                    City = opo.Office.City
                },
                Plan = new EntityModel.Plans.Plan
                {
                    Id = opo.Plan.Id,
                    Name = opo.Plan.Name
                }
            }).ToList();

            //return _databaseContext.OfficePlanOptions.ToList();

            return result;
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
