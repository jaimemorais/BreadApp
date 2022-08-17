using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BreadApp.Api.Controllers
{

    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count == 0)
            {
                return Problem();
            }

            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                var modelStateDict = new ModelStateDictionary();
                errors.ForEach(e => { modelStateDict.AddModelError(e.Code, e.Description); });
                return ValidationProblem(modelStateDict);
            }

            HttpContext.Items["errors"] = errors;

            return BreadAppApiProblem(errors[0]);
        }


        private IActionResult BreadAppApiProblem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: error.Description);
        }

    }
}
