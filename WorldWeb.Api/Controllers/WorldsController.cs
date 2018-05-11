namespace WorldWeb.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WorldWeb.Core.Repositories;

    [Produces("application/json")]
    [Route("api/Worlds")]
    public class WorldsController : Controller
    {
        private IWorldRepository worldRepository;

        public WorldsController(IWorldRepository worldRepository)
        {
            this.worldRepository = worldRepository;
        }

        public IActionResult Get()
        {
            var result = this.worldRepository.Get();
            return Ok(result.Resource);
        }
    }
}
