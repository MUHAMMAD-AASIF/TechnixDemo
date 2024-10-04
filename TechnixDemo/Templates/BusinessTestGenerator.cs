using System.Text;
using TechnixDemo.Model;

namespace TechnixDemo.Templates
{
    public class BusinessTestGenerator
    {
        public string GenerateBusinessTests(EntitySelectModel entity, string ProjectName)
        {
            var testCode = new StringBuilder();

            // Add necessary using statements
            testCode.AppendLine("using NUnit.Framework;");
            testCode.AppendLine("using Moq;");
            testCode.AppendLine($"using Msc.{ProjectName}.Service.CommonModel;");
            testCode.AppendLine($"using Msc.{ProjectName}.Service.Business;");
            testCode.AppendLine($"using Msc.{ProjectName}.Service.DataAccess.Contracts;");
            testCode.AppendLine();
            testCode.AppendLine($"public class {entity.Entity}ServiceTests");
            testCode.AppendLine("{");
            testCode.AppendLine($"    private Mock<I{entity.Entity}Repository> _mockDataAccess;");
            testCode.AppendLine($"    private {entity.Entity}Service _service;");
            testCode.AppendLine();
            testCode.AppendLine($"    [SetUp]");
            testCode.AppendLine("    public void Setup()");
            testCode.AppendLine("    {");
            testCode.AppendLine($"        _mockDataAccess = new Mock<I{entity.Entity}Repository>();");
            testCode.AppendLine($"        _service = new {entity.Entity}Service(_mockDataAccess.Object);");
            testCode.AppendLine("    }");
            testCode.AppendLine();

            // Generate test for GetAll method if enabled
            if (entity.GetAll)
            {
                testCode.AppendLine($"    [Test]");
                testCode.AppendLine($"    public void GetAll{entity.Entity}_ReturnsListOfEntities()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.GetAll()).Returns(new List<{entity.Entity}>());");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.GetAll();");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.That(result, Is.InstanceOf<List<{entity.Entity}>>());");
                testCode.AppendLine("    }");
                testCode.AppendLine();
            }

            // Generate test for GetById method if enabled
            if (entity.GetById)
            {
                testCode.AppendLine($"    [Test]");
                testCode.AppendLine($"    public void Get{entity.Entity}ById_ReturnsEntity_WhenValidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        var entity = new {entity.Entity}();");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.GetById(It.IsAny<int>())).Returns(entity);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.GetById(1);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.That(result, Is.InstanceOf<{entity.Entity}>());");
                testCode.AppendLine("    }");
                testCode.AppendLine();

                testCode.AppendLine($"    [Test]");
                testCode.AppendLine($"    public void Get{entity.Entity}ById_ReturnsNull_WhenInvalidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.GetById(It.IsAny<int>())).Returns(value: null);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.GetById(1);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine("        Assert.That(result, Is.Null);");
                testCode.AppendLine("    }");
                testCode.AppendLine();
            }

            // Generate test for Save method if enabled
            if (entity.Save)
            {
                testCode.AppendLine($"    [Test]");
                testCode.AppendLine($"    public void Save{entity.Entity}_CallsDataAccessSave()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        var entity = new {entity.Entity}();");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        _service.Save(entity);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        _mockDataAccess.Verify(da => da.Save(It.IsAny<{entity.Entity}>()), Times.Once);");
                testCode.AppendLine("    }");
                testCode.AppendLine();
            }

            // Generate test for Update method if enabled
            if (entity.Update)
            {
                testCode.AppendLine($"    [Test]");
                testCode.AppendLine($"    public void Update{entity.Entity}_ReturnsTrue_WhenValidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        var entity = new {entity.Entity}();");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.Update(entity)).Returns(true);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.Update(entity);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.That(result, Is.True);");
                testCode.AppendLine("    }");
                testCode.AppendLine();

                testCode.AppendLine($"    [Test]");
                testCode.AppendLine($"    public void Update{entity.Entity}_ReturnsFalse_WhenInvalidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        var entity = new {entity.Entity}();");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.Update(entity)).Returns(false);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.Update(entity);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.That(result, Is.False);");
                testCode.AppendLine("    }");
                testCode.AppendLine();
            }

            // Generate test for Delete method if enabled
            if (entity.Delete)
            {
                testCode.AppendLine($"    [Test]");
                testCode.AppendLine($"    public void Delete{entity.Entity}_ReturnsTrue_WhenValidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.Delete(It.IsAny<int>())).Returns(true);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.Delete(1);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.That(result, Is.True);");
                testCode.AppendLine("    }");
                testCode.AppendLine();

                testCode.AppendLine($"    [Test]");
                testCode.AppendLine($"    public void Delete{entity.Entity}_ReturnsFalse_WhenInvalidId()");
                testCode.AppendLine("    {");
                testCode.AppendLine("        // Arrange");
                testCode.AppendLine($"        _mockDataAccess.Setup(da => da.Delete(It.IsAny<int>())).Returns(false);");
                testCode.AppendLine();
                testCode.AppendLine("        // Act");
                testCode.AppendLine($"        var result = _service.Delete(1);");
                testCode.AppendLine();
                testCode.AppendLine("        // Assert");
                testCode.AppendLine($"        Assert.That(result, Is.False);");
                testCode.AppendLine("    }");
                testCode.AppendLine();
            }

            testCode.AppendLine("}");

            return testCode.ToString();
        }

    }
}
