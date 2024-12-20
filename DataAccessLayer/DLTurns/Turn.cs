﻿using EntityModel.Offices;
using EntityModel.Turns.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DLTurns
{
    public class Turn : ITurn
    {
        private DatabaseContext _dbContext;
        public Turn()
        {
            _dbContext = new DatabaseContext();
        }

        public bool CheckCitizenHasDependencies(int citizen, int planId)
        {
            var plan = _dbContext.Plans.Where(p => p.Id == planId).Include(d => d.dependentPlans).Single();

            if (plan != null)
            {
                foreach (var item in plan.dependentPlans)
                {
                    if(!IsCitizenExist(citizen, item.Id))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckTurnBeforDelete(int citizenId, int planId)
        {
            var plans = _dbContext.Plans.Include(d => d.dependentPlans).ToList();

            foreach (var plan in plans)
            {
                foreach (var dependent in plan.dependentPlans)
                {
                    if(dependent.Id == planId)
                    {
                        if(IsCitizenExist(citizenId, plan.Id))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public void Create(EntityModel.Turns.Turn turn, OfficePlanOption officePlan)
        {
            _dbContext.turns.Add(turn);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var turn = _dbContext.turns.FirstOrDefault(t => t.Id == id);

            if (turn != null)
            {
                turn.Status = false;
                _dbContext.Update(turn);
                _dbContext.SaveChanges();
            }
        }

        public EntityModel.Turns.Turn? Get(int id)
        {
            var turn = _dbContext.turns.FirstOrDefault(x => x.Id == id);

            return turn;
        }

        public List<EntityModel.Turns.Turn>? GetAll()
        {
            return _dbContext.turns.ToList();
        }

        public bool IsCitizenExist(int citizenId, int planId)
        {
            var turn = _dbContext.turns.FirstOrDefault(t => t.CitizenId == citizenId && t.PlanId == planId && t.Status == true);

            return turn != null;
        }
    }
}
