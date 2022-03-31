using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sharff.ApiRest.Controllers;
using Sharff.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shartff.Shared.ApiRest.Test.Controllers
{
    [TestClass]
    public class LogControllerTest
    {
        private Mock<ILogService> serviceMock;

        private Mock<IMapper> mapperMock;

        private Mock<ILogger<LogController>> loggerMock;


        [TestInitialize()]
        public void InicializarTest()
        {
            this.serviceMock = new Mock<ILogService>();
            this.mapperMock = new Mock<IMapper>();
            this.loggerMock = new Mock<ILogger<LogController>>();

        }

        [TestMethod]
        public async Task GetFech(DateTime? fecha)
        {
            //Arrange
            var controller = new LogController(this.loggerMock.Object, this.mapperMock.Object, this.serviceMock.Object);

            //Act
            var result = await controller.GetFech(fecha);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}

