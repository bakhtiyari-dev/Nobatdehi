using Microsoft.AspNetCore.Mvc;

namespace EntityModel.Offices.Interfaces
{
    public interface IWeekPlan
    {
        public WeekPlan? GetWeekPlan(int opoId);
        public void Create(int opoId, WeekPlan weekPlan);
        public void Update(int opoId, WeekPlan newWeekPlan);
        public void Delete(WeekPlan weekPlan);
    }
}
