using System.Runtime.Caching;
using JET.Services.Implementations.WebStore;
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

        [Test]
        public void Test_Get_Object_From_Cache_If_Cache_Contain_Data()
        {
            ObjectCache cache = MemoryCache.Default;
            _cacheHelper.StoreObjToCache("key", "jet testing");
            var obj = _cacheHelper.RetrieveCachedObj<string>("key");
            Assert.AreEqual("jet testing", obj);
            cache.Remove("key");
        }

        [Test]
        public void TestStoreAnObjectToCache()
        {
            _cacheHelper.StoreObjToCache("a key", "a string");
            var obj = _cacheHelper.RetrieveCachedObj<string>("a key");
            Assert.AreEqual("a string", obj);
            _cacheHelper.RemoveCacheObj("a key");
        }
    }
}
