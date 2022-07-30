using Microsoft.Extensions.Hosting;
using Queue.Api.Queues;
using System.Xml.Linq;

namespace Queue.Api;

public class QueueHostedService : BackgroundService
{
    private readonly ILogger<QueueHostedService> logger;
    private readonly IBackgroundTaskQueue<string> queue;

    public QueueHostedService(ILogger<QueueHostedService> logger, IBackgroundTaskQueue<string> queue)
    {
        this.logger = logger;
        this.queue = queue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var name = await queue.DeQueue(stoppingToken);

            //await Task.Delay(1000); // db insert

            logger.LogInformation($"ExecuteAsync worked for {name}");
        }
    }
}
