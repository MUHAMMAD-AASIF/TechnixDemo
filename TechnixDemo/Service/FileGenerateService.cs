using System.Diagnostics;
using System.Text.RegularExpressions;
using TechnixDemo.Model;
using TechnixDemo.Templates;

namespace TechnixDemo.Service
{
    public class FileGenerateService
    {
        private readonly List<EntitySelectModel> _entities;
        private readonly ProjectResponseModel _filePathRes;
        public FileGenerateService(List<EntitySelectModel> entities, ProjectResponseModel filePathRes)
        {
            _entities = entities;
            _filePathRes = filePathRes;
        }

        public bool ProcessFileGeneration()
        {
            try
            {
                string containerExtensionPath = Path.Combine(_filePathRes.APIPath, "App_Start", "ContainerExtension.cs");

                // Generate Dependency Injection file if it doesn't exist
                if (!File.Exists(containerExtensionPath))
                {
                    GenerateDependencyInjectionFile();

                    string outputPath = Path.Combine(_filePathRes.APIPath, "Program.cs"); 

                    if (File.Exists(outputPath))
                    {
                        SaveProgramFile(_filePathRes.ProjectName, outputPath);
                    }
                }

                string appDbContextPath = Path.Combine(_filePathRes.DataAccessContractPath, "Context", "AppDbContext.cs");

                // Move files except AppDbContext.cs if the file exists
                if (File.Exists(appDbContextPath))
                {
                    MoveOtherFilesExceptAppDbContext();
                }

                // Update file content in the directory
                UpdateCommonModelFileReferences();

                // Generate required files for each entity
                foreach (var entity in _entities)
                {
                    string controllerPath = Path.Combine(_filePathRes.APIPath, "Controllers", $"{entity.Entity}Controller.cs");

                    if (!File.Exists(controllerPath))
                    {
                        GenerateEntityFiles(entity);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                // Log or handle exception
                return false;
            }
        }

        public void GenerateEntityFiles(EntitySelectModel entity)
        {
            var fileTemplates = new Dictionary<string, string>
            {
                { "Controller", Path.Combine(_filePathRes.APIPath, "Controllers", $"{entity.Entity}Controller.cs") },
                { "Business", Path.Combine(_filePathRes.BusinessPath, $"{entity.Entity}Service.cs") },
                { "Business.Contracts", Path.Combine(_filePathRes.BusinessContractPath, "Interfaces", $"I{entity.Entity}Service.cs") },
                { "DataAccess", Path.Combine(_filePathRes.DataAccessPath, $"{entity.Entity}Repository.cs") },
                { "DataAccess.Contracts", Path.Combine(_filePathRes.DataAccessContractPath, "Interfaces", $"I{entity.Entity}Repository.cs") },
                { "API.Test", Path.Combine(_filePathRes.APITestPath, "UnitTest", $"{entity.Entity}ControllerUnitTest.cs") },
                { "Business.Test", Path.Combine(_filePathRes.BusinessTestPath, "UnitTest", $"{entity.Entity}ServiceUnitTest.cs") }
            };

            foreach (var template in fileTemplates)
            {
                GenerateFileFromTemplate(template.Key, template.Value, entity);
            }

            UpdateDependencyInjectionForEntity(entity.Entity);
        }

        public void SaveProgramFile(string projectName, string filePath)
        {
            string programCode = new ProgramGenerator().GenerateProgramFile(projectName);
            File.WriteAllText(filePath, programCode);
        }

        public void UpdateCommonModelFileReferences()
        {
            try
            {
                string oldNamespace = $"Msc.{_filePathRes.ProjectName}.Service.DataAccess.Contracts.Context";
                string newNamespace = $"Msc.{_filePathRes.ProjectName}.Service.CommonModel";
                string directoryPath = _filePathRes.CommonModelPath;

                foreach (var filePath in Directory.GetFiles(directoryPath))
                {
                    if (File.Exists(filePath))
                    {
                        string fileContent = File.ReadAllText(filePath);
                        string updatedContent = fileContent.Replace(oldNamespace, newNamespace);

                        if (!fileContent.Equals(updatedContent))
                        {
                            File.WriteAllText(filePath, updatedContent);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating files: {ex.Message}");
            }
        }

        public void UpdateDependencyInjectionForEntity(string entityName)
        {
            try
            {
                string businessInjectionPoint = "// Business Dependency injection for Service end";
                string dataAccessInjectionPoint = "// DataAccess Dependency injection for Repository end";

                string businessInjectionCode = $"\t\t\tServices.AddScoped<I{entityName}Service, {entityName}Service>();\n\t\t\t{businessInjectionPoint}";
                string dataAccessInjectionCode = $"\t\t\tServices.AddScoped<I{entityName}Repository, {entityName}Repository>();\n\t\t\t{dataAccessInjectionPoint}";

                string containerExtensionPath = Path.Combine(_filePathRes.APIPath, "App_Start", "ContainerExtension.cs");

                if (File.Exists(containerExtensionPath))
                {
                    string fileContent = File.ReadAllText(containerExtensionPath);
                    string updatedContent = Regex.Replace(fileContent, Regex.Escape(businessInjectionPoint), businessInjectionCode);
                    updatedContent = Regex.Replace(updatedContent, Regex.Escape(dataAccessInjectionPoint), dataAccessInjectionCode);

                    if (!fileContent.Equals(updatedContent))
                    {
                        File.WriteAllText(containerExtensionPath, updatedContent);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating file: {ex.Message}");
            }
        }

        public void GenerateDependencyInjectionFile()
        {
            string outputPath = Path.Combine(_filePathRes.APIPath, "App_Start", "ContainerExtension.cs");
            string dpCode = new DependencyInjection().GenerateDependencyInjection(_filePathRes.ProjectName);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);
            File.WriteAllText(outputPath, dpCode);
        }

        public void MoveOtherFilesExceptAppDbContext()
        {
            try
            {
                var sourceDirectory = Path.Combine(_filePathRes.DataAccessContractPath, "Context");
                var destinationDirectory = _filePathRes.CommonModelPath;
                string excludedFile = "AppDbContext.cs";

                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                foreach (var filePath in Directory.GetFiles(sourceDirectory))
                {
                    string fileName = Path.GetFileName(filePath);

                    if (!fileName.Equals(excludedFile, StringComparison.OrdinalIgnoreCase))
                    {
                        string destinationPath = Path.Combine(destinationDirectory, fileName);
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
                Console.WriteLine($"Error during file move: {ex.Message}");
            }
        }

        private void GenerateFileFromTemplate(string type, string outputPath, EntitySelectModel entity)
        {
            var generators = new Dictionary<string, Func<string>>
            {
                { "Controller", () => new ApiGenerator().GenerateController(entity, _filePathRes.ProjectName) },
                { "Business", () => new BusinessGenerator().GenerateBusiness(entity, _filePathRes.ProjectName) },
                { "Business.Contracts", () => new BusinessContractGenerator().GenerateBusinessContract(entity, _filePathRes.ProjectName) },
                { "DataAccess", () => new DataAccessGenerator().GenerateDataAccess(entity, _filePathRes.ProjectName) },
                { "DataAccess.Contracts", () => new DataAccessContractGenerator().GenerateDataAccessContract(entity, _filePathRes.ProjectName) },
                { "API.Test", () => new ApiTestGenerator().GenerateApiTest(entity, _filePathRes.ProjectName) },
                { "Business.Test", () => new BusinessTestGenerator().GenerateBusinessTests(entity, _filePathRes.ProjectName) }
            };

            if (generators.TryGetValue(type, out var generator))
            {
                string fileContent = generator();
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);
                File.WriteAllText(outputPath, fileContent);
            }
            else
            {
                throw new ArgumentException($"Invalid file type: {type}");
            }
        }

        public void RunScaffold()
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "ef dbcontext scaffold \"Your_Connection_String\" Microsoft.EntityFrameworkCore.SqlServer -o Models",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(processInfo))
            {
                process.OutputDataReceived += (sender, args) => Console.WriteLine(args.Data);
                process.BeginOutputReadLine();
                process.WaitForExit();
            }
        }

    }
}
