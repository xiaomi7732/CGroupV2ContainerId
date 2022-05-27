using CodeWithSaar.ContainerId.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.TryAddContainerIdServices();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
