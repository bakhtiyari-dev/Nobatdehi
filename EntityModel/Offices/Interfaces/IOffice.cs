using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel.Offices;

namespace EntityModel.Offices.Interfaces
{
    public interface IOffice
    {
        public void Create(Office office);
        public void Update(int id, Office newOffice);
        public void Delete(int id);
        public List<Office> GetAll();
        public Office Get(int id);
    }
}
