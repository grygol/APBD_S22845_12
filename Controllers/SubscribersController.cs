using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using APBD12.DTOs;
using APBD12.Entities.Models;
using APBD12.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APBD12.Controllers
{
    [Route("api/[controller]")]
    public class SubscribersController : Controller
    {

        private readonly ISubscriberService _service;

        public SubscribersController(ISubscriberService service)
        {
            _service = service;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(SubscriberPost subsciber)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (!new EmailAddressAttribute().IsValid(subsciber.Address)) return BadRequest("Invalid address");

            var newSubscriber = new Subscriber
            {
                Name = subsciber.Name,
                Address = subsciber.Address,
                Status = "Unknown"
            };


            return Ok(await _service.CreateSubscriber(newSubscriber));
        }

    }
}

