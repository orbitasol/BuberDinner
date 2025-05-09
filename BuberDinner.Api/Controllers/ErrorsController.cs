using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("/error")]
[ApiController]
public class ErrorsController : ControllerBase
{
    public IActionResult Error()
    {
        //Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Problem();
    }
}
