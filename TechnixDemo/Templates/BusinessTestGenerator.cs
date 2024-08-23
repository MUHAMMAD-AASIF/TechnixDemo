using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnixDemo.Model;

namespace TechnixDemo.Templates
{
    public class BusinessTestGenerator
    {
        public string GenerateBusinessTests(string entityName, EntitySelectModel entity)
        {
            var testCode = new StringBuilder();

            testCode.AppendLine($"public class {entityName}ServiceTests");
            testCode.AppendLine("{");

            if (entity.Save)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Save_ShouldSave{entityName}()");
                testCode.AppendLine("    {");
                testCode.AppendLine($"        // Arrange");
                testCode.AppendLine($"        // Act");
                testCode.AppendLine($"        // Assert");
                testCode.AppendLine("    }");
            }

            if (entity.Update)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Update_ShouldUpdate{entityName}()");
                testCode.AppendLine("    {");
                testCode.AppendLine($"        // Arrange");
                testCode.AppendLine($"        // Act");
                testCode.AppendLine($"        // Assert");
                testCode.AppendLine("    }");
            }

            if (entity.Delete)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Delete_ShouldDelete{entityName}()");
                testCode.AppendLine("    {");
                testCode.AppendLine($"        // Arrange");
                testCode.AppendLine($"        // Act");
                testCode.AppendLine($"        //Assert");
                testCode.AppendLine("    }");
            }
            testCode.AppendLine("}");

            return testCode.ToString();
        }
    }
}
