namespace SQLiteLib
{
    public class SQLiteConfig
    {
        public string dataSource { get; set; } = "";
        public int version { get; set; } = 3;
        public string useUTF16Encoding { get; set; } = "False";
        public string defaultDbType { get; set; } = "";
        public string defaultTypeName { get; set; } = "";
        public string noDefaultFlags { get; set; } = "False";
        public string noSharedFlags { get; set; } = "False";
        public string vfsName { get; set; } = "";
        public string zipVfsName { get; set; } = "";
        public string dateTimeFormat { get; set; } = "ISO8601";
        public string dateTimeKind { get; set; } = "Unspecified";
        public string dateTimeFormatString { get; set; } = "";
        public string baseSchemaName { get; set; } = "sqlite_default_schema";
        public string binaryGUID { get; set; } = "True";
        public int cacheSize { get; set; } = -2000;
        public string synchronous { get; set; } = "full";
        public int pageSize { get; set; } = 4096;
        public string password { get; set; } = "";
        public string hexPassword { get; set; } = "";
        public string enlist { get; set; } = "Y";
        public string pooling { get; set; } = "False";
        public string failIfMissing { get; set; } = "False";
        public int maxPageCount { get; set; } = 0;
        public string legacyFormat { get; set; } = "False";
        public int defaultTimeout { get; set; } = 30;
        public int busyTimeout { get; set; } = 0;
        public string journalMode { get; set; } = "Delete";
        public string readOnly { get; set; } = "False";
        public int maxPoolSize { get; set; } = 100;
        public string defaultIsolationLevel { get; set; } = "Serializable";
        public string foreignKeys { get; set; } = "False";
        public string flags { get; set; } = "Default";
        public string setDefaults { get; set; } = "True";
        public string toNullPath { get; set; } = "True";
        public int prepareRetries { get; set; } = 3;
        public int progressOps { get; set; } = 0;
        public string recursiveTriggers { get; set; } = "False";
    }
}
