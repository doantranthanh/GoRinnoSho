using System.Web.Http;
using NUnit.Framework;

namespace JET.WebApi.Tests.WebApiRoutingTests
{
    [TestFixture]
    public class RoutingTests
    {    
        private HttpConfiguration _httpConfiguration;

        [SetUp]
        public void SetUp()
        {           
            _httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(_httpConfiguration);
            _httpConfiguration.EnsureInitialized();
        }
       
    }  
}
