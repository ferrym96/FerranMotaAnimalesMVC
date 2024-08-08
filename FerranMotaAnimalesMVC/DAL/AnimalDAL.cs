using FerranMotaAnimalesMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FerranMotaAnimalesMVC.DAL
{
    public class AnimalDAL
    {
        private DbConnection connection;
        public AnimalDAL()
        {
            connection = new DbConnection();
        }

        public void insertAnimal(Animal a)
        {
            connection.Open();

            string sql = @"
                INSERT INTO Animal (NombreAnimal, Raza, RIdTipoAnimal, FechaNacimiento) 
                VALUES (@NombreAnimal, @Raza, @RIdTipoAnimal, @FechaNacimiento)";

            SqlCommand cmd = new SqlCommand(sql, connection.GetConnection());

            cmd.Parameters.AddWithValue("@NombreAnimal", a.NombreAnimal);
            cmd.Parameters.AddWithValue("@Raza", (object)a.Raza ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RIdTipoAnimal", a.RIdTipoAnimal);
            cmd.Parameters.AddWithValue("@FechaNacimiento", (object)a.FechaNacimiento ?? DBNull.Value);

            cmd.ExecuteNonQuery();

            connection.Close();
        }


        public List<Animal> SelectAll()
        {
            connection.Open();

            List<Animal> animals = new List<Animal>();

            string query = "SELECT * FROM Animal";
            SqlCommand command = new SqlCommand(query, connection.GetConnection());

            SqlDataReader records = command.ExecuteReader();

            while (records.Read())
            {
                int idAnimal = records.GetInt32(records.GetOrdinal("IdAnimal"));
                string nombreAnimal = records.GetString(records.GetOrdinal("NombreAnimal"));
                string raza = records.IsDBNull(records.GetOrdinal("Raza")) ? null : records.GetString(records.GetOrdinal("Raza"));
                int rIdTipoAnimal = records.GetInt32(records.GetOrdinal("RIdTipoAnimal"));
                DateTime? fechaNacimiento = records.IsDBNull(records.GetOrdinal("FechaNacimiento"))
                    ? (DateTime?)null
                : records.GetDateTime(records.GetOrdinal("FechaNacimiento"));

                Animal animal = new Animal(idAnimal, nombreAnimal, raza,
                    rIdTipoAnimal, fechaNacimiento);
                animals.Add(animal);
            }

            records.Close();
            connection.Close();
            return animals;

        }

        public bool DeleteAnimalByName(int idAnimal)
        {
            bool result = false;

            try
            {
                connection.Open();

                string query = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
                SqlCommand command = new SqlCommand(query, connection.GetConnection());
                command.Parameters.AddWithValue("@IdAnimal", idAnimal);

                int rowsAffected = command.ExecuteNonQuery();

                result = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }
}