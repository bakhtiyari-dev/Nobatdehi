using EntityModel.Offices;
using EntityModel.Plans;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Turns
{
    [Table("Turns", Schema = "Turn")]
    public class Turn
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CitizenIdType { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime TurnTime { get; set; }
        public bool Status { get; set; }

        //Relations
        
        public Citizen Citizen { get; set; }
        public Office Office { get; set; }
        public Plan Plan { get; set; }
 
    }
}
