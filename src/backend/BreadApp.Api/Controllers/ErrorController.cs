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

        [Route("/error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}