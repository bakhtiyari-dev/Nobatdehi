﻿using EntityModel.Offices.Interfaces;

namespace DataAccessLayer.Offices
{
    public class OfficePlanOption : IOfficePlanOption
    {
        private DatabaseContext _databaseContext = new DatabaseContext();
        public OfficePlanOption() 
        {

        }
        public void Create(EntityModel.Offices.OfficePlanOption officePlan)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, EntityModel.Offices.OfficePlanOption newOfficePlan)
        {
            throw new NotImplementedException();
        }
    }
}
