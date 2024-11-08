namespace EntityModel.Turns.Interfaces
{
    public interface ITurnPool
    {
        public void Create(TurnPool turnPool);
        public void Update(int id, TurnPool newTurnPool);
        public void Delete(int id);
    }
}
