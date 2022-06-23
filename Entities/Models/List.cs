using System;
using System.Collections.Generic;

namespace APBD12.Entities.Models
{
	public class List
	{
        public int Id_list { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Created_at { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
    }
}

