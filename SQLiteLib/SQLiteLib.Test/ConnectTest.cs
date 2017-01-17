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
            SQLiteConfigJson.save(config);
            bool isConnect = SQLiteLib.connect();
            Assert.AreEqual(true, isConnect);
        }
    }
}
