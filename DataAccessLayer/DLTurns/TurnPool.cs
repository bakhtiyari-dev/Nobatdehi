using EntityModel.Turns.Interfaces;
using EntityModel.Offices;
using DataAccessLayer.DLOffices;
using EntityModel.Plans;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DLTurns
{
    public class TurnPool:ITurnPool
    {
        private DatabaseContext _dbContext;
        public TurnPool()
        {
            _dbContext = new DatabaseContext();
        }

        public async Task AddAvailableTurns(TimeOnly startTime, TimeOnly endTime, DateOnly day, int timeGap, EntityModel.Turns.TurnPool turnPool)
        {
            for (TimeOnly time = startTime; time < endTime; time = time.AddMinutes(timeGap))
            {
                EntityModel.Turns.AvailableTurn availableTurn = new EntityModel.Turns.AvailableTurn()
                {
                    AvailableTurnDate = day,
                    AvailableTurnTime = time,
                    TurnPool = turnPool
                };
                turnPool.AvailableTurns.Add(availableTurn);
                await _dbContext.availableTurns.AddAsync(availableTurn);
                
            }
            try
            {
                _dbContext.turnPools.Update(turnPool);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

        }

        public async Task<string> buldturns(EntityModel.Offices.OfficePlanOption opo)
        {
            var weekplan = _dbContext.WeekPlans.FirstOrDefault(w => w.OfficePlanOptionId == opo.Id);
            var planoption = _dbContext.PlanOptions.FirstOrDefault(po => po.Id == opo.Plan.Id);
            
            if (weekplan != null)
            {
                EntityModel.Turns.TurnPool turnPool = new EntityModel.Turns.TurnPool()
                {
                    OfficePlanOptionId = opo.Id
                };
                _dbContext.turnPools.Add(turnPool);
                _dbContext.SaveChanges();

                for (DateOnly date = opo.FromDate; date <= opo.ToDate; date = date.AddDays(1))
                {
                    switch (date.DayOfWeek)
                    {
                        case DayOfWeek.Saturday:
                            try
                            {
                                await AddAvailableTurns(weekplan.SaterdayFirstHour, weekplan.SaterdayLasttHour, date, planoption.TurnTimeGap, turnPool);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.ToString());
                            }

                            break;

                        case DayOfWeek.Sunday:
                            try
                            {
                                await AddAvailableTurns(weekplan.SundayFirstHour, weekplan.SundayLasttHour, date, planoption.TurnTimeGap, turnPool);
                            }
                            catch (Exception ex)
                            {

                                throw new Exception(ex.ToString());
                            }

                            break;

                        case DayOfWeek.Monday:
                            try
                            {
                                await AddAvailableTurns(weekplan.MondayFirstHour, weekplan.MondayLasttHour, date, planoption.TurnTimeGap, turnPool);
                            }
                            catch (Exception ex)
                            {

                                throw new Exception(ex.ToString());
                            }

                            break;

                        case DayOfWeek.Tuesday:
                            try
                            {
                                await AddAvailableTurns(weekplan.tuesdayFirstHour, weekplan.tuesdayLasttHour, date, planoption.TurnTimeGap, turnPool);
                            }
                            catch (Exception ex)
                            {

                                throw new Exception(ex.ToString());
                            }

                            break;

                        case DayOfWeek.Wednesday:
                            try
                            {
                                await AddAvailableTurns(weekplan.wednesdayFirstHour, weekplan.wednesdayLasttHour, date, planoption.TurnTimeGap, turnPool);
                            }
                            catch (Exception ex)
                            {

                                throw new Exception(ex.ToString());
                            }

                            break;

                        case DayOfWeek.Thursday:
                            try
                            {
                                await AddAvailableTurns(weekplan.thursdayFirstHour, weekplan.thursdayLasttHour, date, planoption.TurnTimeGap, turnPool);
                            }
                            catch (Exception ex)
                            {

                                throw new Exception(ex.ToString());
                            }

                            break;

                        case DayOfWeek.Friday:
                            try
                            {
                                await AddAvailableTurns(weekplan.fridayFirstHour, weekplan.fridayLasttHour, date, planoption.TurnTimeGap, turnPool);
                            }
                            catch (Exception ex)
                            {

                                throw new Exception(ex.ToString());
                            }

                            break;

                        default:
                            break;
                    }
                }

                return "Build Available Turns Successfully";
            }

            return "Not Found Office Work Plan";
        }

        public DateTime GetTurnTime(DateOnly day, EntityModel.Offices.OfficePlanOption opo)
        {
            var turnPool = _dbContext.turnPools.Include(a => a.AvailableTurns).FirstOrDefault(t => t.OfficePlanOptionId == opo.Id);

            var turns = turnPool.AvailableTurns.Where(a => a.AvailableTurnDate >= day).OrderBy(t => t.AvailableTurnTime).ToList();

            DateTime turnTime = turns[0].AvailableTurnDate.ToDateTime(turns[0].AvailableTurnTime);

            _dbContext.Remove(turns[0]);
            _dbContext.SaveChanges();

            return turnTime;
        }

        public bool isOpoExist(int id)
        {
            var pool = _dbContext.turnPools.FirstOrDefault(p => p.OfficePlanOptionId == id);

            if (pool == null)
            {
                return false;
            }

            return true;
        }

        public void Update(int id, EntityModel.Turns.TurnPool newTurnPool)
        {
            throw new NotImplementedException();
        }
        
        public void Delete(int id)
        {
            var pool = _dbContext.turnPools.FirstOrDefault(p => p.OfficePlanOptionId == id);

            _dbContext.turnPools.Remove(pool);
            _dbContext.SaveChanges();
        }
    }
}
