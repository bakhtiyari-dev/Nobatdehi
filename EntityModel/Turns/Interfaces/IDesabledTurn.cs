namespace EntityModel.Turns.Interfaces
{
    public interface IDesabledTurn
    {
        public void Create(DesabledTurn desabledTurn);
        public void Delete(int id);
        public List<DesabledTurn> GetAll(int officeId, int planId);
        public DesabledTurn? GetDesabledTurnsByDate(int officeId, int planId, DateOnly day);
    }
}
