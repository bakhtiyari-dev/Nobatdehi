using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Plans.Interfaces
{
    public interface IPlan
    {
        public void Create(Plan plan);
        public void Update(int id, Plan newPlan);
        public void Delete(int id);
        public List<Plan> GetAll();
        public Plan Get(int id);
    }
}
