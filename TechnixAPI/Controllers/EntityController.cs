using Microsoft.AspNetCore.Mvc;
using TechnixAPI.Helper;
using TechnixAPI.Models;
using TechnixAPI.Service;

namespace TechnixAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : Controller
    {
        [HttpGet]
        public ActionResult<List<string>> GetEntityData()
        {
            List<string> entities = new List<string>();
            using (var context = new AppDbContext())
            {
                var entityNames = TechnixHelper.GetEntityNames(context);
                foreach (var name in entityNames)
                {
                    entities.Add(name);
                }
            }
            
            return entities;
        }
    }
}
