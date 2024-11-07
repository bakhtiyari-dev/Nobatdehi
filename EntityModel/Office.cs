using System.Security.Principal;

namespace EntityModel
{
    public class Office
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        public List<OfficePlanOption> OfficePlanOptions { get; set; }
        public List<string> Users { get; set; }
    }
}
