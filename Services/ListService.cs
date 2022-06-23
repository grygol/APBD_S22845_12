using System;
using System.Linq;
using APBD12.Entities;
using APBD12.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD12.Services
{
    public class ListService : IListService
    {
        private readonly DatabaseContext _context;

        public ListService(DatabaseContext context)
        {
            _context = context;
        }


        public IQueryable<List> GetList(int id)
        {
            return _context.Lists
                .Where(e => e.Id_list == id)
                .Include(e => e.Memberships)
                .ThenInclude(e => e.Subscriber);
        }
    }
}

