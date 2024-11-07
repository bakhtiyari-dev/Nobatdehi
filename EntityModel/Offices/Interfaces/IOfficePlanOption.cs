using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel.Offices;

namespace EntityModel.Offices.Interfaces
{
    public interface IOfficePlanOption
    {
        public void Create(OfficePlanOption officePlan);
        public void Update(int id, OfficePlanOption newOfficePlan);
        public void Delete(int id);
    }
}
