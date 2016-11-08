using JET.Services.Interfaces.WebStore;
using NUnit.Framework;

namespace JET.Services.Implementations.Tests.WebStore
{
    [TestFixture]
    public class RetrieveStoreCacheTest
    {
        private ICacheHelper _cacheHelper;

        [SetUp]
        public void SetUp()
        {
            _cacheHelper = new CacheHelper();
        }
    }
}
