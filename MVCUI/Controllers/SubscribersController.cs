using Business.Abstract;
using Entities.DTOs.Subscriber;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Controllers
{
    public class SubscribersController : Controller
    {
        readonly ISubscriberService _subscriberService;

        public SubscribersController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        [HttpPost("[action]")]
        public IActionResult Subscribe([FromBody] SubscriberCreateDto subscriber)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _subscriberService.Add(subscriber);

            if (!result.Success) return BadRequest(result.Message);

            return Ok();
        }
    }
}
