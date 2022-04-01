using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sharff.ApiRest.Controllers;
using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.Model;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net;
using Sharff.ApiRest.Models;
using Sharff.Core.Services;
using Sharff.Domain.Model.DbModel;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Shartff.Shared.ApiRest.Test.Controllers
{
    [TestClass]
    public class ExampleControllerTest
    {
        private Mock<IExampleService> serviceMock;

        private Mock<IMapper> mapperMock;

        private Mock<ILogger<ExampleController>> loggerMock;

        [TestInitialize()]
        public void InicializarTest()
        {
            this.serviceMock = new Mock<IExampleService>();
            this.mapperMock = new Mock<IMapper>();
            this.mapperMock.Setup(m => m.Map<ExampleDto, TblExampleFedex>(It.IsAny<ExampleDto>())).Returns(new TblExampleFedex());
            this.mapperMock.Setup(m => m.Map<TblExampleFedex,ExampleDto>(It.IsAny<TblExampleFedex>())).Returns(new ExampleDto());
            this.loggerMock = new Mock<ILogger<ExampleController>>();
        }

        [TestMethod]
        public async Task GetExample_ReturnOK()
        {
            var lista = new List<TblExampleFedex> {
                new TblExampleFedex() { Id = 1, Description = "Test" },
                new TblExampleFedex() { Id = 2, Description = "Test2" }};

            //Arrange
            this.serviceMock.Setup(a => a.GetExampleAsync()).ReturnsAsync(lista);
            var controller = new ExampleController(this.loggerMock.Object, this.mapperMock.Object, this.serviceMock.Object);
            Task<ActionResult> result = controller.GetExample();

            //Act

            //var result = await controller.GetExample();
            //Assert.IsInstanceOfType(ResultDto3);

            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(result.Result);
            //ResultDto m = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDto>(jsonData);

            //Assert
            Assert.AreEqual(lista, result);
        }

        [TestMethod]
        public async Task Create_ReturnOK()
        {
            //Arrange
            var exampleTest = new TblExampleFedex
            {
                Id = 1,
                Description = "Test1"
            };

            var exampleDto = new ExampleDto
            {
                Id = 1,
                Description = "Test1"
            };

            this.serviceMock.Setup(a => a.CreateAsync(exampleTest)).ReturnsAsync(await this.Getcreateresult());
            ExampleController controller = new ExampleController(this.loggerMock.Object, this.mapperMock.Object, this.serviceMock.Object);              

            //Act
            //var result = await controller.Create(this.mapperMock.Object.Map<ExampleDto>(exampleTest));
            var result = await controller.Create(exampleDto);

            //Assert
            Assert.AreEqual("OK", result);
        }

        private async Task<bool> Getcreateresult()
        {
            return await Task.FromResult(true);
        }
    }
}
