using Microsoft.AspNetCore.Mvc;
using EntityModel.Offices.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DataAccessLayer.DLOffices
{
    public class WeekPlan : IWeekPlan
    {
        private DatabaseContext _dbContext;
        public WeekPlan()
        {
            _dbContext = new DatabaseContext();
        }

        public void Create(int opoId, EntityModel.Offices.WeekPlan weekPlan)
        {
            weekPlan.OfficePlanOptionId = opoId;
            _dbContext.WeekPlans.Add(weekPlan);
            _dbContext.SaveChanges();
        }

        public void Delete(EntityModel.Offices.WeekPlan weekPlan)
        {
            _dbContext.Remove(weekPlan);
            _dbContext.SaveChanges();
        }

        public IActionResult? GetWeekPlan(int opoId)
        {
            var weekPlan = _dbContext.WeekPlans.FirstOrDefault(weekPlan => weekPlan.OfficePlanOptionId == opoId);

            return (IActionResult?)weekPlan;
        }

        public void Update(int opoId, EntityModel.Offices.WeekPlan newWeekPlan)
        {
            var check = GetWeekPlan(opoId);

            if (check != null)
            {
                EntityModel.Offices.WeekPlan weekPlan = (EntityModel.Offices.WeekPlan) check;

                weekPlan.SaterdayFirstHour = newWeekPlan.SaterdayFirstHour;
                weekPlan.SaterdayLasttHour = newWeekPlan.SaterdayLasttHour;

                weekPlan.SundayFirstHour = newWeekPlan.SundayFirstHour;
                weekPlan.SundayLasttHour = newWeekPlan.SundayLasttHour;

                weekPlan.MondayFirstHour = newWeekPlan.MondayFirstHour;
                weekPlan.MondayLasttHour = newWeekPlan.MondayLasttHour;

                weekPlan.tuesdayFirstHour = newWeekPlan.tuesdayFirstHour;
                weekPlan.tuesdayLasttHour = newWeekPlan.tuesdayLasttHour;

                weekPlan.wednesdayFirstHour = newWeekPlan.wednesdayFirstHour;
                weekPlan.wednesdayLasttHour = newWeekPlan.wednesdayLasttHour;

                weekPlan.thursdayFirstHour = newWeekPlan.thursdayFirstHour;
                weekPlan.thursdayLasttHour = newWeekPlan.tuesdayLasttHour;

                weekPlan.fridayFirstHour = newWeekPlan.fridayFirstHour;
                weekPlan.fridayLasttHour = newWeekPlan.fridayLasttHour;

                _dbContext.WeekPlans.Update(weekPlan);
                _dbContext.SaveChanges();
            }
        }
    }
}
