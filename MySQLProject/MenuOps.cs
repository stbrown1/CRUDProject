using System;
using System.Collections.Generic;
using System.Threading;

namespace MySQLProject
{
    public class MenuOps
    {

        public WeaponsRepository WeaponsRepo { get; set; }

        public MenuOps(WeaponsRepository _WeaponsRepo)
        {
            WeaponsRepo = _WeaponsRepo;
        }

        public void MainMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(" ");
            Console.WriteLine("1. See available weapons.");
            Console.WriteLine("2. Add weapon to armory.");
            Console.WriteLine("3. Update information for exisitng weapon.");
            Console.WriteLine("4. Remove weapon from armory.");
            Console.WriteLine("5. Leave Armory");
            Console.WriteLine("");
        }

        public void WpnsAvailable()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Here is what we have available in the armory:");
            Console.WriteLine(" ");

            List<Weapons> weaponsList = WeaponsRepo.GetWeapons();
            foreach (Weapons weapons in weaponsList)
            {

                Console.WriteLine($"{weapons.WeaponID} -- {weapons.WeaponName} -- {weapons.WeaponType} -- {weapons.Rarity} -- {weapons.Slot} -- {weapons.Attack} -- {weapons.Impact} -- {weapons.Magazine}");
            }
        }

        public void WpnCreate()
        {
            Console.WriteLine("Congrats on finding a new weapon in the field!");
            Thread.Sleep(500);
            Console.WriteLine("Please wait while we prepare the Armory to receive your weapon...");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine("You may now add your weapon to the Armory...:");
            string name = UserInput.GetStringResponse("Please enter the name of the weapon: ");
            Console.WriteLine();
            int type = UserInput.GetIntegerResponse("Please enter the type of the weapon from the following list: \n 1. Sidearm \n 2. Hand Cannon \n 3. Submachine Gun \n 4. Scout Rifle \n 5. Pulse Rifle \n " +
                                                    "6. Auto Rifle \n 7. Trace Rifle \n 8. Fusion Rifle \n 9. Linear Fusion Rifle \n 10. Sniper Rifle \n 11. Shotgun \n 12. Grenade Launcher \n 13. Rocket Launcher \n " +
                                                    "14. Sword \n 15. Combat Bow");
            Console.WriteLine();
            int rarity = UserInput.GetIntegerResponse("Please enter the rarity of the weapon from the following list: \n 1. Common \n 2. Uncommon \n 3. Rare \n " +
                                                      "4. Legendary \n 5. Exotic");
            Console.WriteLine();
            string slot = UserInput.GetStringResponse("Please enter the slot your weapon goes in (Kinetic, Energy, or Power): ");
            Console.WriteLine();
            int attack = UserInput.GetIntegerResponse("Please enter your weapon's Attack level: ");
            Console.WriteLine();
            int impact = UserInput.GetIntegerResponse("Please enter your weapon's Impact rating: ");
            Console.WriteLine();
            int magazine = UserInput.GetIntegerResponse("Please enter your weaon's Magazine capacity: ");
            Console.WriteLine();

            var newWeapon = new Weapons { WeaponName = name, WeaponType = type, Rarity = rarity, Slot = slot, Attack = attack, Impact = impact, Magazine = magazine };
            WeaponsRepo.CreateWeapon(newWeapon);
            Console.WriteLine("Your weapon has been added to the armory!");
            Console.WriteLine();
        }

        public void WpnRemove()
        {
            Console.WriteLine("Which would you like to take from the armory?");
            WpnsAvailable();
            Console.WriteLine();
            int selection = UserInput.GetIntegerResponse("Please select by entering it's ID number: ");
            WeaponsRepo.DeleteWeapon(selection);
            Console.WriteLine("You have successfully removed the weapon from the armory!");
            Console.WriteLine();
        }

        public void WpnUpdate()
        {
            Console.WriteLine("Which weapon would you like to update?");
            WpnsAvailable();
            Console.WriteLine();
            int selection = UserInput.GetIntegerResponse("Please enter the ID number of the weapon you want to update: ");

            Console.WriteLine("Please enter the following information for the weapon selected: ");
            string name = UserInput.GetStringResponse("Please enter the name of the weapon: ");
            int type = UserInput.GetIntegerResponse("Please enter the type of the weapon: ");
            int rarity = UserInput.GetIntegerResponse("Please enter the rarity of the weapon: ");
            string slot = UserInput.GetStringResponse("Please enter the slot your weapon goes in: ");
            int attack = UserInput.GetIntegerResponse("Please enter your weapon's Attack level: ");
            int impact = UserInput.GetIntegerResponse("Please enter your weapon's Impact rating: ");
            int magazine = UserInput.GetIntegerResponse("Please enter your weaon's Magazine capacity: ");
            WeaponsRepo.UpdateWeapon(name, type, rarity, slot, attack, impact, magazine, selection);
            Console.WriteLine("The weapon was successfully updated!");
        }
    }
}
