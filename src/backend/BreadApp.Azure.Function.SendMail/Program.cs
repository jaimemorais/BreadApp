using BreadApp.Application.Common.Interfaces.Email;
using BreadApp.Infrastructure.Email;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(s =>
    {
        s.AddSingleton<IEmailSenderService, SendgridMailService>();
    })
            .Build();

host.Run();



