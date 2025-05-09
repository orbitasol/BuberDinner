using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        // Log the exception (not implemented here for brevity)
        // You can use a logging library like Serilog, NLog, etc.

        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Title = "An error occurred while processing your request.",
            Status = StatusCodes.Status500InternalServerError,
            Detail = exception.Message,
            Instance = context.HttpContext.Request.Path
        };

        // Set the result to a generic error response
        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true; // Mark the exception as handled
    }
}
