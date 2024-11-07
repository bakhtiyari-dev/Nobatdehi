using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Plans.Interfaces
{
    public interface IPlanOption
    {
        public void Create(PlanOption planOption);
        public void Update(int id, PlanOption newPlanOption);
        public void Delete(int id);
    }
}
