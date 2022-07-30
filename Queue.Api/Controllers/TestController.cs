using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Queue.Api.Queues;

namespace Queue.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IBackgroundTaskQueue<string> queue;

    public TestController(IBackgroundTaskQueue<string> queue)
    {
        this.queue = queue;
    }


    [HttpPost]
    public async Task<IActionResult> AddQueue(string[] names)
    {
        foreach (var name in names)
        {
            await queue.AddQueue(name);
        }

        return Ok();
    }
}
