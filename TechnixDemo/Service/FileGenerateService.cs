using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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
                string filePath = Path.Combine(_filepathRes.APIPath, "App_Start", "ContainerExtension.cs");

                if (!File.Exists(filePath))
                {
                    GenerateDependencyInjection();
                }

                string MoveFilePath = Path.Combine(_filepathRes.DataAccessContractPath, "Context", "AppDbContext.cs");

                if (File.Exists(MoveFilePath))
                {
                    MoveFilesExcept();
                }

                ReplaceStringInAllFilesInDirectory();

                foreach (EntitySelectModel entitySelectModel in _entities)
                {
                    string controllerPath = Path.Combine(_filepathRes.APIPath, "Controllers", $"{entitySelectModel.Entity}Controller.cs");

                    if (!File.Exists(controllerPath))
                    {
                        GenerateAllFile(entitySelectModel);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                // Handle exception (log, rethrow, etc.)
                return false;
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
            ReplaceStringInFileForDP(entity.Entity);
        }

        public void ReplaceStringInAllFilesInDirectory()
        {
            try
            {
                string oldValue = $"Msc.{_filepathRes.ProjectName}.Service.DataAccess.Contracts.Context";
                string newValue = $"Msc.{_filepathRes.ProjectName}.Service.CommonModel";

                string directoryPath = _filepathRes.CommonModelPath;

                // Get all files in the specified directory
                string[] files = Directory.GetFiles(directoryPath);

                foreach (var filePath in files)
                {
                    // Check if the file exists before proceeding
                    if (File.Exists(filePath))
                    {
                        // Read the file content
                        string fileContent = File.ReadAllText(filePath);

                        // Replace the old value with the new value
                        string updatedContent = fileContent.Replace(oldValue, newValue);

                        // Write the updated content back to the file only if changes were made
                        if (fileContent != updatedContent)
                        {
                            File.WriteAllText(filePath, updatedContent);
                            Console.WriteLine($"File '{filePath}' updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"No changes made in file '{filePath}'. The content was already up to date.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating files: {ex.Message}");
            }
        }


        public void ReplaceStringInFileForDP(string entityName)
        {
            try
            {
                string oldValue1 = "// Business Dependency injection for Service end";
                string oldValue2 = "// DataAccess Dependency injection for Repository end";

                string newValue1 = $"\t\t\tServices.AddScoped<I{entityName}Service, {entityName}Service>();\n\t\t\t{oldValue1}";
                string newValue2 = $"\t\t\tServices.AddScoped<I{entityName}Repository, {entityName}Repository>();\n\t\t\t{oldValue2}";

                string filePath = Path.Combine(_filepathRes.APIPath, "App_Start", "ContainerExtension.cs");

                // Check if the file exists before proceeding
                if (File.Exists(filePath))
                {
                    // Read the file content
                    string fileContent = File.ReadAllText(filePath);

                    // Replace both old values with their respective new values
                    string updatedContent = Regex.Replace(fileContent, Regex.Escape(oldValue1), newValue1);
                    updatedContent = Regex.Replace(updatedContent, Regex.Escape(oldValue2), newValue2);


                    // Write the updated content back to the file only if changes were made
                    if (fileContent != updatedContent)
                    {
                        File.WriteAllText(filePath, updatedContent);
                        Console.WriteLine("File updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No changes made. The content was already up to date.");
                    }
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating file: {ex.Message}");
            }
        }



        public void GenerateDependencyInjection()
        {
            var outputPath = Path.Combine(_filepathRes.APIPath, "App_Start", $"ContainerExtension.cs");
            var DpData = new DependencyInjection().GenerateDependencyInjection(_filepathRes.ProjectName);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty); // Ensure the directory exists
            File.WriteAllText(outputPath, DpData);
        }

        public void MoveFilesExcept()
        {
            try
            {
                var sourceDirectory = Path.Combine(_filepathRes.DataAccessContractPath, "Context");
                var destinationDirectory = Path.Combine(_filepathRes.CommonModelPath);
                string fileToExclude = "AppDbContext.cs";

                // Ensure the destination directory exists
                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                // Get all files in the source directory
                string[] files = Directory.GetFiles(sourceDirectory);

                foreach (string filePath in files)
                {
                    // Get the file name from the full path
                    string fileName = Path.GetFileName(filePath);

                    // Check if the file is the one to exclude
                    if (!fileName.Equals(fileToExclude, StringComparison.OrdinalIgnoreCase))
                    {
                        // Define the destination file path
                        string destinationPath = Path.Combine(destinationDirectory, fileName);

                        // Move the file to the destination directory
                        File.Move(filePath, destinationPath);
                        Console.WriteLine($"Moved: {fileName}");
                    }
                    else
                    {
                        Console.WriteLine($"Skipped: {fileName}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error during file move: {ex.Message}");
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
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty); // Ensure the directory exists
                File.WriteAllText(outputPath, outputContent);
            }
            else
            {
                throw new ArgumentException($"Invalid type: {type}");
            }
        }
    }
}
