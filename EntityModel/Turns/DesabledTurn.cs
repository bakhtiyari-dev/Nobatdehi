﻿using EntityModel.Offices;
using EntityModel.Plans;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Turns
{
    [Table("DesableTurns", Schema = "Turn")]
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
