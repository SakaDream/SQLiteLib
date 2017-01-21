using Newtonsoft.Json;
using SQLiteLib.Security;
using System.IO;
using System.Text;

namespace SQLiteLib
{
    public static class SQLiteConfigJson
    {
        public static string path { get; } = "config.json";

        public static void save(SQLiteConfig config, bool encrypt)
        {
            if (!File.Exists(path))
            {
                using (var stream = File.Create(path));
            }
            else
            {
                File.WriteAllText(path, string.Empty);
            }
            TextWriter tw = new StreamWriter(path, true);
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            if (encrypt)
            {
                tw.Write(Encryption.Encrypt(json));
            }
            else
            {
                tw.Write(json);
            }
            tw.Close();
        }

        public static SQLiteConfig open()
        {
            try
            {
                return JsonConvert.DeserializeObject<SQLiteConfig>(File.ReadAllText(path, Encoding.UTF8));
            }
            catch
            {
                return JsonConvert.DeserializeObject<SQLiteConfig>(Encryption.Decrypt(File.ReadAllText(path, Encoding.UTF8)));
            }
        }
    }
}
