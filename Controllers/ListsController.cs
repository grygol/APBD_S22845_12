using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD12.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APBD12.Controllers
{
    [Route("api/[controller]")]
    public class ListsController : Controller
    {

        private readonly IListService _listService;

        public ListsController(IListService listService)
        {
            _listService = listService;
        }

        //// GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var res = await _listService.GetList(id)
                .Select(e => new
                {
                    Id_list = e.Id_list,
                    Name = e.Name,
                    Address = e.Address,
                    Created_at = e.Created_at,
                    Description = e.Description,
                    Members = e.Memberships.Select(e => new
                    {
                        Name = e.Subscriber.Name,
                        Address = e.Subscriber.Address,
                        Subscriber_status = e.Subscriber.Status,
                        Membership_status = e.Status,
                        Added_at = e.Added_at
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (res is null) return NotFound();
            return Ok(res);
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

