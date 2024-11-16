using EntityModel.Offices;

namespace EntityModel.Turns.Interfaces
{
    public interface ITurn
    {
        public void Create(Turn turn, OfficePlanOption officePlan);
        public void Delete(int id);
        public List<Turn>? GetAll();
        public Turn? Get(int id);
        public bool IsCitizenExist(int citizenId, int planId);
        public bool CheckCitizenHasDependencies(int citizen, int planId);
        //public bool CheckTurnBeforDelete(int citizenId, int planId, int turnId);
    }
}
