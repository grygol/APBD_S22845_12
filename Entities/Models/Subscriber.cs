using System.Collections.Generic;

namespace APBD12.Entities.Models
{
    public class Subscriber
	{
        public int Id_subscriber { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
    }
}

