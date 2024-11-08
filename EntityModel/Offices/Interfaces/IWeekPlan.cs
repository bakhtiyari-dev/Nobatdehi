namespace EntityModel.Offices.Interfaces
{
    public interface IWeekPlan
    {
        public void Create(WeekPlan weekPlan);
        public void Update(int id, WeekPlan newWeekPlan);
        public void Delete(int id);
    }
}
