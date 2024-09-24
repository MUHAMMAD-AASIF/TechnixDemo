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
            serviceCode.AppendLine($"\tpublic class {entity.Entity}Service : I{entity.Entity}Service");
            serviceCode.AppendLine("\t{");
            serviceCode.AppendLine($"\t\tprivate readonly I{entity.Entity}Repository _{entity.Entity.ToLower()}Repository;");
            serviceCode.AppendLine();
            serviceCode.AppendLine($"\t\tpublic {entity.Entity}Service(I{entity.Entity}Repository {entity.Entity.ToLower()}Repository)");
            serviceCode.AppendLine("\t\t{");
            serviceCode.AppendLine($"\t\t\t_{entity.Entity.ToLower()}Repository = {entity.Entity.ToLower()}Repository;");
            serviceCode.AppendLine("\t\t}");
            serviceCode.AppendLine();

            if (entity.GetAll)
            {
                serviceCode.AppendLine($"\t\tpublic IEnumerable<{entity.Entity}> GetAll()");
                serviceCode.AppendLine("\t\t{");
                serviceCode.AppendLine("\t\t\t// Retrieve all records from the repository");
                serviceCode.AppendLine($"\t\t\treturn _{entity.Entity.ToLower()}Repository.GetAll();");
                serviceCode.AppendLine("\t\t}");
                serviceCode.AppendLine();
            }

            if (entity.GetById)
            {
                serviceCode.AppendLine($"\t\tpublic {entity.Entity} GetById(int id)");
                serviceCode.AppendLine("\t\t{");
                serviceCode.AppendLine("\t\t\t// Retrieve a single record by ID from the repository");
                serviceCode.AppendLine($"\t\t\treturn _{entity.Entity.ToLower()}Repository.GetById(id);");
                serviceCode.AppendLine("\t\t}");
                serviceCode.AppendLine();
            }

            if (entity.Save)
            {
                serviceCode.AppendLine($"\t\tpublic {entity.Entity} Save({entity.Entity} model)");
                serviceCode.AppendLine("\t\t{");
                serviceCode.AppendLine("\t\t\t// Validate the model");
                serviceCode.AppendLine("\t\t\tif (model == null)");
                serviceCode.AppendLine("\t\t\t{");
                serviceCode.AppendLine("\t\t\t\tthrow new ArgumentNullException(nameof(model));");
                serviceCode.AppendLine("\t\t\t}");
                serviceCode.AppendLine();
                serviceCode.AppendLine("\t\t\t// Save the new record in the repository");
                serviceCode.AppendLine($"\t\t\treturn _{entity.Entity.ToLower()}Repository.Save(model);");
                serviceCode.AppendLine("\t\t}");
                serviceCode.AppendLine();
            }

            if (entity.Update)
            {
                serviceCode.AppendLine($"\t\tpublic bool Update({entity.Entity} model)");
                serviceCode.AppendLine("\t\t{");
                serviceCode.AppendLine("\t\t\t// Validate the model");
                serviceCode.AppendLine("\t\t\tif (model == null)");
                serviceCode.AppendLine("\t\t\t{");
                serviceCode.AppendLine("\t\t\t\tthrow new ArgumentException(\"Invalid model \");");
                serviceCode.AppendLine("\t\t\t}");
                serviceCode.AppendLine();
                serviceCode.AppendLine("\t\t\t// Update the record in the repository");
                serviceCode.AppendLine($"\t\t\treturn _{entity.Entity.ToLower()}Repository.Update(model);");
                serviceCode.AppendLine("\t\t}");
                serviceCode.AppendLine();
            }

            if (entity.Delete)
            {
                serviceCode.AppendLine($"\t\tpublic bool Delete(int id)");
                serviceCode.AppendLine("\t\t{");
                serviceCode.AppendLine("\t\t\t// Ensure the record exists before attempting to delete");
                serviceCode.AppendLine($"\t\t\tvar existingEntity = _{entity.Entity.ToLower()}Repository.GetById(id);");
                serviceCode.AppendLine("\t\t\tif (existingEntity == null)");
                serviceCode.AppendLine("\t\t\t{");
                serviceCode.AppendLine("\t\t\t\treturn false;");
                serviceCode.AppendLine("\t\t\t}");
                serviceCode.AppendLine();
                serviceCode.AppendLine("\t\t\t// Delete the record from the repository");
                serviceCode.AppendLine($"\t\t\treturn _{entity.Entity.ToLower()}Repository.Delete(id);");
                serviceCode.AppendLine("\t\t}");
                serviceCode.AppendLine();
            }

            serviceCode.AppendLine("\t}");
            serviceCode.AppendLine("}");

            return serviceCode.ToString();
        }

    }
}
