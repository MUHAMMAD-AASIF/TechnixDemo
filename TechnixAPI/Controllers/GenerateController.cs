using Microsoft.AspNetCore.Mvc;

using TechnixAPI.Service;
using TechnixModel;

namespace TechnixAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateController : Controller
    {
        [HttpPost]
        public ActionResult<bool> PostGenerateController(GenerateModel Entity)
        {
            GenerateService service = new GenerateService();
            var dfd= service.GenerateFile(Entity);
            return Ok(dfd);
        }
    }
}
