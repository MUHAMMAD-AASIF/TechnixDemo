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

            testCode.AppendLine("using Xunit;");
            testCode.AppendLine("using Moq;");
            testCode.AppendLine($"using YourNamespace.Business;");
            testCode.AppendLine($"using YourNamespace.DataAccess.Contracts;");
            testCode.AppendLine($"using YourNamespace.Models;");
            testCode.AppendLine();
            testCode.AppendLine($"public class {entityName}ServiceTests");
            testCode.AppendLine("{");
            testCode.AppendLine($"    private readonly Mock<I{entityName}DataAccess> _mockDataAccess;");
            testCode.AppendLine($"    private readonly {entityName}Service _service;");
            testCode.AppendLine();
            testCode.AppendLine($"    public {entityName}ServiceTests()");
            testCode.AppendLine("    {");
            testCode.AppendLine($"        _mockDataAccess = new Mock<I{entityName}DataAccess>();");
            testCode.AppendLine($"        _service = new {entityName}Service(_mockDataAccess.Object);");
            testCode.AppendLine("    }");
            testCode.AppendLine();

            if (entity.GetAll)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void GetAll{entityName}_ReturnsListOfEntities()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.GetAll()).Returns(new List<{entityName}Model>());");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.GetAll();");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.IsType<List<{entityName}Model>>(result);");
                testCode.AppendLine("    }");
                testCode.AppendLine();
            }

            if (entity.GetById)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Get{entityName}ById_ReturnsEntity_WhenValidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        var entity = new {entityName}Model();");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.GetById(It.IsAny<int>())).Returns(entity);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.GetById(1);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.IsType<{entityName}Model>(result);");
                testCode.AppendLine("    }");
                testCode.AppendLine();

                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Get{entityName}ById_ReturnsNull_WhenInvalidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.GetById(It.IsAny<int>())).Returns(value: null);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.GetById(1);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine("        Assert.Null(result);");
                testCode.AppendLine("    }");
                testCode.AppendLine();
            }

            if (entity.Save)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Save{entityName}_CallsDataAccessSave()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        var entity = new {entityName}Model();");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        _service.Save(entity);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        _mockDataAccess.Verify(da => da.Save(It.IsAny<{entityName}Model>()), Times.Once);");
                testCode.AppendLine("    }");
                testCode.AppendLine();
            }

            if (entity.Update)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Update{entityName}_ReturnsTrue_WhenValidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        var entity = new {entityName}Model();");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.Update(It.IsAny<int>(), entity)).Returns(true);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.Update(1, entity);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.True(result);");
                testCode.AppendLine("    }");
                testCode.AppendLine();

                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Update{entityName}_ReturnsFalse_WhenInvalidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        var entity = new {entityName}Model();");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.Update(It.IsAny<int>(), entity)).Returns(false);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.Update(1, entity);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.False(result);");
                testCode.AppendLine("    }");
                testCode.AppendLine();
            }

            if (entity.Delete)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Delete{entityName}_ReturnsTrue_WhenValidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.Delete(It.IsAny<int>())).Returns(true);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.Delete(1);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.True(result);");
                testCode.AppendLine("    }");
                testCode.AppendLine();

                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Delete{entityName}_ReturnsFalse_WhenInvalidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.Delete(It.IsAny<int>())).Returns(false);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.Delete(1);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.False(result);");
                testCode.AppendLine("    }");
                testCode.AppendLine();
            }

            testCode.AppendLine("}");

            return testCode.ToString();
        }

    }
}
