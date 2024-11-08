using EntityModel.Plans;
using EntityModel.Turns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Offices
{
    [Table("OfficePlanOptions", Schema = "Option")]
    public class OfficePlanOption
    {
        public int Id { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        [Range(1, 99999)]
        public int Capacity { get; set; }
        public bool Status { get; set; }

        //Relations

        public Office Office { get; set; }
        public Plan Plan { get; set; }
        
    }
}
