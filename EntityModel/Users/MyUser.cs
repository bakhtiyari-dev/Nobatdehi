using EntityModel.Offices;
using Microsoft.AspNetCore.Identity;

namespace EntityModel.Users
{
    public class CostumIdentityUser : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public bool Status { get; set; }

        //Relations

        public int? OfficeId { get; set; }
        public Office? Office { get; set; }
    }
}
