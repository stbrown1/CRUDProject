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

        //queries weapons table to display all entries.
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

        //adds new entry into weapons table
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

        //deletes entry from weapons table by it's ID
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

        //Deletes entry from weapons table by it's name
        public void DeleteWeapon(string name)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM weapons WHERE WeaponName = @weapName;";
                cmd.Parameters.AddWithValue("weapName", name);
                cmd.ExecuteNonQuery();
            }
        }

        //Updates entry in weapons table
        public void UpdateWeapon(string weapName, int weapType, int weapRarity, string weapSlot, int weapAttack, int weapImpact, int weapMagazine, int weapID )
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE weapons SET WeaponName = @name, WeaponType = @type, Rarity = @rarity, Slot = @slot, Attack = @attack, Impact = @impact, Magazine = @magazine WHERE WeaponID = @id;";
                cmd.Parameters.AddWithValue("name", weapName);
                cmd.Parameters.AddWithValue("type", weapType);
                cmd.Parameters.AddWithValue("rarity", weapRarity);
                cmd.Parameters.AddWithValue("slot", weapSlot);
                cmd.Parameters.AddWithValue("attack", weapAttack);
                cmd.Parameters.AddWithValue("impact", weapImpact);
                cmd.Parameters.AddWithValue("magazine", weapMagazine);
                cmd.Parameters.AddWithValue("id", weapID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
