using Fuelex_Backend.Services.Queue;
using Microsoft.AspNetCore.Mvc;

namespace Fuelex_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService queueService;

        public QueueController(IQueueService queueService)
        {
            this.queueService = queueService;
        }
    }
}
