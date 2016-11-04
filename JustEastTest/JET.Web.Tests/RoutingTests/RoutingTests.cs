using System.Web;
using System.Web.Routing;
using JET.UnityDependency;
using NUnit.Framework;
using Rhino.Mocks;

namespace JET.Web.Tests.RoutingTests
{
    [TestFixture]
    public class RoutingTest
    {
        [TearDown]
        public void TearDown()
        {
            UnityDependencyContainer.GetCurrent().Clear();
        }

        [Test]
        public void Test_Route_To_Home_Page()
        {
            var mockContext = MockRepository.GenerateMock<HttpContextBase>();
            mockContext.Expect(x => x.Request.AppRelativeCurrentExecutionFilePath).Return("~/");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            var routeData = routes.GetRouteData(mockContext);
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Home", routeData.Values["controller"]);
        }
    }
}
