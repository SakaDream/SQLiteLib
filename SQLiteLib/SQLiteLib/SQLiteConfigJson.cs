using Newtonsoft.Json;
using SQLiteLib.Security;
using System.IO;
using System.Text;

namespace SQLiteLib
{
    public static class SQLiteConfigJson
    {
        public static string path { get; } = "config.json";

        public static void save(SQLiteConfig config)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {
                File.WriteAllText(path, string.Empty);
            }
            TextWriter tw = new StreamWriter(path, true);
            tw.Write(Encryption.Encrypt(JsonConvert.SerializeObject(config)));
            tw.Close();
        }

        public static SQLiteConfig open()
        {
            return JsonConvert.DeserializeObject<SQLiteConfig>(Encryption.Decrypt(File.ReadAllText(path, Encoding.UTF8)));
        }
    }
}
