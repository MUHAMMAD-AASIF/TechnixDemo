using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnixDemo.Model;

namespace TechnixDemo.Templates
{
    public class DataAccessGenerator
    {
        public string GenerateDataAccess(string entityName, EntitySelectModel entity)
        {
            var dataAccessCode = new StringBuilder();

            dataAccessCode.AppendLine($"public class {entityName}DataAccess : I{entityName}DataAccess");
            dataAccessCode.AppendLine("{");

            if (entity.GetAll)
            {
                dataAccessCode.AppendLine($"    public IEnumerable<{entityName}> GetAll()");
                dataAccessCode.AppendLine("    {");
                dataAccessCode.AppendLine($"        // Logic for getting all {entityName} entities");
                dataAccessCode.AppendLine("    }");
            }

            if (entity.GetById)
            {
                dataAccessCode.AppendLine($"    public {entityName} GetById(int id)");
                dataAccessCode.AppendLine("    {");
                dataAccessCode.AppendLine($"        // Logic for getting {entityName} by Id");
                dataAccessCode.AppendLine("    }");
            }

            if (entity.Save)
            {
                dataAccessCode.AppendLine($"    public void Save({entityName} model)");
                dataAccessCode.AppendLine("    {");
                dataAccessCode.AppendLine($"        // Logic for saving {entityName}");
                dataAccessCode.AppendLine("    }");
            }

            if (entity.Update)
            {
                dataAccessCode.AppendLine($"    public void Update({entityName} model)");
                dataAccessCode.AppendLine("    {");
                dataAccessCode.AppendLine($"        // Logic for updating {entityName}");
                dataAccessCode.AppendLine("    }");
            }

            if (entity.Delete)
            {
                dataAccessCode.AppendLine($"    public void Delete(int id)");
                dataAccessCode.AppendLine("    {");
                dataAccessCode.AppendLine($"        // Logic for deleting {entityName}");
                dataAccessCode.AppendLine("    }");
            }

            dataAccessCode.AppendLine("}");

            return dataAccessCode.ToString();
        }
    }

}
