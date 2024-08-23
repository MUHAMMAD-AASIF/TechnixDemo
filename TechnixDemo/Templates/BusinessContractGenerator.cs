using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnixDemo.Model;

namespace TechnixDemo.Templates
{
    public class BusinessContractGenerator
    {
        public string GenerateBusinessContract(EntitySelectModel entity, string ProjectName)
        {
            var contractCode = new StringBuilder();

            contractCode.AppendLine($"using {ProjectName}.Models;");
            contractCode.AppendLine("using System.Collections.Generic;");
            contractCode.AppendLine();
            contractCode.AppendLine($"namespace {ProjectName}.Business.Contracts");
            contractCode.AppendLine("{");
            contractCode.AppendLine($"    public interface I{entity.Entity}Service");
            contractCode.AppendLine("    {");

            if (entity.GetAll)
            {
                contractCode.AppendLine($"        IEnumerable<{entity.Entity}Model> GetAll();");
            }

            if (entity.GetById)
            {
                contractCode.AppendLine($"        {entity.Entity}Model GetById(int id);");
            }

            if (entity.Save)
            {
                contractCode.AppendLine($"        {entity.Entity}Model Save({entity.Entity}Model model);");
            }

            if (entity.Update)
            {
                contractCode.AppendLine($"        bool Update(int id, {entity.Entity}Model model);");
            }

            if (entity.Delete)
            {
                contractCode.AppendLine($"        bool Delete(int id);");
            }

            contractCode.AppendLine("    }");
            contractCode.AppendLine("}");

            return contractCode.ToString();
        }

    }

}
