using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnixDemo.Model;

namespace TechnixDemo.Templates
{
    public class DataAccessContractGenerator
    {

        public string GenerateDataAccessContract(EntitySelectModel entity, string ProjectName)
        {
            var contractCode = new StringBuilder();

            contractCode.AppendLine($"using Msc.{ProjectName}.Service.CommonModel;");
            contractCode.AppendLine("using System.Collections.Generic;");
            contractCode.AppendLine();
            contractCode.AppendLine($"namespace Msc.{ProjectName}.Service.DataAccess.Contracts");
            contractCode.AppendLine("{");
            contractCode.AppendLine($"    public interface I{entity.Entity}Repository");
            contractCode.AppendLine("    {");

            if (entity.GetAll)
            {
                contractCode.AppendLine($"        IEnumerable<{entity.Entity}> GetAll();");
            }

            if (entity.GetById)
            {
                contractCode.AppendLine($"        {entity.Entity} GetById(int id);");
            }

            if (entity.Save)
            {
                contractCode.AppendLine($"        {entity.Entity} Save({entity.Entity} model);");
            }

            if (entity.Update)
            {
                contractCode.AppendLine($"        bool Update({entity.Entity} model);");
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
