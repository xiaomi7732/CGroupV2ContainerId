using CodeWithSaar.ContainerId.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddSimpleConsole(opt =>
        {
            opt.SingleLine = true;
        });
    })
    .ConfigureServices(services =>
    {
        services.TryAddContainerIdServices();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
