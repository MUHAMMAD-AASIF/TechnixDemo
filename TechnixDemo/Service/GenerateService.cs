
using System.Diagnostics;
using System.Text;
using TechnixDemo.Model;

namespace TechnixDemo.Service
{
    public class GenerateService
    {
        private DataGridView _dataGridView;
        private ProgressBar _progressBar;
        public GenerateService(DataGridView dataGridView, ProgressBar progressBar)
        {
            _dataGridView = dataGridView;
            _progressBar = progressBar;
        }

        public async Task<ProjectResponseModel> GenerateAPIProjectAsync(string solutionName, string projectName, string outputPath)
        {
            var responseModel = new ProjectResponseModel();

            if (string.IsNullOrWhiteSpace(solutionName) || string.IsNullOrWhiteSpace(projectName) || string.IsNullOrWhiteSpace(outputPath))
            {
                Console.WriteLine("Solution name, project name, and output path cannot be empty.");
                responseModel.Status = false;
                return responseModel;
            }

            try
            {
                UpdateProgress(1);
                UpdateDataGridView("Create Solution", "Started");

                var solutionDirectory = Path.Combine(outputPath, solutionName);
                if (!Directory.Exists(solutionDirectory))
                {
                    Directory.CreateDirectory(solutionDirectory);
                }
                responseModel.SolutionPath = solutionDirectory;
                await ExecuteDotnetCommandAsync($"new sln --name Msc.{solutionName}.Service", solutionDirectory);
                UpdateDataGridView("Create Solution", "Completed");
                UpdateProgress(10);

                // Create Web API Project
                UpdateDataGridView("Create Web API Project", "Started");
                var webApiProjectDirectory = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.Api");
                responseModel.ProjectPath = webApiProjectDirectory;
                await ExecuteDotnetCommandAsync($"new webapi --name Msc.{projectName}.Service.Api", solutionDirectory);
                UpdateDataGridView("Create Web API Project", "Completed");
                UpdateProgress(20);

                // Create Class Library Projects
                var classLibraryNames = new[] { "Business", "Business.Contracts", "CommonModel", "DataAccess", "DataAccess.Contracts" };
                foreach (var libraryName in classLibraryNames)
                {
                    UpdateDataGridView($"Create {libraryName} Class Library", "Started");
                    var classLibraryDirectory = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.{libraryName}");
                    await ExecuteDotnetCommandAsync($"new classlib --name Msc.{projectName}.Service.{libraryName}", solutionDirectory);
                    UpdateDataGridView($"Create {libraryName} Class Library", "Completed");
                    UpdateProgress(20 + Array.IndexOf(classLibraryNames, libraryName) * 5);
                }

                // Create NUnit Test Projects
                var testProjectNames = new[] { "Api", "Business" };
                foreach (var testName in testProjectNames)
                {
                    UpdateDataGridView($"Create NUnit Msc.{testName} Test Project", "Started");
                    var testProjectDirectory = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.{testName}.Test");
                    await ExecuteDotnetCommandAsync($"new nunit --name Msc.{projectName}.Service.{testName}.Test", solutionDirectory);
                    UpdateDataGridView($"Create NUnit {testName} Test Project", "Completed");
                    UpdateProgress(40 + Array.IndexOf(testProjectNames, testName) * 5);
                }

                // Add projects to solution
                UpdateDataGridView("Add Projects to Solution", "Started");
                var projectPaths = new List<string>
                {
                    Path.Combine(webApiProjectDirectory, $"Msc.{projectName}.Service.Api.csproj"),
                    Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.Business", $"Msc.{projectName}.Service.Business.csproj"),
                    Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.Business.Contracts", $"Msc.{projectName}.Service.Business.Contracts.csproj"),
                    Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.CommonModel", $"Msc.{projectName}.Service.CommonModel.csproj"),
                    Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.DataAccess", $"Msc.{projectName}.Service.DataAccess.csproj"),
                    Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.DataAccess.Contracts", $"Msc.{projectName}.Service.DataAccess.Contracts.csproj"),
                    Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.Api.Test", $"Msc.{projectName}.Service.Api.Test.csproj"),
                    Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.Business.Test", $"Msc.{projectName}.Service.Business.Test.csproj")
                };

                foreach (var projectPath in projectPaths)
                {
                    await ExecuteDotnetCommandAsync($"sln {Path.Combine(solutionDirectory, $"Msc.{solutionName}.Service.sln")} add {projectPath}", solutionDirectory);
                }
                UpdateDataGridView("Add Projects to Solution", "Completed");
                UpdateProgress(60);

                // Create Project Folders (for Web API Project)
                UpdateDataGridView("Create Project Folders", "Started");
                responseModel.APIPath = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.Api");
                responseModel.BusinessPath = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.Business");
                responseModel.BusinessContractPath = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.Business.Contracts");
                responseModel.CommonModelPath = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.CommonModel");
                responseModel.DataAccessPath = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.DataAccess");
                responseModel.DataAccessContractPath = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.DataAccess.Contracts");
                responseModel.APITestPath = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.API.Test");
                responseModel.BusinessTestPath = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.Business.Test");
                UpdateDataGridView("Create Project Folders", "Completed");
                UpdateProgress(70);

                // Add References Between Projects
                await AddReferencesBetweenProjects(solutionDirectory, projectName);
                UpdateProgress(80);

                // Open Solution
                UpdateDataGridView("Open Solution", "Started");
                OpenSolutionFile(solutionDirectory, $"Msc.{solutionName}.Service");
                UpdateDataGridView("Open Solution", "Completed");
                UpdateProgress(100);

                responseModel.Status = true;
            }
            catch (Exception ex)
            {
                UpdateDataGridView("Error", ex.Message);
                responseModel.Status = false;
            }

            return responseModel;
        }

        #region Adding Reference between all Projects 

        private async Task AddReferencesBetweenProjects(string solutionDirectory, string projectName)
        {
            // Define references based on the project
            var projectReferences = new Dictionary<string, List<string>>()
            {
                { "Api", new List<string> { "Business", "Business.Contracts", "CommonModel", "DataAccess", "DataAccess.Contracts" } },
                { "Api.Test", new List<string> { "Api", "CommonModel" } },
                { "Business", new List<string> { "Business.Contracts", "CommonModel", "DataAccess", "DataAccess.Contracts" } },
                { "Business.Contracts", new List<string> { "CommonModel", "DataAccess.Contracts" } },
                { "Business.Test", new List<string> { "Business", "Business.Contracts", "CommonModel", "DataAccess", "DataAccess.Contracts" } },
                { "DataAccess", new List<string> { "Business.Contracts", "CommonModel", "DataAccess.Contracts" } },
                { "DataAccess.Contracts", new List<string> { "CommonModel" } }
            };

            foreach (var project in projectReferences)
            {
                var projectPath = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.{project.Key}", $"Msc.{projectName}.Service.{project.Key}.csproj");

                foreach (var reference in project.Value)
                {
                    var referencePath = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.{reference}", $"Msc.{projectName}.Service.{reference}.csproj");
                    await ExecuteDotnetCommandAsync($"add {projectPath} reference {referencePath}", solutionDirectory);
                }
            }
        }

        #endregion

        private void UpdateDataGridView(string step, string status)
        {
            if (_dataGridView.InvokeRequired)
            {
                _dataGridView.Invoke(new Action(() => AddRowToDataGridView(step, status)));
            }
            else
            {
                AddRowToDataGridView(step, status);
            }
        }

        private void UpdateProgress(int progress)
        {
            if (_progressBar.InvokeRequired)
            {
                _progressBar.Invoke(new Action(() => UpdateToProgressBar(progress)));
            }
            else
            {
                UpdateToProgressBar(progress);
            }
        }

        private void AddRowToDataGridView(string step, string status)
        {
            _dataGridView.Rows.Add(step, status);
        }

        private void UpdateToProgressBar(int progress)
        {
            _progressBar.Value = progress;
        }

        private void OpenSolutionFile(string solutionDirectory, string solutionName)
        {
            string solutionPath = Path.Combine(solutionDirectory, $"{solutionName}.sln");
            if (File.Exists(solutionPath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = solutionPath,
                        UseShellExecute = true // Use the system's default application (usually Visual Studio)
                    });
                    Console.WriteLine($"Solution {solutionName}.sln opened successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to open the solution file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Solution file not found at {solutionPath}");
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
                case "DateTime": return "DateTime";
                // Add more cases as needed
                default: return clrType;
            }
        }

        private async Task ExecuteDotnetCommandAsync(string command, string workingDirectory)
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/C dotnet {command}";
                process.StartInfo.WorkingDirectory = workingDirectory;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                var outputBuilder = new StringBuilder();
                var errorBuilder = new StringBuilder();

                process.OutputDataReceived += (sender, args) => outputBuilder.AppendLine(args.Data);
                process.ErrorDataReceived += (sender, args) => errorBuilder.AppendLine(args.Data);

                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync();

                if (process.ExitCode != 0)
                {
                    var errorOutput = errorBuilder.ToString();
                    throw new Exception($"Dotnet command failed with exit code {process.ExitCode}: {errorOutput}");
                }
            }
        }
    }
}
