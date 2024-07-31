using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO.Compression;
using TechnixAPI.Service;
using TechnixModel;

namespace TechnixAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateController : Controller
    {
        [HttpPost]
        public ActionResult<bool> PostGenerateController(GenerateModel Entity)
        {
            GenerateService service = new GenerateService();
            var dfd= service.GenerateFile(Entity);
            return Ok(dfd);
        }


        
        [HttpGet("create-webapi-proj")]
        public ActionResult CreateWebApiProject(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Project name cannot be empty.");
            }
            var FilePath = "C:\\Users\\muhammadaasif.muhamm\\Dev\\Training\\NewTestingProj";
            // Path to the new project directory
            var projectDir = Path.Combine(FilePath, name);
            var zipFilePath = Path.Combine(FilePath, $"{name}.zip");

            try
            {
                // Create the Web API project using dotnet CLI
                var createProjArgs = $"new webapi --name {name}";
                ExecuteDotnetCommand(createProjArgs, FilePath);

                // Zip the project directory
                ZipFile.CreateFromDirectory(projectDir, zipFilePath);

                // Return the zip file as a download
                var fileBytes = System.IO.File.ReadAllBytes(zipFilePath);
                return File(fileBytes, "application/zip", $"{name}.zip");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating and zipping project: {ex.Message}");
            }
            finally
            {
                // Cleanup: delete the zip file and project directory after returning the file
                if (System.IO.File.Exists(zipFilePath))
                {
                    System.IO.File.Delete(zipFilePath);
                }

                if (Directory.Exists(projectDir))
                {
                    Directory.Delete(projectDir, true);
                }
            }
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
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                var error = process.StandardError.ReadToEnd();
                throw new InvalidOperationException($"Dotnet command failed: {error}");
            }
        }
    }
}
