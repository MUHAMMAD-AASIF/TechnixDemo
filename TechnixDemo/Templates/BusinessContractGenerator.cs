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
        public string GenerateBusinessContract(string entityName, EntitySelectModel entity)
        {
            var contractCode = new StringBuilder();

            contractCode.AppendLine($"namespace YourNamespace.Business.Contracts");
            contractCode.AppendLine("{");
            contractCode.AppendLine($"    public interface I{entityName}Service");
            contractCode.AppendLine("    {");

            if (entity.GetAll)
            {
                contractCode.AppendLine($"        IEnumerable<YourEntityModel> GetAll();");
            }

            if (entity.GetById)
            {
                contractCode.AppendLine($"        YourEntityModel GetById(int id);");
            }

            if (entity.Save)
            {
                contractCode.AppendLine($"        void Save(YourEntityModel model);");
            }

            if (entity.Update)
            {
                contractCode.AppendLine($"        void Update(int id, YourEntityModel model);");
            }

            if (entity.Delete)
            {
                contractCode.AppendLine($"        void Delete(int id);");
            }

            contractCode.AppendLine("    }");
            contractCode.AppendLine("}");

            return contractCode.ToString();
        }
    }

}
