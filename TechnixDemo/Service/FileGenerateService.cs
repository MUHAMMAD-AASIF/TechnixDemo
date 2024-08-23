using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechnixDemo.Model;
using TechnixDemo.Templates;

namespace TechnixDemo.Service
{
    public class FileGenerateService
    {
        private readonly List<EntitySelectModel> _entities;
        private readonly ProjectResponseModel _filepathRes;
        public FileGenerateService(List<EntitySelectModel> entities, ProjectResponseModel filepathRes)
        {
            _entities = entities;
            _filepathRes = filepathRes;
        }

        public bool GenerateFile()
        {
            try
            {
                foreach (EntitySelectModel entitySelectModel in _entities)
                {
                    GenerateAllFile(entitySelectModel);
                }

                return true;
            }

            catch (Exception ex)
            {
                // Log the exception (you can replace this with your logging mechanism)
                Console.WriteLine($"An error occurred while generating the controller file: {ex.Message}");
                return false; // Return false if an error occurs
            }
        }

        public void GenerateAllFile(EntitySelectModel entity)
        {
            var fileTemplates = new Dictionary<string, string>
            {
                { "Controller", Path.Combine(_filepathRes.APIPath, "Controllers", $"{entity.Entity}Controller.cs") },
                { "Business", Path.Combine(_filepathRes.BusinessPath, $"{entity.Entity}Service.cs") },
                { "Business.Contracts", Path.Combine(_filepathRes.BusinessContractPath, "Interfaces", $"I{entity.Entity}Service.cs") },
                { "DataAccess", Path.Combine(_filepathRes.DataAccessPath, $"{entity.Entity}Repository.cs") },
                { "DataAccess.Contracts", Path.Combine(_filepathRes.DataAccessContractPath, "Interfaces", $"I{entity.Entity}Repository.cs") },
                { "API.Test", Path.Combine(_filepathRes.APITestPath, "UnitTest", $"{entity.Entity}ControllerUnitTest.cs") },
                { "Business.Test", Path.Combine(_filepathRes.BusinessTestPath, "UnitTest", $"{entity.Entity}ServiceUnitTest.cs") }
            };

            foreach (var template in fileTemplates)
            {
                GenerateFileFromTemplate(template.Key, template.Value, entity);
            }
        }

        private void GenerateFileFromTemplate(string type, string outputPath, EntitySelectModel entity)
        {
            var generators = new Dictionary<string, Func<string>>
            {
                { "Controller", () => new ApiGenerator().GenerateController(entity, _filepathRes.ProjectName) },
                { "Business", () => new BusinessGenerator().GenerateBusiness(entity, _filepathRes.ProjectName) },
                { "Business.Contracts", () => new BusinessContractGenerator().GenerateBusinessContract(entity, _filepathRes.ProjectName) },
                { "DataAccess", () => new DataAccessGenerator().GenerateDataAccess(entity, _filepathRes.ProjectName) },
                { "DataAccess.Contracts", () => new DataAccessContractGenerator().GenerateDataAccessContract(entity, _filepathRes.ProjectName) },
                { "API.Test", () => new ApiTestGenerator().GenerateApiTest(entity, _filepathRes.ProjectName) },
                { "Business.Test", () => new BusinessTestGenerator().GenerateBusinessTests(entity, _filepathRes.ProjectName) }
            };

            if (generators.TryGetValue(type, out var generator))
            {
                string outputContent = generator();
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath)); // Ensure the directory exists
                File.WriteAllText(outputPath, outputContent);
            }
            else
            {
                throw new ArgumentException($"Invalid type: {type}");
            }
        }

        private string ProcessTemplate(string templateContent, object templateParams)
        {
            // Create a DataTable to hold template parameters
            var dataTable = new DataTable();
            dataTable.Columns.Add("Placeholder", typeof(string));
            dataTable.Columns.Add("Value", typeof(string));

            // Fill the DataTable with parameter names and their values
            foreach (var prop in templateParams.GetType().GetProperties())
            {
                string placeholder = $"<#= {prop.Name} #>";
                string value = prop.GetValue(templateParams)?.ToString() ?? string.Empty;
                dataTable.Rows.Add(placeholder, value);
            }

            // Replace placeholders in the template content
            foreach (DataRow row in dataTable.Rows)
            {
                string placeholder = row["Placeholder"].ToString();
                string value = row["Value"].ToString();
                templateContent = templateContent.Replace(placeholder, value);
            }

            return templateContent;
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
