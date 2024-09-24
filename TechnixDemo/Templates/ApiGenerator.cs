using System.Text;
using TechnixDemo.Model;

namespace TechnixDemo.Templates
{
    public class ApiGenerator
    {
        public string GenerateController(EntitySelectModel entity, string projectName)
        {
            var controllerCode = new StringBuilder();

            controllerCode.AppendLine("using Microsoft.AspNetCore.Mvc;");
            controllerCode.AppendLine($"using Msc.{projectName}.Service.Business.Contracts;");
            controllerCode.AppendLine($"using Msc.{projectName}.Service.CommonModel;");
            controllerCode.AppendLine();
            controllerCode.AppendLine($"namespace Msc.{projectName}.Service.Controllers");
            controllerCode.AppendLine("{");
            controllerCode.AppendLine("\t[ApiController]");
            controllerCode.AppendLine($"\t[Route(\"v1/{entity.Entity}\")]");
            controllerCode.AppendLine($"\tpublic class {entity.Entity}Controller : ControllerBase");
            controllerCode.AppendLine("\t{");
            controllerCode.AppendLine($"\t\tprivate readonly I{entity.Entity}Service _{entity.Entity.ToLower()}Service;");
            controllerCode.AppendLine();
            controllerCode.AppendLine($"\t\tpublic {entity.Entity}Controller(I{entity.Entity}Service {entity.Entity.ToLower()}Service)");
            controllerCode.AppendLine("\t\t{");
            controllerCode.AppendLine($"\t\t\t_{entity.Entity.ToLower()}Service = {entity.Entity.ToLower()}Service;");
            controllerCode.AppendLine("\t\t}");
            controllerCode.AppendLine();

            if (entity.GetAll)
            {
                controllerCode.AppendLine("\t\t[HttpGet]");
                controllerCode.AppendLine($"\t\tpublic IActionResult GetAll{entity.Entity}()");
                controllerCode.AppendLine("\t\t{");
                controllerCode.AppendLine($"\t\t\tvar result = _{entity.Entity.ToLower()}Service.GetAll();");
                controllerCode.AppendLine("\t\t\treturn Ok(result);");
                controllerCode.AppendLine("\t\t}");
                controllerCode.AppendLine();
            }

            if (entity.GetById)
            {
                controllerCode.AppendLine("\t\t[HttpGet(\"{id}\")]");
                controllerCode.AppendLine($"\t\tpublic IActionResult Get{entity.Entity}ById(int id)");
                controllerCode.AppendLine("\t\t{");
                controllerCode.AppendLine($"\t\t\tvar result = _{entity.Entity.ToLower()}Service.GetById(id);");
                controllerCode.AppendLine("\t\t\tif (result == null)");
                controllerCode.AppendLine("\t\t\t{");
                controllerCode.AppendLine("\t\t\t\treturn NotFound();");
                controllerCode.AppendLine("\t\t\t}");
                controllerCode.AppendLine("\t\t\treturn Ok(result);");
                controllerCode.AppendLine("\t\t}");
                controllerCode.AppendLine();
            }

            if (entity.Save)
            {
                controllerCode.AppendLine("\t\t[HttpPost]");
                controllerCode.AppendLine($"\t\tpublic IActionResult Save{entity.Entity}([FromBody] {entity.Entity} model)");
                controllerCode.AppendLine("\t\t{");
                controllerCode.AppendLine("\t\t\tif (model == null)");
                controllerCode.AppendLine("\t\t\t{");
                controllerCode.AppendLine("\t\t\t\treturn BadRequest();");
                controllerCode.AppendLine("\t\t\t}");
                controllerCode.AppendLine();
                controllerCode.AppendLine($"\t\t\tvar createdEntity = _{entity.Entity.ToLower()}Service.Save(model);");
                controllerCode.AppendLine("\t\t\treturn StatusCode(200);");
                controllerCode.AppendLine("\t\t}");
                controllerCode.AppendLine();
            }

            if (entity.Update)
            {
                controllerCode.AppendLine("\t\t[HttpPut(\"\")]");
                controllerCode.AppendLine($"\t\tpublic IActionResult Update{entity.Entity}([FromBody] {entity.Entity} model)");
                controllerCode.AppendLine("\t\t{");
                controllerCode.AppendLine("\t\t\tif (model == null)");
                controllerCode.AppendLine("\t\t\t{");
                controllerCode.AppendLine("\t\t\t\treturn BadRequest();");
                controllerCode.AppendLine("\t\t\t}");
                controllerCode.AppendLine();
                controllerCode.AppendLine($"\t\t\tvar updated = _{entity.Entity.ToLower()}Service.Update(model);");
                controllerCode.AppendLine("\t\t\tif (!updated)");
                controllerCode.AppendLine("\t\t\t{");
                controllerCode.AppendLine("\t\t\t\treturn NotFound();");
                controllerCode.AppendLine("\t\t\t}");
                controllerCode.AppendLine("\t\t\treturn StatusCode(200);");
                controllerCode.AppendLine("\t\t}");
                controllerCode.AppendLine();
            }

            if (entity.Delete)
            {
                controllerCode.AppendLine("\t\t[HttpDelete(\"{id}\")]");
                controllerCode.AppendLine($"\t\tpublic IActionResult Delete{entity.Entity}(int id)");
                controllerCode.AppendLine("\t\t{");
                controllerCode.AppendLine($"\t\t\tvar deleted = _{entity.Entity.ToLower()}Service.Delete(id);");
                controllerCode.AppendLine("\t\t\tif (!deleted)");
                controllerCode.AppendLine("\t\t\t{");
                controllerCode.AppendLine("\t\t\t\treturn NotFound();");
                controllerCode.AppendLine("\t\t\t}");
                controllerCode.AppendLine("\t\t\treturn StatusCode(200);");
                controllerCode.AppendLine("\t\t}");
                controllerCode.AppendLine();
            }

            controllerCode.AppendLine("\t}");
            controllerCode.AppendLine("}");

            return controllerCode.ToString();
        }

    }
}
