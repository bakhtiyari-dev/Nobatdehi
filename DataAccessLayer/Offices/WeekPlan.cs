﻿using EntityModel.Offices.Interfaces;
using Microsoft.Identity.Client.Extensibility;

namespace DataAccessLayer.Offices
{
    public class WeekPlan : IWeekPlan
    {
        private DatabaseContext _dbContext=new DatabaseContext();
        public WeekPlan()
        {
                
        }
        public void Create(EntityModel.Offices.WeekPlan weekPlan)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, EntityModel.Offices.WeekPlan newWeekPlan)
        {
            throw new NotImplementedException();
        }
    }
}
