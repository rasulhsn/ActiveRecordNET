using System.Collections.Generic;
using ActiveRecordNET.Lib.Common.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActiveRecordNET.Lib.Extensions.Integration.Tests
{
    [TestClass]
    public class AdoObjectTests
    {
        [TestMethod]
        public void Sample()
        {
            TestAdoObject adoObject = new TestAdoObject();

            IEnumerable<TestUserObject> objects = adoObject.GetAll();

            Assert.IsNotNull(objects);
        }
    }
}