using Microsoft.AspNetCore.Mvc;

namespace RestaurantApiV2.WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {

    }
}
