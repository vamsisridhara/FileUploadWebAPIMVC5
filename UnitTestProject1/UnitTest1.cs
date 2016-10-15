using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
        }
    }
    public class DefaultPageFixture
    {

        private readonly MockRepository _Mockery;
        private readonly Mock<HttpContextBase> context;
        private readonly Mock<HttpResponseBase> response;
        private readonly Mock<HttpRequestBase> request;

        public DefaultPageFixture()
        {

            _Mockery = new MockRepository(MockBehavior.Loose);

            context = _Mockery.Create<HttpContextBase>();

            response = _Mockery.Create<HttpResponseBase>();
            context.SetupGet(c => c.Response).Returns(response.Object);
            context.SetupGet(c => c.IsDebuggingEnabled).Returns(true);

            request = _Mockery.Create<HttpRequestBase>();
            context.SetupGet(c => c.Request).Returns(request.Object);

        }

        [Fact]
        public void VerifyIsInTestModeIsSetInHttpContextCurrent()
        {

            // Arrange
            WebApplicationProxy.SubstituteDummyHttpContext("/");

            // Act
            HttpContext testContext = HttpContext.Current;

            // Assert
            Assert.NotNull(testContext);
            Assert.True(testContext.Items.Contains("IsInTestMode"));

        }

    }
    public class TestablePage : System.Web.UI.Page
    {
        private HttpContextBase _Context;
        public new System.Web.HttpContextBase Context
        {
            get
            {
                if (_Context == null) _Context = new System.Web.HttpContextWrapper(System.Web.HttpContext.Current);
                return _Context;
            }
            set { _Context = value; }
        }
    }
}
