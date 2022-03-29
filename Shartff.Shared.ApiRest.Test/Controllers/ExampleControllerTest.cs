using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sharff.ApiRest.Controllers;
using Sharff.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Shartff.Shared.ApiRest.Test.Controllers
{
    [TestClass]
    public class ExampleControllerTest
    {
        private Mock<IExampleService> serviceMock;

        private Mock<IMapper> mapperMock;

        private Mock<ILogger<ExampleController>> loggerMock;

        private Mock<ILogService> logServicio;

        [TestInitialize()]
        public void InicializarTest()
        {
            this.serviceMock = new Mock<IExampleService>();
            this.mapperMock = new Mock<IMapper>();
            this.loggerMock = new Mock<ILogger<ExampleController>>();
            this.logServicio = new Mock<ILogService>();
        }

        [TestMethod]
        public async Task GetExample()
        {
            //Arrange
            var controller = new ExampleController(this.loggerMock.Object, this.logServicio.Object, this.mapperMock.Object, this.serviceMock.Object);

            //Act
            var result = await controller.GetExample();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
