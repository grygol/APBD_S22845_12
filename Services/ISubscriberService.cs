using System;
using System.Threading.Tasks;
using APBD12.Entities.Models;

namespace APBD12.Services
{
	public interface ISubscriberService
	{
		Task<Subscriber> CreateSubscriber(Subscriber subscriber); 
	}
}

