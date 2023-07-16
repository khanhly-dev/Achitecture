using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Achitecture.Api.Controllers
{
    [ApiController]
    //[ApiExceptionFilter]
    [Route("api/[controller]")]
    public abstract class ApplicationControllerBase : Controller
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
