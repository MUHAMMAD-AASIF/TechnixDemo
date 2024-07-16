using System.Reflection.PortableExecutable;
using TechnixAPI.Helper;
using TechnixAPI.Models;
using TechnixModel;

namespace TechnixAPI.Service
{
    public class GenerateService
    {
        public bool GenerateFile(GenerateModel entity)
        {
            try
            {
                GenerateControllerFile(entity);
                GenerateCustomModelFile(entity);
                GenerateServiceFile(entity);

                return true;
            }

            catch (Exception ex)
            {
                // Log the exception (you can replace this with your logging mechanism)
                Console.WriteLine($"An error occurred while generating the controller file: {ex.Message}");
                return false; // Return false if an error occurs
            }
        }

        private void GenerateServiceFile(GenerateModel entity)
        {
            var servicePath = Path.GetFullPath("Service");
            string serviceFileName = entity.EntityName + "Service.cs";
            string serviceFilePath = Path.Combine(servicePath, serviceFileName);

            // Create the directories if they don't exist
            if (!Directory.Exists(servicePath))
            {
                Directory.CreateDirectory(servicePath);
            }

            // Create and write to the Service file
            using (StreamWriter writer = new StreamWriter(serviceFilePath))
            {
                using (var db = new AppDbContext())
                {
                    var entityType = db.Model.GetEntityTypes().FirstOrDefault(e => e.ClrType.Name == entity.EntityName);

                    if (entityType != null)
                    {
                        var properties = entityType.GetProperties();
                        writer.WriteLine("using System.Collections.Generic;");
                        writer.WriteLine("using System.Linq;");
                        writer.WriteLine("using TechnixAPI.Models.Custom;");
                        writer.WriteLine("using TechnixAPI.Models;");
                        writer.WriteLine("");
                        writer.WriteLine("namespace TechnixAPI.Service");
                        writer.WriteLine("{");
                        writer.WriteLine($"\tpublic class {entity.EntityName}Service");
                        writer.WriteLine("\t{");

                        // Generate GetAll method
                        writer.WriteLine($"\t\tpublic IEnumerable<{entity.EntityName}> GetAll{entity.EntityName}()");
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\tusing (var db = new AppDbContext())");
                        writer.WriteLine("\t\t\t{");
                        writer.WriteLine($"\t\t\t\tvar res = db.{entity.EntityName}s.ToList();");
                        writer.WriteLine("\t\t\t\treturn res;");
                        writer.WriteLine("\t\t\t}");
                        writer.WriteLine("\t\t}");
                        writer.WriteLine("");

                        // Generate GetById method
                        writer.WriteLine($"\t\tpublic {entity.EntityName} Get{entity.EntityName}ById(int id)");
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\tusing (var db = new AppDbContext())");
                        writer.WriteLine("\t\t\t{");
                        writer.WriteLine($"\t\t\t\tvar res = db.{entity.EntityName}s.FirstOrDefault(x => x.Id == id);");
                        writer.WriteLine($"\t\t\t\treturn res ?? new {entity.EntityName}();");
                        writer.WriteLine("\t\t\t}");
                        writer.WriteLine("\t\t}");
                        writer.WriteLine("");

                        // Generate Create method
                        writer.WriteLine($"\t\tpublic bool Create{entity.EntityName}({entity.EntityName}Model entity)");
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\tusing (var db = new AppDbContext())");
                        writer.WriteLine("\t\t\t{");
                        writer.WriteLine($"\t\t\t{entity.EntityName} obj=new {entity.EntityName}()");
                        writer.WriteLine("\t\t\t{");

                        foreach (var property in properties)
                        {
                            var propertyName = property.Name;
                            var propertyType = property.ClrType.Name;
                            writer.WriteLine($"\t\t\t\t {propertyName} =entity.{propertyName}, ");
                        }

                        writer.WriteLine("\t\t\t};");
                        writer.WriteLine($"\t\t\t\tdb.{entity.EntityName}s.Add(obj);");
                        writer.WriteLine("\t\t\t\tdb.SaveChanges();");
                        writer.WriteLine("\t\t\t\treturn true;");
                        writer.WriteLine("\t\t\t}");
                        writer.WriteLine("\t\t}");
                        writer.WriteLine("");

                        // Generate Update method
                        writer.WriteLine($"\t\tpublic bool Update{entity.EntityName}({entity.EntityName}Model entity)");
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\tusing (var db = new AppDbContext())");
                        writer.WriteLine("\t\t\t{");
                        writer.WriteLine($"\t\t\t\tvar res = db.{entity.EntityName}s.FirstOrDefault(x => x.Id == entity.Id);");
                        writer.WriteLine("\t\t\t\tif (res == null) return false;");

                        foreach (var property in properties)
                        {
                            var propertyName = property.Name;
                            var propertyType = property.ClrType.Name;
                            writer.WriteLine($"\t\t\t\t res.{propertyName} =entity.{propertyName}; ");
                        }
                        writer.WriteLine($"\t\t\t\tdb.{entity.EntityName}s.Update(res);");
                        writer.WriteLine("\t\t\t\tdb.SaveChanges();");
                        writer.WriteLine("\t\t\t\treturn true;");
                        writer.WriteLine("\t\t\t}");
                        writer.WriteLine("\t\t}");
                        writer.WriteLine("");

                        // Generate Delete method
                        writer.WriteLine($"\t\tpublic bool Delete{entity.EntityName}(int id)");
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\tusing (var db = new AppDbContext())");
                        writer.WriteLine("\t\t\t{");
                        writer.WriteLine($"\t\t\t\tvar res = db.{entity.EntityName}s.FirstOrDefault(x => x.Id == id);");
                        writer.WriteLine("\t\t\t\tif (res == null) return false;");
                        writer.WriteLine($"\t\t\t\tdb.{entity.EntityName}s.Remove(res);");
                        writer.WriteLine("\t\t\t\tdb.SaveChanges();");
                        writer.WriteLine("\t\t\t\treturn true;");
                        writer.WriteLine("\t\t\t}");
                        writer.WriteLine("\t\t}");

                        writer.WriteLine("\t}");
                        writer.WriteLine("}");
                    }
                }
            }
        }

        private void GenerateControllerFile(GenerateModel entity)
        {
            var controllerPath = Path.GetFullPath("Controllers");
            string controllerFileName = entity.EntityName + "Controller.cs";
            string controllerFilePath = Path.Combine(controllerPath, controllerFileName);

            // Create the directories if they don't exist
            if (!Directory.Exists(controllerPath))
            {
                Directory.CreateDirectory(controllerPath);
            }

            // Create and write to the Controller file
            using (StreamWriter writer = new StreamWriter(controllerFilePath))
            {
                writer.WriteLine("using Microsoft.AspNetCore.Mvc;");
                writer.WriteLine("using TechnixAPI.Service;");
                writer.WriteLine("using TechnixAPI.Models.Custom;");
                writer.WriteLine("");
                writer.WriteLine("namespace TechnixAPI.Controllers");
                writer.WriteLine("{");
                writer.WriteLine("\t[ApiController]");
                writer.WriteLine("\t[Route(\"api/[controller]\")]");
                writer.WriteLine($"\tpublic class {entity.EntityName}Controller : ControllerBase");
                writer.WriteLine("\t{");
                writer.WriteLine($"\t\tprivate readonly {entity.EntityName}Service _{entity.EntityName.ToLower()}Service;");
                writer.WriteLine("");
                writer.WriteLine($"\t\tpublic {entity.EntityName}Controller({entity.EntityName}Service {entity.EntityName.ToLower()}Service)");
                writer.WriteLine("\t\t{");
                writer.WriteLine($"\t\t\t_{entity.EntityName.ToLower()}Service = {entity.EntityName.ToLower()}Service;");
                writer.WriteLine("\t\t}");
                writer.WriteLine("");

                // Generate GET method
                writer.WriteLine($"\t\t[HttpGet(\"GetAll{entity.EntityName}\")]");
                writer.WriteLine($"\t\tpublic IActionResult GetAll{entity.EntityName}()");
                writer.WriteLine("\t\t{");
                writer.WriteLine($"\t\t\tvar result = _{entity.EntityName.ToLower()}Service.GetAll{entity.EntityName}();");
                writer.WriteLine("\t\t\treturn Ok(result);");
                writer.WriteLine("\t\t}");
                writer.WriteLine("");

                // Generate GET by ID method
                writer.WriteLine("\t\t[HttpGet(\"Get" + entity.EntityName + "ById\")]");
                writer.WriteLine($"\t\tpublic IActionResult Get{entity.EntityName}ById(int id)");
                writer.WriteLine("\t\t{");
                writer.WriteLine($"\t\t\tvar result = _{entity.EntityName.ToLower()}Service.Get{entity.EntityName}ById(id);");
                writer.WriteLine("\t\t\tif (result == null)");
                writer.WriteLine("\t\t\t{");
                writer.WriteLine("\t\t\t\treturn NotFound();");
                writer.WriteLine("\t\t\t}");
                writer.WriteLine("\t\t\treturn Ok(result);");
                writer.WriteLine("\t\t}");
                writer.WriteLine("");

                // Generate POST method
                writer.WriteLine($"\t\t[HttpPost(\"Create{entity.EntityName}\")]");
                writer.WriteLine($"\t\tpublic IActionResult Create{entity.EntityName}([FromBody] {entity.EntityName}Model entity)");
                writer.WriteLine("\t\t{");
                writer.WriteLine($"\t\t\tvar result = _{entity.EntityName.ToLower()}Service.Create{entity.EntityName}(entity);");
                writer.WriteLine("\t\t\treturn Ok(result);");
                writer.WriteLine("\t\t}");
                writer.WriteLine("");

                // Generate PUT method
                writer.WriteLine("\t\t[HttpPut(\"Update" + entity.EntityName + "\")]");
                writer.WriteLine($"\t\tpublic IActionResult Update{entity.EntityName}([FromBody] {entity.EntityName}Model entity)");
                writer.WriteLine("\t\t{");
                writer.WriteLine($"\t\t\tvar result = _{entity.EntityName.ToLower()}Service.Update{entity.EntityName}(entity);");
                writer.WriteLine("\t\t\tif (result == null)");
                writer.WriteLine("\t\t\t{");
                writer.WriteLine("\t\t\t\treturn NotFound();");
                writer.WriteLine("\t\t\t}");
                writer.WriteLine("\t\t\treturn Ok(result);");
                writer.WriteLine("\t\t}");
                writer.WriteLine("");

                // Generate DELETE method
                writer.WriteLine("\t\t[HttpDelete(\"" + entity.EntityName + "\")]");
                writer.WriteLine($"\t\tpublic IActionResult Delete{entity.EntityName}(int id)");
                writer.WriteLine("\t\t{");
                writer.WriteLine($"\t\t\tvar result = _{entity.EntityName.ToLower()}Service.Delete{entity.EntityName}(id);");
                writer.WriteLine("\t\t\tif (!result)");
                writer.WriteLine("\t\t\t{");
                writer.WriteLine("\t\t\t\treturn NotFound();");
                writer.WriteLine("\t\t\t}");
                writer.WriteLine("\t\t\treturn NoContent();");
                writer.WriteLine("\t\t}");

                writer.WriteLine("\t}");
                writer.WriteLine("}");
            }
        }
        private void GenerateCustomModelFile(GenerateModel entity)
        {
            var cModelPath = Path.GetFullPath("Models/Custom");
            string cModelFileName = entity.EntityName + "Model.cs";
            string cModelFilePath = Path.Combine(cModelPath, cModelFileName);

            // Create the directories if they don't exist
            if (!Directory.Exists(cModelPath))
            {
                Directory.CreateDirectory(cModelPath);
            }

            // Create and write to the Custom Model file
            using (StreamWriter writer = new StreamWriter(cModelFilePath))
            {
                using (var db = new AppDbContext())
                {
                    var entityType = db.Model.GetEntityTypes().FirstOrDefault(e => e.ClrType.Name == entity.EntityName);

                    if (entityType != null)
                    {
                        var properties = entityType.GetProperties();
                        writer.WriteLine("using System;");
                        writer.WriteLine("");
                        writer.WriteLine("namespace TechnixAPI.Models.Custom");
                        writer.WriteLine("{");
                        writer.WriteLine($"\tpublic class {entity.EntityName}Model");
                        writer.WriteLine("\t{");
                        foreach (var property in properties)
                        {
                            var propertyName = property.Name;
                            var propertyType = property.ClrType.Name;
                            writer.WriteLine($"\t\tpublic {GetPropertyType(propertyType)} {propertyName} {{ get; set; }}");
                        }
                        writer.WriteLine("\t}");
                        writer.WriteLine("}");
                    }
                }
            }
        }

        private string GetPropertyType(string clrType)
        {
            switch (clrType)
            {
                case "String": return "string";
                case "Int32": return "int";
                case "Int64": return "long";
                case "Double": return "double";
                case "Decimal": return "decimal";
                case "Boolean": return "bool";
                case "Nullable`1": return "bool";
                case "DateTime": return "DateTime";
                // Add more cases as needed
                default: return clrType;
            }
        }
    }
}
