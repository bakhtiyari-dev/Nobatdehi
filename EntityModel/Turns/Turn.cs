using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Turns
{
    public class Turn
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CitizenIdType { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime TurnTime { get; set; }
        public bool Status { get; set; }

        public int CitizenId { get; set; }
        public int OfficeId { get; set; }
        public int PlanId { get; set; }
    }
}
