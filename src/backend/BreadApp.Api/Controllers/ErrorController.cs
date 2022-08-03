using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BreadApp.Api.Controllers
{
    public class ErrorController : ControllerBase
    {

        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error()
        {
            Exception ex = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            _logger.LogCritical(ex, ex.Message);

            return Problem();
        }
    }
}