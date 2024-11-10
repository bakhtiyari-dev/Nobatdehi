using EntityModel.Turns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Offices
{
    [Table("Offices", Schema = "Office")]
    public class Office
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        //Relations

        public List<Turn> Turns { get; set; }
        public List<OfficePlanOption> OfficePlanOptions { get; set; }
        public List<string> UsersID { get; set; }
        public List<DesabledTurn> DesabledTurns { get; set; }
    }
}
