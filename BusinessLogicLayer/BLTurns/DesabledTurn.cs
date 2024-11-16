using EntityModel.Turns.Interfaces;
using DataAccessLayer;

namespace BusinessLogicLayer.BLTurns
{
    public class DesabledTurn : IDesabledTurn
    {
        DataAccessLayer.DLTurns.DesabledTurn _dlTurn;
        public DesabledTurn()
        {
            _dlTurn = new DataAccessLayer.DLTurns.DesabledTurn();
        }

        public void Create(EntityModel.Turns.DesabledTurn desabledTurn)
        {
            _dlTurn.Create(desabledTurn);
        }

        public void Delete(int id)
        {
            _dlTurn.Delete(id);
        }

        public List<EntityModel.Turns.DesabledTurn> GetAll(int officeId, int planId)
        {
            throw new NotImplementedException();
        }

        public EntityModel.Turns.DesabledTurn? GetDesabledTurnsByDate(int officeId, int planId, DateOnly day)
        {
            return _dlTurn.GetDesabledTurnsByDate(officeId, planId, day);
        }
    }
}
