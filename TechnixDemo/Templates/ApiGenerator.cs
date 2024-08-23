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

        public string GenerateController(EntitySelectModel entity,string ProjectName)
        {
            var controllerCode = new StringBuilder();

            controllerCode.AppendLine("using Microsoft.AspNetCore.Mvc;");
            controllerCode.AppendLine($"namespace {ProjectName}.Controllers");
            controllerCode.AppendLine("{");
            controllerCode.AppendLine($"    public class {entity.Entity}Controller : ControllerBase");
            controllerCode.AppendLine("    {");

            if (entity.GetAll)
            {
                controllerCode.AppendLine($"        [HttpGet]");
                controllerCode.AppendLine($"        public IActionResult GetAll{entity.Entity}()");
                controllerCode.AppendLine("        {");
                controllerCode.AppendLine("            // Add logic to get all records");
                controllerCode.AppendLine("            return Ok();");
                controllerCode.AppendLine("        }");
            }

            if (entity.GetById)
            {
                controllerCode.AppendLine($"        [HttpGet(\"{{id}}\")]");
                controllerCode.AppendLine($"        public IActionResult Get{entity.Entity}ById(int id)");
                controllerCode.AppendLine("        {");
                controllerCode.AppendLine("            // Add logic to get a record by ID");
                controllerCode.AppendLine("            return Ok();");
                controllerCode.AppendLine("        }");
            }

            if (entity.Save)
            {
                controllerCode.AppendLine($"        [HttpPost]");
                controllerCode.AppendLine($"        public IActionResult Save{entity.Entity}([FromBody] {entity.Entity}Model model)");
                controllerCode.AppendLine("        {");
                controllerCode.AppendLine("            // Add logic to save a new record");
                controllerCode.AppendLine("            return Ok();");
                controllerCode.AppendLine("        }");
            }

            if (entity.Update)
            {
                controllerCode.AppendLine($"        [HttpPut(\"{{id}}\")]");
                controllerCode.AppendLine($"        public IActionResult Update{entity.Entity}(int id, [FromBody] {entity.Entity}Model model)");
                controllerCode.AppendLine("        {");
                controllerCode.AppendLine("            // Add logic to update an existing record");
                controllerCode.AppendLine("            return Ok();");
                controllerCode.AppendLine("        }");
            }

            if (entity.Delete)
            {
                controllerCode.AppendLine($"        [HttpDelete(\"{{id}}\")]");
                controllerCode.AppendLine($"        public IActionResult Delete{entity.Entity}(int id)");
                controllerCode.AppendLine("        {");
                controllerCode.AppendLine("            // Add logic to delete a record");
                controllerCode.AppendLine("            return Ok();");
                controllerCode.AppendLine("        }");
            }

            controllerCode.AppendLine("    }");
            controllerCode.AppendLine("}");

            return controllerCode.ToString();
        }
    }
}
