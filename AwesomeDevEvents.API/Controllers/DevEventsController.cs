using AwesomeDevEvents.API.Entities;
using AwesomeDevEvents.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeDevEvents.API.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;
        public DevEventsController(DevEventsDbContext context) 
        {
            _context = context; 
        }
        // api-dev-events GET
        [HttpGet]
        public IActionResult GetAll()
        { 
            var devEvents = _context.DevEvents.Where(d => !d.IsDeleted).ToList();
            return Ok(devEvents);
        }
        // api-dev-events/4234342 GET
        [HttpGet("{id}")]
        public IActionResult GetById( Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id); 
            if (devEvent == null)
            {
                return NotFound();
            }
            return Ok(devEvent);    
        }
        // api-dev-events/ POST
        [HttpPost]
        public IActionResult Post(DevEvent devEvent)
        {
            _context.DevEvents.Add(devEvent);
            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }
        // api-dev-events/123233 PUT
        [HttpPut ("{id}")]
        public IActionResult Update(Guid id, DevEvent input)
        {

            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);
            if (devEvent == null)
            {
                return NotFound();
            }
            devEvent.Update(input.Title, input.Description, input.StartDate, input.EndDate);
            return NoContent();

        }
        // api-dev-events/5435435435 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);
            if (devEvent == null)
            {
                return NotFound();
            }
            devEvent.Delete();  
            return NoContent();
        }
        // api-dev-events/4543535/speakers
        [HttpPost("{id}/speakers")]
        public IActionResult PostSpeaker(Guid id, DevEventSpeaker speaker)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);
            if (devEvent == null)
            {
                return NotFound();
            }
            devEvent.Speakers.Add(speaker);
            return NoContent();
        }
    }
}
