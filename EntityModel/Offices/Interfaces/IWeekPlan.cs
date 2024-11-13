using Microsoft.AspNetCore.Mvc;

namespace EntityModel.Offices.Interfaces
{
    public interface IWeekPlan
    {
        public IActionResult? GetWeekPlan(int id);
        public void Create(WeekPlan weekPlan);
        public void Update(int id, WeekPlan newWeekPlan);
        public void Delete(WeekPlan weekPlan);
    }
}
