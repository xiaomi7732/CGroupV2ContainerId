using CodeWithSaar.Extensions.ContainerId;

namespace CodeWithSaar.ContainerId.Worker;

public class Worker : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<Worker> _logger;

    public Worker(
        IServiceScopeFactory serviceScopeFactory,
        ILogger<Worker> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                IContainerService containerService = scope.ServiceProvider.GetRequiredService<IContainerService>();
                _logger.LogInformation("Container Id: {containerId}. Wait for 10 seconds.", await containerService.GetContainerIdAsync());
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
