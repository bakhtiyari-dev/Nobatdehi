using EntityModel.Turns.Interfaces;
using DataAccessLayer;
using EntityModel.Offices;

namespace BusinessLogicLayer.BLTurns
{
    public class Turn:ITurn
    {
        DataAccessLayer.DLTurns.Turn _dlTurn;
        public Turn()
        {
            _dlTurn = new DataAccessLayer.DLTurns.Turn();
        }

        public bool CheckCitizenHasDependencies(int citizen, int planId)
        {
            return _dlTurn.CheckCitizenHasDependencies(citizen, planId);
        }

        public bool CheckTurnBeforDelete(int citizenId, int planId)
        {
            throw new NotImplementedException();
        }

        public void Create(EntityModel.Turns.Turn turn, OfficePlanOption officePlan)
        {
            _dlTurn.Create(turn, officePlan);
        }

        public void Delete(int id)
        {
            _dlTurn.Delete(id);
        }

        public EntityModel.Turns.Turn? Get(int id)
        {
            return _dlTurn.Get(id);
        }

        public List<EntityModel.Turns.Turn>? GetAll()
        {
            return _dlTurn.GetAll();
        }

        public bool IsCitizenExist(int citizenId, int planId)
        {
            return _dlTurn.IsCitizenExist(citizenId, planId);
        }
    }
}
