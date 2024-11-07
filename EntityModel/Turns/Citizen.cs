using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Turns
{
    public class Citizen
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public string ExclusiveCode { get; set; }
        public string HouseholdCode { get; set; }
        public string UniqCode { get; set; }
    }
}
