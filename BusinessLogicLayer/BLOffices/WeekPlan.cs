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

        public void Create(EntityModel.Offices.WeekPlan weekPlan)
        {
            _dlWeek.Create(weekPlan);
        }

        public void Delete(EntityModel.Offices.WeekPlan weekPlan)
        {
            _dlWeek.Delete(weekPlan);
        }

        public IActionResult? GetWeekPlan(int id)
        {
            return _dlWeek.GetWeekPlan(id);
        }

        public void Update(int id, EntityModel.Offices.WeekPlan newWeekPlan)
        {
            _dlWeek.Update(id, newWeekPlan);
        }
    }
}
