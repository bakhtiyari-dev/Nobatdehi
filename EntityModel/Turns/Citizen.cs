using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Turns
{
    [Table("Citizens", Schema = "Member")]
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

        //Relations

        public List<Turn> Turns { get; set; }
    }
}
