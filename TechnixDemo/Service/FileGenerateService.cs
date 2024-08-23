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
                foreach(EntitySelectModel entitySelectModel in _entities)
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
            // Generate Controller file
            GenerateFileFromTemplate("Controller", Path.Combine(_filepathRes.APIPath,"Controllers", $"{entity.Entity}Controller.cs"), entity);

            // Generate Business file
            GenerateFileFromTemplate("Business", Path.Combine(_filepathRes.BusinessPath, $"{entity.Entity}Service.cs"), entity);

            //// Generate Business.Contracts file
            GenerateFileFromTemplate("Business.Contracts", Path.Combine(_filepathRes.APIPath, "Interfaces", $"I{entity.Entity}Service.cs"), entity);

            //// Generate DataAccess file
            GenerateFileFromTemplate("DataAccess", Path.Combine(_filepathRes.BusinessPath, $"{entity.Entity}Repository.cs"), entity);

            //// Generate DataAccess.Contracts file
            GenerateFileFromTemplate("DataAccess.Contracts", Path.Combine(_filepathRes.APIPath, "Interfaces", $"I{entity.Entity}Repository.cs"), entity);

            //// Generate Controller xUnit Test file
            GenerateFileFromTemplate("API.Test", Path.Combine(_filepathRes.APIPath, "UnitTest", $"{entity.Entity}ControllerUnitTest.cs"), entity);

            //// Generate Business xUnit Test file
            GenerateFileFromTemplate("Business.Test", Path.Combine(_filepathRes.APIPath, "UnitTest", $"{entity.Entity}ServiceUnitTest.cs"), entity);

        }

        private void GenerateFileFromTemplate(string type, string outputPath, EntitySelectModel entity)
        {
            string outputContent=string.Empty;
            if (type == "Controller")
            {
                ApiGenerator apiGenerator = new ApiGenerator();
                outputContent = apiGenerator.GenerateController(entity, _filepathRes.ProjectName);
            }
            else if (type == "Business")
            {
                BusinessGenerator businessGenerator = new BusinessGenerator();
                outputContent = businessGenerator.GenerateBusiness(entity, _filepathRes.ProjectName);
            }
            else if (type == "Business.Contracts")
            {
                ApiGenerator apiGenerator = new ApiGenerator();
                outputContent = apiGenerator.GenerateController(entity, _filepathRes.ProjectName);
            }
            else if (type == "DataAccess")
            {
                ApiGenerator apiGenerator = new ApiGenerator();
                outputContent = apiGenerator.GenerateController(entity, _filepathRes.ProjectName);
            }
            else if (type == "DataAccess.Contracts")
            {
                ApiGenerator apiGenerator = new ApiGenerator();
                outputContent = apiGenerator.GenerateController(entity, _filepathRes.ProjectName);
            }
            else if (type == "API.Test")
            {
                ApiGenerator apiGenerator = new ApiGenerator();
                outputContent = apiGenerator.GenerateController(entity, _filepathRes.ProjectName);
            }
            else if (type == "Business.Test")
            {
                ApiGenerator apiGenerator = new ApiGenerator();
                outputContent = apiGenerator.GenerateController(entity, _filepathRes.ProjectName);
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)); // Ensure the directory exists
            File.WriteAllText(outputPath, outputContent);
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
