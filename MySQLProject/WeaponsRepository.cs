using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace MySQLProject
{
    public class WeaponsRepository
    {
        private static string connectionString;

        public WeaponsRepository(string _connectionString)
        {
            connectionString = _connectionString;
        }

        //queries weapons DB to display all entries.
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

        //adds new entry into weapons DB
        public void CreateWeapon (Weapons weapons)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO weapons (WeaponName, WeaponType, Rarity, Slot, Attack, Impact, Magazine) VALUES (@name, @type, @rarity, @slot, @attack, @impact, @magazine);";
                cmd.Parameters.AddWithValue("name", weapons.WeaponName);
                cmd.Parameters.AddWithValue("type", weapons.WeaponType);
                cmd.Parameters.AddWithValue("rarity", weapons.Rarity);
                cmd.Parameters.AddWithValue("slot", weapons.Slot);
                cmd.Parameters.AddWithValue("attack", weapons.Attack);
                cmd.Parameters.AddWithValue("impact", weapons.Impact);
                cmd.Parameters.AddWithValue("magazine", weapons.Magazine);
                cmd.ExecuteNonQuery();
            }
        }

        //deletes entry from weapons DB by their ID
        public void DeleteWeapon(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM weapons WHERE WeaponID = @weapId;";
                cmd.Parameters.AddWithValue("weapId", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
