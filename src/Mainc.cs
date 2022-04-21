using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace EATM
{
    public class Mainc
    {
        private static void ScriptAnim(string ongoing, string finished) {
            Console.WriteLine(ongoing);
            using (var progress = new ProgressBar()) {
                for (int i = 0; i < 100; i++) {
                    progress.Report((double)i / 100);
                    System.Threading.Thread.Sleep(100);
                }
            }
            Console.Clear();
            Console.WriteLine(finished);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Amirul Finance Business.");
            // Console.WriteLine("Please enter your PIN number: ");
            // int PIN = Convert.ToInt32(Console.ReadLine());
            ScriptAnim("DATABASE TEST", "PRINTING RESULTS");
            if(File.Exists("EATM.db"))
            {
                Console.WriteLine("Database file found.");
                Console.WriteLine(Path.GetFullPath("EATM.db"));
            }
            else
            {
                Console.WriteLine("Database file not found.");
                Console.WriteLine("Creating database file...");
                EATM.databaseAccess db = new EATM.databaseAccess();
                db.CreateConnection();
                Console.WriteLine("Database file created.");
                Console.WriteLine(Path.GetFullPath("EATM.db"));
            }
        }
        public class enquiries {
            public void enquired() {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Balance Inquiry");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Please enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You have chosen to deposit.");
                        Console.WriteLine("Please enter the amount you want to deposit: ");
                        int deposit = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Your deposit is successful.");
                        break;
                    case 2:
                        Console.WriteLine("You have chosen to withdraw.");
                        Console.WriteLine("Please enter the amount you want to withdraw: ");
                        int withdraw = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Your withdraw is successful.");
                        break;
                    case 3:
                        Console.WriteLine("You have chosen to check your balance.");
                        Console.WriteLine("Your balance is: ");
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using Amirul Finance Business.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
