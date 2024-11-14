using Microsoft.AspNetCore.Mvc;
using EntityModel.Offices.Interfaces;

namespace BusinessLogicLayer.BLOffices
{
    public class WeekPlan : IWeekPlan
    {
        DataAccessLayer.DLOffices.WeekPlan _dlWeek;
        public WeekPlan()
        {
            _dlWeek = new DataAccessLayer.DLOffices.WeekPlan();
        }

        public void Create(int opoId, EntityModel.Offices.WeekPlan weekPlan)
        {
            _dlWeek.Create(opoId, weekPlan);
        }

        public void Delete(EntityModel.Offices.WeekPlan weekPlan)
        {
            _dlWeek.Delete(weekPlan);
        }

        public EntityModel.Offices.WeekPlan? GetWeekPlan(int opoId)
        {
            return _dlWeek.GetWeekPlan(opoId);
        }

        public void Update(int opoId, EntityModel.Offices.WeekPlan newWeekPlan)
        {
            _dlWeek.Update(opoId, newWeekPlan);
        }
    }
}
