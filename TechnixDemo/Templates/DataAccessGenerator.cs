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
        public string GenerateDataAccess(EntitySelectModel entity, string ProjectName)
        {
            var dataAccessCode = new StringBuilder();

            dataAccessCode.AppendLine($"using {ProjectName}.Models;");
            dataAccessCode.AppendLine("using System.Collections.Generic;");
            dataAccessCode.AppendLine("using System.Linq;");
            dataAccessCode.AppendLine();
            dataAccessCode.AppendLine($"namespace {ProjectName}.DataAccess");
            dataAccessCode.AppendLine("{");
            dataAccessCode.AppendLine($"    public class {entity.Entity}DataAccess : I{entity.Entity}DataAccess");
            dataAccessCode.AppendLine("    {");
            dataAccessCode.AppendLine($"        private readonly ApplicationDbContext _context;");
            dataAccessCode.AppendLine();
            dataAccessCode.AppendLine($"        public {entity.Entity}DataAccess(ApplicationDbContext context)");
            dataAccessCode.AppendLine("        {");
            dataAccessCode.AppendLine("            _context = context;");
            dataAccessCode.AppendLine("        }");
            dataAccessCode.AppendLine();

            if (entity.GetAll)
            {
                dataAccessCode.AppendLine($"        public IEnumerable<{entity.Entity}Model> GetAll()");
                dataAccessCode.AppendLine("        {");
                dataAccessCode.AppendLine($"            // Logic for getting all {entity.Entity} entities");
                dataAccessCode.AppendLine($"            return _context.{entity.Entity}s.ToList();");
                dataAccessCode.AppendLine("        }");
                dataAccessCode.AppendLine();
            }

            if (entity.GetById)
            {
                dataAccessCode.AppendLine($"        public {entity.Entity}Model GetById(int id)");
                dataAccessCode.AppendLine("        {");
                dataAccessCode.AppendLine($"            // Logic for getting {entity.Entity} by Id");
                dataAccessCode.AppendLine($"            return _context.{entity.Entity}s.FirstOrDefault(e => e.Id == id);");
                dataAccessCode.AppendLine("        }");
                dataAccessCode.AppendLine();
            }

            if (entity.Save)
            {
                dataAccessCode.AppendLine($"        public {entity.Entity}Model Save({entity.Entity}Model model)");
                dataAccessCode.AppendLine("        {");
                dataAccessCode.AppendLine($"            // Logic for saving a new {entity.Entity}");
                dataAccessCode.AppendLine("            _context.Add(model);");
                dataAccessCode.AppendLine("            _context.SaveChanges();");
                dataAccessCode.AppendLine("            return model;");
                dataAccessCode.AppendLine("        }");
                dataAccessCode.AppendLine();
            }

            if (entity.Update)
            {
                dataAccessCode.AppendLine($"        public bool Update({entity.Entity}Model model)");
                dataAccessCode.AppendLine("        {");
                dataAccessCode.AppendLine($"            // Logic for updating an existing {entity.Entity}");
                dataAccessCode.AppendLine("            var existingEntity = _context.{entity.Entity}s.FirstOrDefault(e => e.Id == model.Id);");
                dataAccessCode.AppendLine("            if (existingEntity == null) return false;");
                dataAccessCode.AppendLine();
                dataAccessCode.AppendLine("            existingEntity.Property1 = model.Property1; // Update necessary properties");
                dataAccessCode.AppendLine("            existingEntity.Property2 = model.Property2;");
                dataAccessCode.AppendLine();
                dataAccessCode.AppendLine("            _context.Update(existingEntity);");
                dataAccessCode.AppendLine("            _context.SaveChanges();");
                dataAccessCode.AppendLine("            return true;");
                dataAccessCode.AppendLine("        }");
                dataAccessCode.AppendLine();
            }

            if (entity.Delete)
            {
                dataAccessCode.AppendLine($"        public bool Delete(int id)");
                dataAccessCode.AppendLine("        {");
                dataAccessCode.AppendLine($"            // Logic for deleting an existing {entity.Entity}");
                dataAccessCode.AppendLine($"            var entityToDelete = _context.{entity.Entity}s.FirstOrDefault(e => e.Id == id);");
                dataAccessCode.AppendLine("            if (entityToDelete == null) return false;");
                dataAccessCode.AppendLine();
                dataAccessCode.AppendLine("            _context.Remove(entityToDelete);");
                dataAccessCode.AppendLine("            _context.SaveChanges();");
                dataAccessCode.AppendLine("            return true;");
                dataAccessCode.AppendLine("        }");
                dataAccessCode.AppendLine();
            }

            dataAccessCode.AppendLine("    }");
            dataAccessCode.AppendLine("}");

            return dataAccessCode.ToString();
        }

    }

}
