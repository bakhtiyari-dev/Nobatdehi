using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Plans.Interfaces
{
    public interface IPlanDependency
    {
        public IQueryable? GetAllDependencies();
        public IQueryable? GetDependency(int id);
        public void CreateDependency(int inDependentId, int dependentId);
        public void DeleteDependency(int independentId, int dependentId);
        public bool CheckConflict(int inDependentId, int dependentId);
        public bool CheckExist(int independentId, int dependentId);
    }

    public interface IPlanHelper
    {
        public bool HasCycle(Plan plan, Plan dependent, int target, HashSet<int> visited);
    }
}
