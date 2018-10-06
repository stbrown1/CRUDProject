using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace MySQLProject
{
    class Program
    {
        static void Main(string[] args)
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

            var weaponsList = weaponsRepo.GetWeapons();

            Console.WriteLine("Welcome to the Destiny 2 Armory!");
            Console.WriteLine("Here is what we have available:");

            foreach (Weapons weapons in weaponsList)
            {

                Console.WriteLine($"{weapons.WeaponID} -- {weapons.WeaponName} -- {weapons.WeaponType} -- {weapons.Rarity} -- {weapons.Rarity} -- {weapons.Slot} -- {weapons.Attack} -- {weapons.Impact} -- {weapons.Magazine}");
            }

            Console.WriteLine("Which would you like to take from the armory?");
            Console.WriteLine("Please select by entering it's ID number:");
            Console.ReadLine();
        }
    }
}
