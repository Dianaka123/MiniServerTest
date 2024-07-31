using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace MiniServerTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventStreamController : ControllerBase
    {
        public class EventsSendModel
        {
            [JsonPropertyName("events")]
            public List<EventInfo> Events { get; set; }
        }

        public class EventInfo
        {
            [JsonPropertyName("type")]
            public string EventType { get; set; }

            [JsonPropertyName("data")]
            public string Data { get; set; }
        }

        private ILogger<EventStreamController> _logger;

        public EventStreamController(ILogger<EventStreamController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "save_events")]
        public IActionResult SaveEvents([FromBody]EventsSendModel eventsSendModel)
        {
            foreach(EventInfo e in eventsSendModel.Events)
            {
                _logger.LogInformation($"{e.EventType} : {e.Data}");
            }
            return Ok();
        }
    }
}
