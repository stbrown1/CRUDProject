using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MySQLProject
{
    public class WeaponsRepository
    {
        private static string connectionString;

        public WeaponsRepository(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public List<Weapons> GetWeapons()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT WeaponID AS id, WeaponName AS name, WeaponType as type, rarity, slot, attack, impact, magazine FROM weapons;";
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Weapons> weapons = new List<Weapons>();
                while (reader.Read())
                {
                    Weapons weapon = new Weapons();
                    weapon.WeaponID = (int)reader["id"];
                    weapon.WeaponName = (string)reader["name"];
                    weapon.WeaponType = (int)reader["type"];
                    weapon.Rarity = (int)reader["rarity"];
                    weapon.Slot = (string)reader["slot"];
                    weapon.Attack = (int)reader["attack"];
                    weapon.Impact = (int)reader["impact"];
                    weapon.Magazine = (int)reader["magazine"];
                    weapons.Add(weapon);
                }

                return weapons;
            }
        }
    }
}
