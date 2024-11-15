using EntityModel.Turns;
using EntityModel.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Offices
{
    [Table("Offices", Schema = "Office")]
    public class Office
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(13)]
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }

        //Relations

        public List<Turn> Turns { get; set; } = new List<Turn>();
        public List<OfficePlanOption> OfficePlanOptions { get; set; } = new List<OfficePlanOption>();
        public List<CostumIdentityUser> Users { get; set; } = new List<CostumIdentityUser>();
        public List<DesabledTurn> DesabledTurns { get; set; } = new List<DesabledTurn>();
    }
}
