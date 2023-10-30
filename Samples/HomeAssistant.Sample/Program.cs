﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sholo.HomeAssistant;
using Sholo.HomeAssistant.Mqtt;

await Host.CreateDefaultBuilder(args)
    .ConfigureLogging(lb =>
    {
        lb.AddSimpleConsole(opt =>
        {
            opt.SingleLine = true;
        });
    })
    .ConfigureServices((ctx, services) =>
    {
        services.AddHomeAssistant(ctx.Configuration.GetSection("homeassistant")).AddMqtt(_ => { });
    })
    .UseConsoleLifetime(opt =>
    {
        opt.SuppressStatusMessages = true;
    })
    .Build()
    .RunAsync();
