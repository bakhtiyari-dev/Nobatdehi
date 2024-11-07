﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public int PlanOptionId { get; set; }
        public List<OfficePlanOption> OfficePlanOptions { get; set; }
    }
}
