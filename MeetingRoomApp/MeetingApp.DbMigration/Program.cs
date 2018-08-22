using DbUp;
using System;
using System.Reflection;

namespace MeetingApp.DbMigration
{
    static class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=.;Initial Catalog=Db_BookingRoomApp;Integrated Security=True";

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
