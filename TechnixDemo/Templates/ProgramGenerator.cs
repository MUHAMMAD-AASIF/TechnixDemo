using System.Text;

namespace TechnixDemo.Templates
{
    public class ProgramGenerator
    {
        public string GenerateProgramFile(string projectName)
        {
            var programCode = new StringBuilder();

            programCode.AppendLine("using Microsoft.EntityFrameworkCore;");
            programCode.AppendLine($"using Msc.{projectName}.Service.Api.App_Start;");
            programCode.AppendLine($"using Msc.{projectName}.Service.DataAccess.Contracts.Context;");
            programCode.AppendLine();
            programCode.AppendLine("var builder = WebApplication.CreateBuilder(args);");
            programCode.AppendLine("builder.Services.AddEndpointsApiExplorer();");
            programCode.AppendLine("builder.Services.AddSwaggerGen();");
            programCode.AppendLine($"builder.Services.AddDbContext<AppDbContext>(options =>");
            programCode.AppendLine($"       options.UseSqlServer(\"Server=HQAPEW1C002-AUZ;Database=technix;User Id=sa;Password=msc123;TrustServerCertificate=True;\"));");
            programCode.AppendLine("ContainerExtension.LoadCustomConfiguration(builder.Services);");
            programCode.AppendLine("builder.Services.AddControllers().AddJsonOptions(options =>");
            programCode.AppendLine("{");
            programCode.AppendLine("    options.JsonSerializerOptions.MaxDepth = 64;");
            programCode.AppendLine("});");
            programCode.AppendLine("builder.Services.AddControllers();");
            programCode.AppendLine();
            programCode.AppendLine("var app = builder.Build();");
            programCode.AppendLine("if (app.Environment.IsDevelopment())");
            programCode.AppendLine("{");
            programCode.AppendLine("    app.UseSwagger();");
            programCode.AppendLine("    app.UseSwaggerUI();");
            programCode.AppendLine("}");
            programCode.AppendLine("app.UseHttpsRedirection();");
            programCode.AppendLine("app.MapControllers();");
            programCode.AppendLine();
            programCode.AppendLine("app.Run();");

            return programCode.ToString();
        }

    }
}
