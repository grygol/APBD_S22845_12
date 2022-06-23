using System;
using System.Threading.Tasks;
using APBD12.Entities;
using APBD12.Entities.Models;

namespace APBD12.Services
{
    public class SubscriberService : ISubscriberService
    {

        private readonly DatabaseContext _context;

        public SubscriberService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Subscriber> CreateSubscriber(Subscriber subscriber)
        {
            var res = await _context.Subscribers.AddAsync(subscriber);
            await _context.SaveChangesAsync();

            return res.Entity;
        }
    }
}

