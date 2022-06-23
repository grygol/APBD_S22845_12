using System;
using System.Linq;
using APBD12.Entities.Models;

namespace APBD12.Services
{
	public interface IListService
	{
		public IQueryable<List> GetList(int id);
	}
}

