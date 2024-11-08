namespace EntityModel.Turns.Interfaces
{
    public interface IAvailableTurn
    {
        public void Create(AvailableTurn availableTurn);
        public void Delete(DateOnly Day, TimeOnly Hour);
        public List<AvailableTurn> GetAvailableTurns(int officeId, int planId);
        public TimeOnly GetAvailableTurnsByDate(int officeId, int planId, DateOnly day);
    }
}
