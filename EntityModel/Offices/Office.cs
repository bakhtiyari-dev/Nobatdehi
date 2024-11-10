using EntityModel.Turns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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

        public List<Turn> Turns { get; set; }
        public List<OfficePlanOption> OfficePlanOptions { get; set; }

        [MaybeNull]
        public List<string> UsersID { get; set; }
        public List<DesabledTurn> DesabledTurns { get; set; }
    }
}
