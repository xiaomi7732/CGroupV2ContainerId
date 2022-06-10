# Use it with dependency injection

1. Add NuGet package

    ```shell
    dotnet add package CodeWithSaar.Extensions.ContainerId --prerelease
    ```

2. Register the services:

    ```csharp
    // TryAddContainerIdServices is an extension method provided in CodeWithSaar.Extensions.ContainerId.
    services.TryAddContainerIdServices();
    ```

3. Inject it and use the service:

    ```csharp
    class Consumer
    {
        private readonly ILogger _logger;
        private readonly IContainerService _containerService;

        // Inject containerIdService and logger in ctor
        public Consumer(IContainerService containerService, ILogger<Consumer> logger)
        {
            _loggr = logger ?? throw new ArgumentNullException(nameof(logger));
            _containerService = containerService ?? throw new ArgumentNullException(nameof(containerService));
        }

        public async Task ShowContainerIdAsync()
        {
            // Get container id & log it.
            _logger.LogInformation(await _containerService.GetContainerIdAsync());
        }
    }
    ```

