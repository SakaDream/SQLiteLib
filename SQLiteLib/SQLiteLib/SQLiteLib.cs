using System;
using System.Data.SQLite;

namespace SQLiteLib
{
    public static class SQLiteLib
    {
        static SQLiteConnection con;
        static SQLiteCommand com;
        public static void createDB(string path, bool saveConfig, bool encrypt)
        {
            SQLiteConnection.CreateFile(path);
            if (saveConfig)
            {
                SQLiteConfig config = new SQLiteConfig();
                config.dataSource = path;
                SQLiteConfigJson.save(config, encrypt);
            }
            else
            {
                SQLiteConfig config = new SQLiteConfig();
                config.dataSource = path;
                SQLiteConfigJson.saveTemp(config, encrypt);
            }
        }
        public static void createDB(string path, string password, bool saveConfig, bool encrypt)
        {
            SQLiteConnection.CreateFile(path);
            if (!password.Equals(""))
            {
                SQLiteConnection con = new SQLiteConnection("Data Source: " + path + ";");
                con.SetPassword(password);
            }
            if (saveConfig)
            {
                SQLiteConfig config = new SQLiteConfig();
                config.dataSource = path;
                if (!password.Equals(""))
                {
                    config.password = password;
                }
                SQLiteConfigJson.save(config, encrypt);
            }
            else
            {
                SQLiteConfig config = new SQLiteConfig();
                config.dataSource = path;
                if (!password.Equals(""))
                {
                    config.password = password;
                }
                SQLiteConfigJson.saveTemp(config, encrypt);
            }
        }
        public static bool connect(SQLiteConfig config)
        {
            try
            {
                con = new SQLiteConnection(
                "Data Source = " + config.dataSource + "; "
                + "Version = " + config.version + "; "
                + "UseUTF16Encoding = " + config.useUTF16Encoding + "; "
                + "DefaultDbType = " + config.defaultDbType + "; "
                + "DefaultTypeName = " + config.defaultTypeName + "; "
                + "NoDefaultFlags = " + config.noDefaultFlags + "; "
                + "NoSharedFlags = " + config.noSharedFlags + "; "
                + "ZipVfsVersion = " + config.zipVfsName + "; "
                + "DateTimeFormat = " + config.dateTimeFormat + "; "
                + "DateTimeKind = " + config.dateTimeKind + "; "
                + "DateTimeFormatString = " + config.dateTimeFormatString + "; "
                + "BaseSchemaName = " + config.baseSchemaName + "; "
                + "BinaryGUID = " + config.binaryGUID + "; "
                + "Cache Size = " + config.cacheSize + "; "
                + "Synchronous = " + config.synchronous + "; "
                + "Page Size = " + config.pageSize + "; "
                + "Password = " + config.password + "; "
                + "HexPassword = " + config.hexPassword + "; "
                + "Enlist = " + config.enlist + "; "
                + "Pooling = " + config.pooling + "; "
                + "FailIfMissing = " + config.failIfMissing + "; "
                + "Max Page Count = " + config.maxPageCount + "; "
                + "Legacy Format = " + config.legacyFormat + "; "
                + "Default Timeout = " + config.defaultTimeout + "; "
                + "BusyTimeout = " + config.busyTimeout + "; "
                + "Journal Mode = " + config.journalMode + "; "
                + "Read Only = " + config.readOnly + "; "
                + "Max Pool Size = " + config.maxPoolSize + "; "
                + "Default IsolationLevel = " + config.defaultIsolationLevel + "; "
                + "Foreign Keys = " + config.foreignKeys + "; "
                + "Flags = " + config.flags + "; "
                + "SetDefaults = " + config.setDefaults + "; "
                + "ToFullPath = " + config.toNullPath + "; "
                + "PrepareRetries = " + config.prepareRetries + "; "
                + "ProgressOps = " + config.progressOps + "; "
                + "Recursive Triggers  = " + config.recursiveTriggers
                );

                con.Open();
                com = new SQLiteCommand(con);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                con = null;
                return false;
            }
        }
        public static bool connect()
        {
            try
            {
                SQLiteConfig config = SQLiteConfigJson.openTemp();
                connect(config);
                return true;
            }
            catch
            {
                try
                {
                    SQLiteConfig config = SQLiteConfigJson.open();
                    connect(config);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static SQLiteDataReader selectQuery(string query)
        {
            try
            {
                connect();
                com.CommandText = query;
                return com.ExecuteReader();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                if(con != null)
                {
                    con.Close();
                }
                return null;
            }
        }
        public static void updateQuery(string query)
        {
            try
            {
                connect();
                com.CommandText = query;
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                if (con != null)
                {
                    con.Close();
                }
            }
        }
    }
}
