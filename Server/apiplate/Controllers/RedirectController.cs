using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace apiplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedirectController : ControllerBase {
        private readonly IConfiguration _configuration;

        public RedirectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult  Get(){
            var clientBaseUrl = _configuration.GetValue<string>("clientBaseUrl");
            return Redirect(clientBaseUrl);
        }
    }
}