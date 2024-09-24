using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnixDemo.Model;
using TechnixDemo.Service;

namespace TechnixDemo.Templates
{
    public class DataAccessGenerator
    {
        public string GenerateDataAccess(EntitySelectModel entity, string ProjectName)
        {
            var dataAccessCode = new StringBuilder();

            dataAccessCode.AppendLine($"using Msc.{ProjectName}.Service.CommonModel;");
            dataAccessCode.AppendLine($"using Msc.{ProjectName}.Service.DataAccess.Contracts;");
            dataAccessCode.AppendLine($"using Msc.{ProjectName}.Service.DataAccess.Contracts.Context;");
            dataAccessCode.AppendLine("using Microsoft.EntityFrameworkCore;");
            dataAccessCode.AppendLine("using System.Linq;");
            dataAccessCode.AppendLine();
            dataAccessCode.AppendLine($"namespace Msc.{ProjectName}.Service.DataAccess");
            dataAccessCode.AppendLine("{");
            dataAccessCode.AppendLine($"\tpublic class {entity.Entity}Repository : I{entity.Entity}Repository");
            dataAccessCode.AppendLine("\t{");
            dataAccessCode.AppendLine($"\t\tprivate readonly AppDbContext _context;");
            dataAccessCode.AppendLine();
            dataAccessCode.AppendLine($"\t\tpublic {entity.Entity}Repository(AppDbContext context)");
            dataAccessCode.AppendLine("\t\t{");
            dataAccessCode.AppendLine("\t\t\t_context = context;");
            dataAccessCode.AppendLine("\t\t}");
            dataAccessCode.AppendLine();

            DatabaseHelper db = new DatabaseHelper();

            if (entity.GetAll)
            {
                dataAccessCode.AppendLine($"\t\tpublic IEnumerable<{entity.Entity}> GetAll()");
                dataAccessCode.AppendLine("\t\t{");
                dataAccessCode.AppendLine($"\t\t\t// Logic for getting all {entity.Entity} entities");
                var forgintb = db.GetForeignTables(entity.Entity);
                string result = string.Join(", ", forgintb.Select(item => $".Include(\"{item}\")")).Replace(", ", "");

                dataAccessCode.AppendLine($"\t\t\treturn _context.{entity.Entity}s{result}.ToList();");
                dataAccessCode.AppendLine("\t\t}");
                dataAccessCode.AppendLine();
            }

            if (entity.GetById)
            {
                dataAccessCode.AppendLine($"\t\tpublic {entity.Entity} GetById(int id)");
                dataAccessCode.AppendLine("\t\t{");
                dataAccessCode.AppendLine($"\t\t\t// Logic for getting {entity.Entity} by Id");
                dataAccessCode.AppendLine($"\t\t\treturn _context.{entity.Entity}s.FirstOrDefault(e => e.Id == id);");
                dataAccessCode.AppendLine("\t\t}");
                dataAccessCode.AppendLine();
            }

            if (entity.Save)
            {
                dataAccessCode.AppendLine($"\t\tpublic {entity.Entity} Save({entity.Entity} model)");
                dataAccessCode.AppendLine("\t\t{");
                dataAccessCode.AppendLine($"\t\t\t// Logic for saving a new {entity.Entity}");
                dataAccessCode.AppendLine("\t\t\t_context.Add(model);");
                dataAccessCode.AppendLine("\t\t\t_context.SaveChanges();");
                dataAccessCode.AppendLine("\t\t\treturn model;");
                dataAccessCode.AppendLine("\t\t}");
                dataAccessCode.AppendLine();
            }

            if (entity.Update)
            {
                dataAccessCode.AppendLine($"\t\tpublic bool Update({entity.Entity} model)");
                dataAccessCode.AppendLine("\t\t{");
                dataAccessCode.AppendLine($"\t\t\t// Logic for updating an existing {entity.Entity}");
                dataAccessCode.AppendLine($"\t\t\tvar existingEntity = _context.{entity.Entity}s.FirstOrDefault(e => e.Id == model.Id);");
                dataAccessCode.AppendLine("\t\t\tif (existingEntity == null) return false;");
                dataAccessCode.AppendLine();

                var entityNames = db.GetColumnNamesAndDataTypes(entity.Entity);

                foreach (var column in entityNames)
                {
                    if (column.Key != "Id")
                    {
                        dataAccessCode.AppendLine($"\t\t\texistingEntity.{column.Key} = model.{column.Key}; // Update necessary properties");
                    }
                }

                dataAccessCode.AppendLine();
                dataAccessCode.AppendLine("\t\t\t_context.Update(existingEntity);");
                dataAccessCode.AppendLine("\t\t\t_context.SaveChanges();");
                dataAccessCode.AppendLine("\t\t\treturn true;");
                dataAccessCode.AppendLine("\t\t}");
                dataAccessCode.AppendLine();
            }

            if (entity.Delete)
            {
                dataAccessCode.AppendLine($"\t\tpublic bool Delete(int id)");
                dataAccessCode.AppendLine("\t\t{");
                dataAccessCode.AppendLine($"\t\t\t// Logic for deleting an existing {entity.Entity}");
                dataAccessCode.AppendLine($"\t\t\tvar entityToDelete = _context.{entity.Entity}s.FirstOrDefault(e => e.Id == id);");
                dataAccessCode.AppendLine("\t\t\tif (entityToDelete == null) return false;");
                dataAccessCode.AppendLine();
                dataAccessCode.AppendLine("\t\t\t_context.Remove(entityToDelete);");
                dataAccessCode.AppendLine("\t\t\t_context.SaveChanges();");
                dataAccessCode.AppendLine("\t\t\treturn true;");
                dataAccessCode.AppendLine("\t\t}");
                dataAccessCode.AppendLine();
            }

            dataAccessCode.AppendLine("\t}");
            dataAccessCode.AppendLine("}");

            return dataAccessCode.ToString();
        }

    }

}
