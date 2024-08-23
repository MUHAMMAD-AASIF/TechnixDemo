using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnixDemo.Model;

namespace TechnixDemo.Templates
{
    public class ApiGenerator
    {
        public ApiGenerator()
        {

        }

        public string GenerateController(EntitySelectModel entity, string projectName)
        {
            var controllerCode = new StringBuilder();

            controllerCode.AppendLine("using Microsoft.AspNetCore.Mvc;");
            controllerCode.AppendLine($"using {projectName}.Services;");
            controllerCode.AppendLine($"using {projectName}.Models;");
            controllerCode.AppendLine();
            controllerCode.AppendLine($"namespace {projectName}.Controllers");
            controllerCode.AppendLine("{");
            controllerCode.AppendLine($"    [ApiController]");
            controllerCode.AppendLine($"    [Route(\"api/[controller]\")]");
            controllerCode.AppendLine($"    public class {entity.Entity}Controller : ControllerBase");
            controllerCode.AppendLine("    {");
            controllerCode.AppendLine($"        private readonly I{entity.Entity}Service _{entity.Entity.ToLower()}Service;");
            controllerCode.AppendLine();
            controllerCode.AppendLine($"        public {entity.Entity}Controller(I{entity.Entity}Service {entity.Entity.ToLower()}Service)");
            controllerCode.AppendLine("        {");
            controllerCode.AppendLine($"            _{entity.Entity.ToLower()}Service = {entity.Entity.ToLower()}Service;");
            controllerCode.AppendLine("        }");
            controllerCode.AppendLine();

            if (entity.GetAll)
            {
                controllerCode.AppendLine("        [HttpGet]");
                controllerCode.AppendLine($"        public IActionResult GetAll{entity.Entity}()");
                controllerCode.AppendLine("        {");
                controllerCode.AppendLine($"            var result = _{entity.Entity.ToLower()}Service.GetAll();");
                controllerCode.AppendLine("            return Ok(result);");
                controllerCode.AppendLine("        }");
                controllerCode.AppendLine();
            }

            if (entity.GetById)
            {
                controllerCode.AppendLine("        [HttpGet(\"{id}\")]");
                controllerCode.AppendLine($"        public IActionResult Get{entity.Entity}ById(int id)");
                controllerCode.AppendLine("        {");
                controllerCode.AppendLine($"            var result = _{entity.Entity.ToLower()}Service.GetById(id);");
                controllerCode.AppendLine("            if (result == null)");
                controllerCode.AppendLine("            {");
                controllerCode.AppendLine("                return NotFound();");
                controllerCode.AppendLine("            }");
                controllerCode.AppendLine("            return Ok(result);");
                controllerCode.AppendLine("        }");
                controllerCode.AppendLine();
            }

            if (entity.Save)
            {
                controllerCode.AppendLine("        [HttpPost]");
                controllerCode.AppendLine($"        public IActionResult Save{entity.Entity}([FromBody] {entity.Entity}Model model)");
                controllerCode.AppendLine("        {");
                controllerCode.AppendLine($"            if (model == null)");
                controllerCode.AppendLine("            {");
                controllerCode.AppendLine("                return BadRequest();");
                controllerCode.AppendLine("            }");
                controllerCode.AppendLine();
                controllerCode.AppendLine($"            var createdEntity = _{entity.Entity.ToLower()}Service.Save(model);");
                controllerCode.AppendLine("            return CreatedAtAction(nameof(GetById), new { id = createdEntity.Id }, createdEntity);");
                controllerCode.AppendLine("        }");
                controllerCode.AppendLine();
            }

            if (entity.Update)
            {
                controllerCode.AppendLine("        [HttpPut(\"{id}\")]");
                controllerCode.AppendLine($"        public IActionResult Update{entity.Entity}(int id, [FromBody] {entity.Entity}Model model)");
                controllerCode.AppendLine("        {");
                controllerCode.AppendLine("            if (model == null || id != model.Id)");
                controllerCode.AppendLine("            {");
                controllerCode.AppendLine("                return BadRequest();");
                controllerCode.AppendLine("            }");
                controllerCode.AppendLine();
                controllerCode.AppendLine($"            var updated = _{entity.Entity.ToLower()}Service.Update(id, model);");
                controllerCode.AppendLine("            if (!updated)");
                controllerCode.AppendLine("            {");
                controllerCode.AppendLine("                return NotFound();");
                controllerCode.AppendLine("            }");
                controllerCode.AppendLine("            return NoContent();");
                controllerCode.AppendLine("        }");
                controllerCode.AppendLine();
            }

            if (entity.Delete)
            {
                controllerCode.AppendLine("        [HttpDelete(\"{id}\")]");
                controllerCode.AppendLine($"        public IActionResult Delete{entity.Entity}(int id)");
                controllerCode.AppendLine("        {");
                controllerCode.AppendLine($"            var deleted = _{entity.Entity.ToLower()}Service.Delete(id);");
                controllerCode.AppendLine("            if (!deleted)");
                controllerCode.AppendLine("            {");
                controllerCode.AppendLine("                return NotFound();");
                controllerCode.AppendLine("            }");
                controllerCode.AppendLine("            return NoContent();");
                controllerCode.AppendLine("        }");
                controllerCode.AppendLine();
            }

            controllerCode.AppendLine("    }");
            controllerCode.AppendLine("}");

            return controllerCode.ToString();
        }

    }
}
