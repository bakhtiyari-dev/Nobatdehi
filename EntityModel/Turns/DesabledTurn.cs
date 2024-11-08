using EntityModel.Offices;
using EntityModel.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Turns
{
    public class DesabledTurn
    {
        public int Id { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly Hour { get; set; }

        //Relations

        public Plan Plan { get; set; }
        public Office Office { get; set; }
    }
}
