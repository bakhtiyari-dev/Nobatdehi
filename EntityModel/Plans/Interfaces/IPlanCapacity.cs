using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Plans.Interfaces
{
    public interface IPlanCapacity
    {
        public void IncreaseCapacity(int officeId, int planId, int capacity);
        public void DecreaseCapacity(int officeId, int planId, int capacity);
        public void SetCapacity(int officeId, int planId, int capacity);
    }
}
