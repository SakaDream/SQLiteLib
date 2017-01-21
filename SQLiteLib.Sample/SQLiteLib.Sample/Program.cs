using System;
using System.Data.SQLite;

namespace SQLiteLib.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating test.db file...");
            SQLiteLib.createDB(@"test.db", true);
            SQLiteLib.updateQuery(@"CREATE TABLE 'TEST' ('ID' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 'NAME' TEXT NOT NULL, 'GENDER' INTEGER NOT NULL DEFAULT 0 CHECK(GENDER == 0 OR GENDER == 1), 'SALARY' REAL DEFAULT 0)");

            Console.WriteLine("---------------------------------------------");
            string name;
            int gender, salary;
            Console.WriteLine("Please input some information");
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Gender (1 is male, 0 is female) : ");
            gender = Convert.ToInt32(Console.ReadLine());
            Console.Write("Salary: ");
            salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Inserting record to database...");
            SQLiteLib.updateQuery(string.Format(@"INSERT INTO TEST (NAME, GENDER, SALARY) VALUES ('{0}', {1}, {2})", name, gender, salary));

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Show all records in database...");
            SQLiteDataReader reader = SQLiteLib.selectQuery(@"SELECT * FROM TEST");
            while (reader.Read())
            {
                Console.WriteLine("ID: " + reader[0]);
                Console.WriteLine("Name: " + reader[1]);
                Console.WriteLine("Gender: " + reader[2]);
                Console.WriteLine("Salary: " + reader[3]);
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }
    }
}
