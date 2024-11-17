using EntityModel.Turns.Interfaces;

namespace BusinessLogicLayer.BLTurns
{
    public class Citizen : ICitizen
    {
        DataAccessLayer.DLTurns.Citizen _dlCitizen;
        public Citizen()
        {
            _dlCitizen = new DataAccessLayer.DLTurns.Citizen();
        }


        // BLL : Citizen


        public List<EntityModel.Turns.Citizen>? GetCitizensById(string id)
        {
            return _dlCitizen.GetCitizensById(id);
        }

        public List<EntityModel.Turns.Citizen>? GetAllCitizens()
        {
            return _dlCitizen.GetAllCitizens();
        }

        public EntityModel.Turns.Citizen? Get(int id)
        {
            return _dlCitizen.Get(id);
        }
    }
}
