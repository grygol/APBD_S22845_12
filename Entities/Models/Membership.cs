using System;
namespace APBD12.Entities.Models
{
	public class Membership
	{
        public int Id_list { get; set; }
        public int Id_subscriber { get; set; }
        public string Status { get; set; }
        public DateTime Added_at { get; set; }

        public virtual List List { get; set; }
        public virtual Subscriber Subscriber { get; set; }

    }
}

