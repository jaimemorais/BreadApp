using BreadApp.Application.Common.Interfaces.Email;
using BreadApp.Infrastructure.Email;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(BreadApp.Azure.Function.SendMail.Startup))]

namespace BreadApp.Azure.Function.SendMail
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IEmailSenderService, SendgridMailService>();
        }
    }
}