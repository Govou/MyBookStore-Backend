using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly ICommandHandler<CreatePublisherCommand> _createPublisherCommandHandler;
        private readonly ICommandHandler<UpdatePublisherCommand> _updatePublisherCommandHandler;
        private readonly IPublisherQueries _publisherQueries;

        public PublisherController(ICommandHandler<CreatePublisherCommand> createPublisherCommandHandler,
            ICommandHandler<UpdatePublisherCommand> updatePublisherCommandHandler,
            IPublisherQueries publisherQueries)
        {
            _createPublisherCommandHandler = createPublisherCommandHandler;
            _updatePublisherCommandHandler = updatePublisherCommandHandler;
            _publisherQueries = publisherQueries;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_publisherQueries.GetAllAsync().Result);
        }

        [HttpPost]
        public IActionResult Post(CreatePublisherCommand command)
        {
            var result = _createPublisherCommandHandler.Handle(command);
            if (result.Success)
                return Ok(command);

            return BadRequest(result.Errors);
        }

        [HttpPut]
        public IActionResult Put(UpdatePublisherCommand command)
        {
            var result = _updatePublisherCommandHandler.Handle(command);
            if (result.Success)
                return Ok(command);

            return BadRequest(result.Errors);
        }
    }
}
