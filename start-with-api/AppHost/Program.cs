var builder = DistributedApplication.CreateBuilder(args);

//myCache

var myCache = builder.AddRedis("cache")
    .WithImageRegistry("ghcr.io")
    .WithImage("microsoft/garnet")
    .WithImageTag("latest");

var api = builder.AddProject<Projects.Api>("api")
                 .WithReference(myCache);

var web = builder.AddProject<Projects.MyWeatherHub>("myweatherhub")
    .WithReference(api)
    .WithExternalHttpEndpoints();

builder.Build().Run();
