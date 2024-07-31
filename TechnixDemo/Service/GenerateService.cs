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

        public async Task<ProjectResponceModel> GenerateAPIProject(string solutionName, string projectName, string outputPath)
        {
            ProjectResponceModel responceModel = new ProjectResponceModel();
            if (string.IsNullOrWhiteSpace(solutionName) || string.IsNullOrWhiteSpace(projectName) || string.IsNullOrWhiteSpace(outputPath))
            {
                Console.WriteLine("Solution name, project name, and output path cannot be empty.");
            }
            
                try
                {
                    UpdateProgress(1);
                    System.Threading.Thread.Sleep(1000); // Simulate work
                    UpdateDataGridView("Create Solution", "Started");
                    var solutionDirectory = Path.Combine(outputPath, solutionName);
                    if (!Directory.Exists(solutionDirectory))
                    {
                        Directory.CreateDirectory(solutionDirectory);
                    }
                    responceModel.SolutionPath = solutionDirectory;
                    ExecuteDotnetCommand($"new sln --name {solutionName}", solutionDirectory);
                    UpdateDataGridView("Create Solution", "Completed");
                    UpdateProgress(5);

                    UpdateDataGridView("Create Web API Project", "Started");
                    var projectDirectory = Path.Combine(solutionDirectory, projectName);
                    responceModel.ProjectPath = projectDirectory;
                    ExecuteDotnetCommand($"new webapi --name {projectName}", solutionDirectory);
                    UpdateDataGridView("Create Web API Project", "Completed");
                    UpdateProgress(20);

                    UpdateDataGridView("Add Project to Solution", "Started");
                    ExecuteDotnetCommand($"sln {solutionName}.sln add {Path.Combine(projectDirectory, $"{projectName}.csproj")}", solutionDirectory);
                    UpdateDataGridView("Add Project to Solution", "Completed");
                    UpdateProgress(25);

                    UpdateDataGridView("Create Project Folders", "Started");
                    var getPaths = CreateProjectFolders(projectDirectory);
                    responceModel.ControllerPath = getPaths.ControllerPath;
                    responceModel.ServicePath = getPaths.ServicePath;
                    responceModel.ModelPath = getPaths.ModelPath;
                    UpdateDataGridView("Create Project Folders", "Completed");
                    UpdateProgress(35);

                    UpdateDataGridView("Open Solution", "Started");
                    OpenSolutionFile(solutionDirectory, solutionName);
                    UpdateDataGridView("Open Solution", "Completed");
                    UpdateProgress(40);
                    responceModel.Status = true;
                }
                catch (Exception ex)
                {
                    UpdateDataGridView("Error", ex.Message);
                    responceModel.Status = false;
                }
            
            return responceModel;

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

        

        private ProjectResponceModel CreateProjectFolders(string projectDirectory)
        {
            ProjectResponceModel responceModel = new ProjectResponceModel();
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


        private void ExecuteDotnetCommand(string arguments, string workingDirectory)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = workingDirectory,
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                Console.WriteLine($"Command: dotnet {arguments}");
                Console.WriteLine($"Output: {output}");
                Console.WriteLine($"Error: {error}");
                throw new InvalidOperationException($"Dotnet command failed: {error}");
            }
        }
    }
}
