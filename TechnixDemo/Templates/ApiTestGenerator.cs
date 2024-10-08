using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnixDemo.Model;

namespace TechnixDemo.Templates
{
    public class ApiTestGenerator
    {
        public string GenerateApiTest(EntitySelectModel entity, string projectName)
        {
            var testCode = new StringBuilder();

            // Add necessary using statements
            testCode.AppendLine("using NUnit.Framework;");
            testCode.AppendLine("using Moq;");
            testCode.AppendLine($"using Msc.{projectName}.Service.CommonModel;");
            testCode.AppendLine($"using Msc.{projectName}.Service.Business.Contracts;");
            testCode.AppendLine($"using Msc.{projectName}.Service.Controllers;");
            testCode.AppendLine("using Microsoft.AspNetCore.Mvc;");
            testCode.AppendLine("using System.Collections.Generic;");
            testCode.AppendLine();

            testCode.AppendLine($"namespace Msc.{projectName}.Tests");
            testCode.AppendLine("{");
            testCode.AppendLine($"    [TestFixture]");
            testCode.AppendLine($"    public class {entity.Entity}ControllerTests");
            testCode.AppendLine("    {");
            testCode.AppendLine($"        private Mock<I{entity.Entity}Service> _mockService;");
            testCode.AppendLine($"        private {entity.Entity}Controller _controller;");
            testCode.AppendLine();
            testCode.AppendLine($"        [SetUp]");
            testCode.AppendLine("        public void Setup()");
            testCode.AppendLine("        {");
            testCode.AppendLine($"            _mockService = new Mock<I{entity.Entity}Service>();");
            testCode.AppendLine($"            _controller = new {entity.Entity}Controller(_mockService.Object);");
            testCode.AppendLine("        }");
            testCode.AppendLine();

            // Generate test for GetAll method if enabled
            if (entity.GetAll)
            {
                testCode.AppendLine($"        [Test]");
                testCode.AppendLine($"        public void GetAll{entity.Entity}_ReturnsListOfEntities()");
                testCode.AppendLine("        {");
                testCode.AppendLine("            // Arrange");
                testCode.AppendLine($"            var expectedEntities = new List<{entity.Entity}>();");
                testCode.AppendLine($"            _mockService.Setup(s => s.GetAll()).Returns(expectedEntities);");
                testCode.AppendLine();
                testCode.AppendLine("            // Act");
                testCode.AppendLine($"            var result = _controller.GetAll{entity.Entity}();");
                testCode.AppendLine();
                testCode.AppendLine("            // Assert");
                testCode.AppendLine($"            Assert.IsInstanceOf<OkObjectResult>(result);");
                testCode.AppendLine("            var okResult = result as OkObjectResult;");
                testCode.AppendLine($"            Assert.AreEqual(expectedEntities, okResult.Value);");
                testCode.AppendLine("        }");
                testCode.AppendLine();
            }

            // Generate test for GetById method if enabled
            if (entity.GetById)
            {
                testCode.AppendLine($"        [Test]");
                testCode.AppendLine($"        public void Get{entity.Entity}ById_InvalidId_ReturnsNotFound()");
                testCode.AppendLine("        {");
                testCode.AppendLine("            // Arrange");
                testCode.AppendLine($"            _mockService.Setup(s => s.GetById(It.IsAny<int>())).Returns(({entity.Entity})null);");
                testCode.AppendLine();
                testCode.AppendLine("            // Act");
                testCode.AppendLine($"            var result = _controller.Get{entity.Entity}ById(1);");
                testCode.AppendLine();
                testCode.AppendLine("            // Assert");
                testCode.AppendLine("            Assert.IsInstanceOf<NotFoundResult>(result);");
                testCode.AppendLine("        }");
                testCode.AppendLine();

                testCode.AppendLine($"        [Test]");
                testCode.AppendLine($"        public void Get{entity.Entity}ById_ValidId_ReturnsEntity()");
                testCode.AppendLine("        {");
                testCode.AppendLine("            // Arrange");
                testCode.AppendLine($"            var expectedEntity = new {entity.Entity}();");
                testCode.AppendLine($"            _mockService.Setup(s => s.GetById(It.IsAny<int>())).Returns(expectedEntity);");
                testCode.AppendLine();
                testCode.AppendLine("            // Act");
                testCode.AppendLine($"            var result = _controller.Get{entity.Entity}ById(1);");
                testCode.AppendLine();
                testCode.AppendLine("            // Assert");
                testCode.AppendLine("            Assert.IsInstanceOf<OkObjectResult>(result);");
                testCode.AppendLine("            var okResult = result as OkObjectResult;");
                testCode.AppendLine($"            Assert.AreEqual(expectedEntity, okResult.Value);");
                testCode.AppendLine("        }");
                testCode.AppendLine();
            }

            // Generate test for Save method if enabled
            if (entity.Save)
            {
                
                testCode.AppendLine($"        [Test]");
                testCode.AppendLine($"        public void Save{entity.Entity}_ReturnsBadRequest_WhenEntityIsNull()");
                testCode.AppendLine("        {");
                testCode.AppendLine("            // Arrange");
                testCode.AppendLine("            // Act");
                testCode.AppendLine($"            var result = _controller.Save{entity.Entity}(null);");
                testCode.AppendLine();
                testCode.AppendLine("            // Assert");
                testCode.AppendLine($"            Assert.IsInstanceOf<BadRequestResult>(result);");
                testCode.AppendLine("        }");
                testCode.AppendLine();
            }

            // Generate test for Update method if enabled
            if (entity.Update)
            {
               

                testCode.AppendLine($"        [Test]");
                testCode.AppendLine($"        public void Update{entity.Entity}_ReturnsNotFound_WhenUpdateFails()");
                testCode.AppendLine("        {");
                testCode.AppendLine("            // Arrange");
                testCode.AppendLine($"            var entityToUpdate = new {entity.Entity}();");
                testCode.AppendLine($"            _mockService.Setup(s => s.Update(entityToUpdate)).Returns(false);");
                testCode.AppendLine();
                testCode.AppendLine("            // Act");
                testCode.AppendLine($"            var result = _controller.Update{entity.Entity}(entityToUpdate);");
                testCode.AppendLine();
                testCode.AppendLine("            // Assert");
                testCode.AppendLine($"            Assert.IsInstanceOf<NotFoundResult>(result);");
                testCode.AppendLine("        }");
                testCode.AppendLine();
            }

            // Generate test for Delete method if enabled
            if (entity.Delete)
            {
                testCode.AppendLine($"        [Test]");
                testCode.AppendLine($"        public void Delete{entity.Entity}_ReturnsNotFound_WhenInvalidId()");
                testCode.AppendLine("        {");
                testCode.AppendLine("            // Arrange");
                testCode.AppendLine($"            _mockService.Setup(s => s.Delete(It.IsAny<int>())).Returns(false);");
                testCode.AppendLine();
                testCode.AppendLine("            // Act");
                testCode.AppendLine($"            var result = _controller.Delete{entity.Entity}(1);");
                testCode.AppendLine();
                testCode.AppendLine("            // Assert");
                testCode.AppendLine($"            Assert.IsInstanceOf<NotFoundResult>(result);");
                testCode.AppendLine("        }");
                testCode.AppendLine();
            }
            testCode.AppendLine("}");
            testCode.AppendLine("}");

            return testCode.ToString();
        }
    }
}