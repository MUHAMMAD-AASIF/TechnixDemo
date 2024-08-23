using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnixDemo.Model;

namespace TechnixDemo.Templates
{
    public class BusinessGenerator
    {
        
        public string GenerateBusiness(EntitySelectModel entity, string ProjectName)
        {
            var serviceCode = new StringBuilder();

            serviceCode.AppendLine($"namespace YourNamespace.Business");
            serviceCode.AppendLine("{");
            serviceCode.AppendLine($"    public class {entityName}Service : I{entityName}Service");
            serviceCode.AppendLine("    {");

            if (entity.GetAll)
            {
                serviceCode.AppendLine($"        public IEnumerable<YourEntityModel> GetAll()");
                serviceCode.AppendLine("        {");
                serviceCode.AppendLine("            // Add logic to get all records");
                serviceCode.AppendLine("        }");
            }

            if (entity.GetById)
            {
                serviceCode.AppendLine($"        public YourEntityModel GetById(int id)");
                serviceCode.AppendLine("        {");
                serviceCode.AppendLine("            // Add logic to get a record by ID");
                serviceCode.AppendLine("        }");
            }

            if (entity.Save)
            {
                serviceCode.AppendLine($"        public void Save(YourEntityModel model)");
                serviceCode.AppendLine("        {");
                serviceCode.AppendLine("            // Add logic to save a new record");
                serviceCode.AppendLine("        }");
            }

            if (entity.Update)
            {
                serviceCode.AppendLine($"        public void Update(int id, YourEntityModel model)");
                serviceCode.AppendLine("        {");
                serviceCode.AppendLine("            // Add logic to update an existing record");
                serviceCode.AppendLine("        }");
            }

            if (entity.Delete)
            {
                serviceCode.AppendLine($"        public void Delete(int id)");
                serviceCode.AppendLine("        {");
                serviceCode.AppendLine("            // Add logic to delete a record");
                serviceCode.AppendLine("        }");
            }

            serviceCode.AppendLine("    }");
            serviceCode.AppendLine("}");

            return serviceCode.ToString();
        }
    }
}
