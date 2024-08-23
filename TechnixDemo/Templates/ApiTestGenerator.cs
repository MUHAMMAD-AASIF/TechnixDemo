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
        public string GenerateBusinessTests(EntitySelectModel entity, string ProjectName)
        {
            var testCode = new StringBuilder();

            // Add necessary using statements
            testCode.AppendLine("using Xunit;");
            testCode.AppendLine("using Moq;");
            testCode.AppendLine($"using {ProjectName}.Business;");
            testCode.AppendLine($"using {ProjectName}.DataAccess.Contracts;");
            testCode.AppendLine($"using {ProjectName}.Models;");
            testCode.AppendLine();
            testCode.AppendLine($"public class {entity.Entity}ServiceTests");
            testCode.AppendLine("{");
            testCode.AppendLine($"    private readonly Mock<I{entity.Entity}DataAccess> _mockDataAccess;");
            testCode.AppendLine($"    private readonly {entity.Entity}Service _service;");
            testCode.AppendLine();
            testCode.AppendLine($"    public {entity.Entity}ServiceTests()");
            testCode.AppendLine("    {");
            testCode.AppendLine($"        _mockDataAccess = new Mock<I{entity.Entity}DataAccess>();");
            testCode.AppendLine($"        _service = new {entity.Entity}Service(_mockDataAccess.Object);");
            testCode.AppendLine("    }");
            testCode.AppendLine();

            // Generate test for GetAll method if enabled
            if (entity.GetAll)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void GetAll{entity.Entity}_ReturnsListOfEntities()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.GetAll()).Returns(new List<{entity.Entity}Model>());");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.GetAll();");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.IsType<List<{entity.Entity}Model>>(result);");
                testCode.AppendLine("    }");
                testCode.AppendLine();
            }

            // Generate test for GetById method if enabled
            if (entity.GetById)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Get{entity.Entity}ById_ReturnsEntity_WhenValidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        var entity = new {entity.Entity}Model();");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.GetById(It.IsAny<int>())).Returns(entity);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.GetById(1);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.IsType<{entity.Entity}Model>(result);");
                testCode.AppendLine("    }");
                testCode.AppendLine();

                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Get{entity.Entity}ById_ReturnsNull_WhenInvalidId()");
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

            // Generate test for Save method if enabled
            if (entity.Save)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Save{entity.Entity}_CallsDataAccessSave()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        var entity = new {entity.Entity}Model();");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        _service.Save(entity);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        _mockDataAccess.Verify(da => da.Save(It.IsAny<{entity.Entity}Model>()), Times.Once);");
                testCode.AppendLine("    }");
                testCode.AppendLine();
            }

            // Generate test for Update method if enabled
            if (entity.Update)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Update{entity.Entity}_ReturnsTrue_WhenValidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        var entity = new {entity.Entity}Model();");
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
                testCode.AppendLine($"    public void Update{entity.Entity}_ReturnsFalse_WhenInvalidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        var entity = new {entity.Entity}Model();");
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

            // Generate test for Delete method if enabled
            if (entity.Delete)
            {
                testCode.AppendLine($"    [Fact]");
                testCode.AppendLine($"    public void Delete{entity.Entity}_ReturnsTrue_WhenValidId()");
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
                testCode.AppendLine($"    public void Delete{entity.Entity}_ReturnsFalse_WhenInvalidId()");
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
