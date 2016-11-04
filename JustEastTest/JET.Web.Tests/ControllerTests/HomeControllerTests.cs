using System.Web.Mvc;
using NUnit.Framework;
using StructureMap.AutoMocking;

namespace JET.Web.Tests.ControllerTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private RhinoAutoMocker<HomeController> _mockHomeController;

        [SetUp]
        public void SetUp()
        {
            _mockHomeController = new RhinoAutoMocker<HomeController>();
        }

        [Test]
        public void IndexTests()
        {
            // Act
            var result = _mockHomeController.ClassUnderTest.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
