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
        {
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
            DpCode.AppendLine("\tpublic static class ContainerExtension");
            DpCode.AppendLine("\t{");
            DpCode.AppendLine("\t\tpublic static void LoadCustomConfiguration(IServiceCollection Services)");
            DpCode.AppendLine("\t\t{");
            DpCode.AppendLine("\t\t\tif (Services == null)");
            DpCode.AppendLine("\t\t\t{");
            DpCode.AppendLine("\t\t\t\tthrow new ArgumentNullException(nameof(Services));");
            DpCode.AppendLine("\t\t\t}");
            DpCode.AppendLine();
            DpCode.AppendLine("\t\t\t// Business Dependency injection for Service start");
            DpCode.AppendLine("\t\t\t// Business Dependency injection for Service end");
            DpCode.AppendLine();
            DpCode.AppendLine("\t\t\t// DataAccess Dependency injection for Repository start");
            DpCode.AppendLine("\t\t\t// DataAccess Dependency injection for Repository end");
            DpCode.AppendLine("\t\t}");
            DpCode.AppendLine("\t}");
            DpCode.AppendLine("}");

            return DpCode.ToString();
        }

    }
}
