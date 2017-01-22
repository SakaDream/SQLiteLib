using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SQLiteLib.Test
{
    [TestClass]
    public class ConnectTest
    {
        [TestMethod]
        public void TestWithObject()
        {
            SQLiteConfig config = new SQLiteConfig();
            config.dataSource = @"test.db";
            bool isConnect = SQLiteLib.connect(config);
            Assert.AreEqual(true, isConnect);
        }
        [TestMethod]
        public void TestWithJsonFile()
        {
            SQLiteConfig config = new SQLiteConfig();
            config.dataSource = @"test.db";
            SQLiteConfigJson.save(config, true);
            bool isConnect = SQLiteLib.connect();
            Assert.AreEqual(true, isConnect);
        }
        [TestMethod]
        public void TestWithCreateDBEncryptJSONFileAndNoPassword()
        {
            SQLiteLib.createDB(@"new-test.db", true, true);
            bool isConnect = SQLiteLib.connect();
            Assert.AreEqual(true, isConnect);
        }
        [TestMethod]
        public void TestWithCreateDBNotEncryptJSONFileAndSetPassword()
        {
            SQLiteLib.createDB(@"new-test-2.db","p@ssw0rd", true, false);
            bool isConnect = SQLiteLib.connect();
            Assert.AreEqual(true, isConnect);
        }
        [TestMethod]
        public void TestWithTempFile()
        {
            SQLiteLib.createDB(@"new-test-3.db", false, false);
            bool isConnect = SQLiteLib.connect();
            Assert.AreEqual(true, isConnect);
        }
    }
}
