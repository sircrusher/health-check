using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheck.Controllers
{
    [Route("status")]
    public class MainController : BaseController
    {
        [AllowAnonymous]
        [Route("")]
        [HttpGet]
        public async Task<ObjectResult> Status()
        {
            return new OkObjectResult(new
            {
                Location = AppConfig.Configuration["Location"],
                IpAddress = AppConfig.Configuration["IpAddress"]
            });
        }
    }
}