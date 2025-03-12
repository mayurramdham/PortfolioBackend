using App.Core.Apps.Contact.Command;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] ContactDto contactDto)
        {
            var contactInfo=await _mediator.Send(new AddContactCommand { contactDto=contactDto });
            if (!ModelState.IsValid)
            {
                // If the model is invalid (e.g., invalid email), return 400 with validation errors
                return BadRequest(ModelState);
            }
            return Ok(contactInfo);
            
        }
    }
}
