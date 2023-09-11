using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMonolegal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerBaseApi : ControllerBase
    {
        private IMediator _mediator;
        
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

    }
}