using System.Text;
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
            contractCode.AppendLine($"\tpublic interface I{entity.Entity}Repository");
            contractCode.AppendLine("\t{");

            if (entity.GetAll)
            {
                contractCode.AppendLine($"\t\tIEnumerable<{entity.Entity}> GetAll();");
            }

            if (entity.GetById)
            {
                contractCode.AppendLine($"\t\t{entity.Entity} GetById(int id);");
            }

            if (entity.Save)
            {
                contractCode.AppendLine($"\t\t{entity.Entity} Save({entity.Entity} model);");
            }

            if (entity.Update)
            {
                contractCode.AppendLine($"\t\tbool Update({entity.Entity} model);");
            }

            if (entity.Delete)
            {
                contractCode.AppendLine($"\t\tbool Delete(int id);");
            }

            contractCode.AppendLine("\t}");
            contractCode.AppendLine("}");

            return contractCode.ToString();
        }

    }
}
