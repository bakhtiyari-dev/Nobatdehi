﻿using EntityModel.Turns.Interfaces;
using DataAccessLayer;

namespace BusinessLogicLayer.BLTurns
{
    public class Citizen:ICitizen
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
    }
}
