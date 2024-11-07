using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Plans.Interfaces
{
    public interface IPlanDependency
    {
        public void Create(Dependency dependency);
        public void Update(int id, Dependency newDependency);
        public void Update(string id, Dependency newDependency);
        public void Delete(int id);
        public void Delete(string id);
    }
}
