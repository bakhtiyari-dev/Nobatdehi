using EntityModel.Turns.Interfaces;
using DataAccessLayer;

namespace BusinessLogicLayer.BLTurns
{
    public class Turn:ITurn
    {
        DataAccessLayer.DLTurns.Turn _dlTurn;
        public Turn()
        {
            _dlTurn = new DataAccessLayer.DLTurns.Turn();
        }

        public void Create(EntityModel.Turns.Turn turn)
        {
            _dlTurn.Create(turn);
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
    }
}
