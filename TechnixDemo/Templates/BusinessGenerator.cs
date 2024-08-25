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

            serviceCode.AppendLine($"using Msc.{ProjectName}.Service.Business.Contracts;");
            serviceCode.AppendLine($"using Msc.{ProjectName}.Service.DataAccess.Contracts;");
            serviceCode.AppendLine($"using Msc.{ProjectName}.Service.CommonModel;");
            serviceCode.AppendLine("using System.Collections.Generic;");
            serviceCode.AppendLine();
            serviceCode.AppendLine($"namespace Msc.{ProjectName}.Service.Business");
            serviceCode.AppendLine("{");
            serviceCode.AppendLine($"    public class {entity.Entity}Service : I{entity.Entity}Service");
            serviceCode.AppendLine("    {");
            serviceCode.AppendLine($"        private readonly I{entity.Entity}Repository _{entity.Entity.ToLower()}Repository;");
            serviceCode.AppendLine();
            serviceCode.AppendLine($"        public {entity.Entity}Service(I{entity.Entity}Repository {entity.Entity.ToLower()}Repository)");
            serviceCode.AppendLine("        {");
            serviceCode.AppendLine($"            _{entity.Entity.ToLower()}Repository = {entity.Entity.ToLower()}Repository;");
            serviceCode.AppendLine("        }");
            serviceCode.AppendLine();

            if (entity.GetAll)
            {
                serviceCode.AppendLine($"        public IEnumerable<{entity.Entity}> GetAll()");
                serviceCode.AppendLine("        {");
                serviceCode.AppendLine("            // Retrieve all records from the repository");
                serviceCode.AppendLine($"            return _{entity.Entity.ToLower()}Repository.GetAll();");
                serviceCode.AppendLine("        }");
                serviceCode.AppendLine();
            }

            if (entity.GetById)
            {
                serviceCode.AppendLine($"        public {entity.Entity} GetById(int id)");
                serviceCode.AppendLine("        {");
                serviceCode.AppendLine("            // Retrieve a single record by ID from the repository");
                serviceCode.AppendLine($"            return _{entity.Entity.ToLower()}Repository.GetById(id);");
                serviceCode.AppendLine("        }");
                serviceCode.AppendLine();
            }

            if (entity.Save)
            {
                serviceCode.AppendLine($"        public {entity.Entity} Save({entity.Entity} model)");
                serviceCode.AppendLine("        {");
                serviceCode.AppendLine("            // Validate the model");
                serviceCode.AppendLine("            if (model == null)");
                serviceCode.AppendLine("            {");
                serviceCode.AppendLine("                throw new ArgumentNullException(nameof(model));");
                serviceCode.AppendLine("            }");
                serviceCode.AppendLine();
                serviceCode.AppendLine("            // Save the new record in the repository");
                serviceCode.AppendLine($"            return _{entity.Entity.ToLower()}Repository.Save(model);");
                serviceCode.AppendLine("        }");
                serviceCode.AppendLine();
            }

            if (entity.Update)
            {
                serviceCode.AppendLine($"        public bool Update({entity.Entity} model)");
                serviceCode.AppendLine("        {");
                serviceCode.AppendLine("            // Validate the model");
                serviceCode.AppendLine("            if (model == null)");
                serviceCode.AppendLine("            {");
                serviceCode.AppendLine("                throw new ArgumentException(\"Invalid model \");");
                serviceCode.AppendLine("            }");
                serviceCode.AppendLine();
                serviceCode.AppendLine("            // Update the record in the repository");
                serviceCode.AppendLine($"            return _{entity.Entity.ToLower()}Repository.Update(model);");
                serviceCode.AppendLine("        }");
                serviceCode.AppendLine();
            }

            if (entity.Delete)
            {
                serviceCode.AppendLine($"        public bool Delete(int id)");
                serviceCode.AppendLine("        {");
                serviceCode.AppendLine("            // Ensure the record exists before attempting to delete");
                serviceCode.AppendLine($"            var existingEntity = _{entity.Entity.ToLower()}Repository.GetById(id);");
                serviceCode.AppendLine("            if (existingEntity == null)");
                serviceCode.AppendLine("            {");
                serviceCode.AppendLine("                return false;");
                serviceCode.AppendLine("            }");
                serviceCode.AppendLine();
                serviceCode.AppendLine("            // Delete the record from the repository");
                serviceCode.AppendLine($"            return _{entity.Entity.ToLower()}Repository.Delete(id);");
                serviceCode.AppendLine("        }");
                serviceCode.AppendLine();
            }

            serviceCode.AppendLine("    }");
            serviceCode.AppendLine("}");

            return serviceCode.ToString();
        }

    }
}
