using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace MySQLProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
#if DEBUG
                .AddJsonFile("appsettings.DEBUG.json")
#else
                .AddJsonFile("appsettings.Release.json")
#endif
                .Build();

                string connString = configuration.GetConnectionString("DefaultConnection");

                var weaponsRepo = new WeaponsRepository(connString);



                Console.WriteLine("Welcome to the Destiny 2 Armory!");
                Console.WriteLine(" ");

                var weaponsOne = new MenuOps(weaponsRepo);

                weaponsOne.MainMenu();

                int selection = UserInput.GetIntegerResponse("Please enter the number for your selection: ");

                if (selection == 1)
                {
                    weaponsOne.WpnsAvailable();
                }
                else if (selection == 2)
                {
                    weaponsOne.WpnCreate();
                }
                else if (selection == 3)
                {
                    weaponsOne.WpnUpdate();
                }
                else if (selection == 4)
                {
                    weaponsOne.WpnRemove();
                }
                else if (selection == 5)
                {
                    Console.WriteLine("Thank you for visiting!");

                    Console.WriteLine("Good Bye!");
                    break;
                }
                else
                {
                    UserInput.GetIntegerResponse("Please enter a selection fom the menu options: ");
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to return to the Main Menu!");
                Console.ReadLine();
            }
        }
    }
}
