using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnixDemo.Model;

namespace TechnixDemo.Templates
{
    internal class ApiTestGenerator
    {
        public string GenerateControllerTests(EntitySelectModel entity)
        {
            var testCode = new StringBuilder();

            testCode.AppendLine($"public class {entity.Entity}ControllerTests");
            testCode.AppendLine("{");

            if (entity.Save)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Save{entity.Entity}()");
                testCode.AppendLine("    {");
                testCode.AppendLine($"        // Arrange");
                testCode.AppendLine($"        // Act");
                testCode.AppendLine($"        // Assert");
                testCode.AppendLine("    }");
            }

            if (entity.Update)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Update{entity.Entity}()");
                testCode.AppendLine("    {");
                testCode.AppendLine($"        // Arrange");
                testCode.AppendLine($"        // Act");
                testCode.AppendLine($"        // Assert");
                testCode.AppendLine("    }");
            }

            if (entity.Delete)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Delete{entity.Entity}()");
                testCode.AppendLine("    {");
                testCode.AppendLine($"        // Arrange");
                testCode.AppendLine($"        // Act");
                testCode.AppendLine($"        // Assert");
                testCode.AppendLine("    }");
            }

            testCode.AppendLine("}");

            return testCode.ToString();
        }
    }
}
