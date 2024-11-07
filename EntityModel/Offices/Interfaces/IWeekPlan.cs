using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel.Offices;

namespace EntityModel.Offices.Interfaces
{
    public interface IWeekPlan
    {
        public void Create(WeekPlan weekPlan);
        public void Update(int id, WeekPlan newWeekPlan);
        public void Delete(int id);
    }
}
