namespace EntityModel.Turns.Interfaces
{
    public interface IDesabledTurn
    {
        public void Create(DesabledTurn desabledTurn);
        public void Delete(int id);
        public List<DesabledTurn> GetAll(int officeId, int planId);
        public TimeOnly GetDesabledTurnsByDate(int officeId, int planId, DateOnly day);
    }
}
