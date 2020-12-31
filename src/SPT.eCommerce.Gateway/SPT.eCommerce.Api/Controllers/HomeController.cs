using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SPT.eCommerce.Api.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Home Controller constructor
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// API Home page to display our API project is running
        /// </summary>
        /// <returns>Returns message and swagger documentation url</returns>
        [HttpGet("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Get()
        {
            _logger.LogInformation("Sharp Programmer Tutorials - eCommerce Gateway api is running!");

            return Ok(new {
                message = "Sharp Programmer Tutorials - eCommerce Sample project is running!",
                tryIt = $"{Request.Scheme}://{Request.Host}/docs/index.html"
            }); ;
        }
    }
}
