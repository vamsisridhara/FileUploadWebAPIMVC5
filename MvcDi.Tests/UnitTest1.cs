using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcDi.Tests.App_Start;
using MvcDI;
using MvcDI.Controllers;
using MvcDI.Models;

namespace MvcDi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private ProductApiController pc;
        [TestInitialize]
        public void MyTestInitialize()
        {
            NinjectWebCommon.Start();

        }
        [TestMethod]
        public void TestMethod1()
        {
            List<ProductVM> list = new List<ProductVM>()
            {
                new ProductVM() { ProductID = 1, ProductName = "Chai"},
                new ProductVM() { ProductID = 12, ProductName = "Chai"}
            };
            var mock = new Mock<IProductRepository>();
            //IProductRepository repo = mock.Object;
            
            mock.Setup(x => x.getProducts(It.IsAny<CategoryInput>())).Returns(list);
            pc = new ProductApiController(mock.Object);
            var result = pc.Index(new CategoryInput() { CategoryID = 1 });
            
            Assert.IsNotNull(result);
        }
    }
}
