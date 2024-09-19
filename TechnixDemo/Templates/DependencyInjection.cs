using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnixDemo.Model;

namespace TechnixDemo.Templates
{
    public class DependencyInjection
    {
        public string GenerateDependencyInjection(string projectName)
        {// Assuming project name is BMS; replace it with the actual project name if needed.
            var DpCode = new StringBuilder();

            DpCode.AppendLine("using Microsoft.IdentityModel.Tokens;");
            DpCode.AppendLine($"using Msc.{projectName}.Service.Business.Contracts;");
            DpCode.AppendLine($"using Msc.{projectName}.Service.Business;");
            DpCode.AppendLine($"using Msc.{projectName}.Service.DataAccess.Contracts;");
            DpCode.AppendLine($"using Msc.{projectName}.Service.DataAccess;");
            DpCode.AppendLine("using static System.Net.Mime.MediaTypeNames;");
            DpCode.AppendLine();
            DpCode.AppendLine($"namespace Msc.{projectName}.Service.Api.App_Start");
            DpCode.AppendLine("{");
            DpCode.AppendLine("    public static class ContainerExtension");
            DpCode.AppendLine("    {");
            DpCode.AppendLine("        public static void LoadCustomConfiguration(IServiceCollection Services)");
            DpCode.AppendLine("        {");
            DpCode.AppendLine("            if (Services == null)");
            DpCode.AppendLine("            {");
            DpCode.AppendLine("                throw new ArgumentNullException(nameof(Services));");
            DpCode.AppendLine("            }");
            DpCode.AppendLine("            // Business Dependency injection for Service start");
            DpCode.AppendLine("            // Business Dependency injection for Service end");
            DpCode.AppendLine();
            DpCode.AppendLine("            // DataAccess Dependency injection for Repository start");
            DpCode.AppendLine("            // DataAccess Dependency injection for Repository end");
            DpCode.AppendLine("        }");
            DpCode.AppendLine("    }");
            DpCode.AppendLine("}");

            return DpCode.ToString();
        }
    }
}
