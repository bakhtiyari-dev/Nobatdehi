using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EntityModel.Turns
{
    [Table("Citizens", Schema = "Member")]
    public class Citizen
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength (20)]
        public string Nationality { get; set; }
        [MaxLength(9)]
        [MinLength(6)]
        public string Passport { get; set; }
        [Length(12,12)]
        public string ExclusiveCode { get; set; }
        [Length (10,10)]
        public string HouseholdCode { get; set; }
        [Length(10,10)]
        public string UniqCode { get; set; }

        //Relations

        public List<Turn> Turns { get; set; }
    }
}
