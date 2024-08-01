using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechnixDemo.Model;
using System.Data;
using System.Data.SqlClient;

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
                UpdateProgress(5);

                // Create Web API Project
                UpdateDataGridView("Create Web API Project", "Started");
                var webApiProjectDirectory = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.Api");
                responseModel.ProjectPath = webApiProjectDirectory;
                await ExecuteDotnetCommandAsync($"new webapi --name Msc.{projectName}.Service.Api", solutionDirectory);
                UpdateDataGridView("Create Web API Project", "Completed");
                UpdateProgress(15);

                // Create Blazor Server Project
                UpdateDataGridView("Create Blazor Server Project", "Started");
                var blazorServerProjectDirectory = Path.Combine(solutionDirectory, $"Msc.{projectName}.Client");
                await ExecuteDotnetCommandAsync($"new blazorserver --name Msc.{projectName}.Client", solutionDirectory);
                UpdateDataGridView("Create Blazor Server Project", "Completed");
                UpdateProgress(25);

                // Create Class Library Projects
                var classLibraryNames = new[] { "Business", "Business.Contracts", "CommonModel", "DataAccess", "DataAccess.Contracts" };
                foreach (var libraryName in classLibraryNames)
                {
                    UpdateDataGridView($"Create {libraryName} Class Library", "Started");
                    var classLibraryDirectory = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.{libraryName}");
                    await ExecuteDotnetCommandAsync($"new classlib --name Msc.{projectName}.Service.{libraryName}", solutionDirectory);
                    UpdateDataGridView($"Create {libraryName} Class Library", "Completed");
                    UpdateProgress(25 + Array.IndexOf(classLibraryNames, libraryName) * 10);
                }

                // Create NUnit Test Projects
                var testProjectNames = new[] { "Api", "Business" };
                foreach (var testName in testProjectNames)
                {
                    UpdateDataGridView($"Create NUnit {testName} Test Project", "Started");
                    var testProjectDirectory = Path.Combine(solutionDirectory, $"Msc.{projectName}.Service.{testName}.Test");
                    await ExecuteDotnetCommandAsync($"new nunit --name Msc.{projectName}.Service.{testName}.Test", solutionDirectory);
                    UpdateDataGridView($"Create NUnit {testName} Test Project", "Completed");
                }
                UpdateProgress(55);

                // Add projects to solution
                UpdateDataGridView("Add Projects to Solution", "Started");
                var projectPaths = new List<string>
                    {
                        Path.Combine(webApiProjectDirectory, $"{projectName}.Api.csproj"),
                        Path.Combine(blazorServerProjectDirectory, $"{projectName}.BlazorServer.csproj"),
                        Path.Combine(solutionDirectory, $"{projectName}.Business", $"{projectName}.Business.csproj"),
                        Path.Combine(solutionDirectory, $"{projectName}.Business.Contracts", $"{projectName}.Business.Contracts.csproj"),
                        Path.Combine(solutionDirectory, $"{projectName}.CommonModel", $"{projectName}.CommonModel.csproj"),
                        Path.Combine(solutionDirectory, $"{projectName}.DataAccess", $"{projectName}.DataAccess.csproj"),
                        Path.Combine(solutionDirectory, $"{projectName}.DataAccess.Contracts", $"{projectName}.DataAccess.Contracts.csproj"),
                        Path.Combine(solutionDirectory, $"{projectName}.Api.Tests", $"{projectName}.Api.Tests.csproj"),
                        Path.Combine(solutionDirectory, $"{projectName}.Business.Tests", $"{projectName}.Business.Tests.csproj")
                    };

                foreach (var projectPath in projectPaths)
                {
                    await ExecuteDotnetCommandAsync($"sln {solutionName}.sln add {projectPath}", solutionDirectory);
                }
                UpdateDataGridView("Add Projects to Solution", "Completed");
                UpdateProgress(80);

                // Create Project Folders (for Web API Project)
                UpdateDataGridView("Create Project Folders", "Started");
                var getPaths = CreateProjectFolders(webApiProjectDirectory);
                responseModel.ControllerPath = getPaths.ControllerPath;
                responseModel.ServicePath = getPaths.ServicePath;
                responseModel.ModelPath = getPaths.ModelPath;
                UpdateDataGridView("Create Project Folders", "Completed");
                UpdateProgress(90);

                // Add References Between Projects
                await AddReferencesBetweenProjects(solutionDirectory, projectName, classLibraryNames);
                await AddTestProjectReferences(solutionDirectory, projectName, testProjectNames, classLibraryNames);

                // Open Solution
                UpdateDataGridView("Open Solution", "Started");
                OpenSolutionFile(solutionDirectory, solutionName);
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


        private async Task AddReferencesBetweenProjects(string solutionDirectory, string projectName, string[] classLibraryProjects)
        {
            foreach (var lib in classLibraryProjects)
            {
                var libProjectPath = Path.Combine(solutionDirectory, $"{projectName}.{lib}", $"{projectName}.{lib}.csproj");
                foreach (var refLib in classLibraryProjects)
                {
                    if (lib != refLib)
                    {
                        var refProjectPath = Path.Combine(solutionDirectory, $"{projectName}.{refLib}", $"{projectName}.{refLib}.csproj");
                        await ExecuteDotnetCommandAsync($"add {libProjectPath} reference {refProjectPath}", solutionDirectory);
                    }
                }
                // Add references to the Web API project
                var apiProjectPath = Path.Combine(solutionDirectory, $"{projectName}.Api", $"{projectName}.Api.csproj");
                await ExecuteDotnetCommandAsync($"add {apiProjectPath} reference {libProjectPath}", solutionDirectory);
            }
        }

        private async Task AddTestProjectReferences(string solutionDirectory, string projectName, string[] testProjects, string[] classLibraryProjects)
        {
            foreach (var test in testProjects)
            {
                var testProjectPath = Path.Combine(solutionDirectory, $"{projectName}.{test}.Tests", $"{projectName}.{test}.Tests.csproj");
                string targetProjectName = test;
                var targetProjectPath = Path.Combine(solutionDirectory, $"{projectName}.{targetProjectName}", $"{projectName}.{targetProjectName}.csproj");

                if (targetProjectName == "Api")
                {
                    targetProjectPath = Path.Combine(solutionDirectory, $"{projectName}.Api", $"{projectName}.Api.csproj");
                }

                await ExecuteDotnetCommandAsync($"add {testProjectPath} reference {targetProjectPath}", solutionDirectory);
            }
        }


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



        private ProjectResponseModel CreateProjectFolders(string projectDirectory)
        {
            ProjectResponseModel responceModel = new ProjectResponseModel();
            var apiPath = Path.Combine(projectDirectory, "API");
            var controllersPath = Path.Combine(apiPath, "Controllers");
            var businessPath = Path.Combine(projectDirectory, "Business");
            var servicePath = Path.Combine(businessPath, "Service");
            var dataAccessPath = Path.Combine(projectDirectory, "DataAccess");
            var modelsPath = Path.Combine(dataAccessPath, "Models");

            Directory.CreateDirectory(apiPath);
            Directory.CreateDirectory(controllersPath);
            Directory.CreateDirectory(businessPath);
            Directory.CreateDirectory(servicePath);
            Directory.CreateDirectory(dataAccessPath);
            Directory.CreateDirectory(modelsPath);

            responceModel.ControllerPath = controllersPath;
            responceModel.ServicePath = servicePath;
            responceModel.ModelPath = modelsPath;


            return responceModel;
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
