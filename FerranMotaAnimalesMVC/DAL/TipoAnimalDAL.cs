using FerranMotaAnimalesMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FerranMotaAnimalesMVC.DAL
{
    public class TipoAnimalDAL
    {
        private DbConnection connection;
        public TipoAnimalDAL()
        {
            connection = new DbConnection();
        }


        public List<TipoAnimal> SelectAll()
        {
            connection.Open();

            List<TipoAnimal> tipoAnimals = new List<TipoAnimal>();

            string query = "SELECT * FROM TipoAnimal";
            SqlCommand command = new SqlCommand(query, connection.GetConnection());

            SqlDataReader records = command.ExecuteReader();

            while (records.Read())
            {
                int idTipoAnimal = records.GetInt32(records.GetOrdinal("IdTipoAnimal"));
                string TipoDescripcion = records.GetString(records.GetOrdinal("TipoDescripcion"));

                TipoAnimal tipoAnimal = new TipoAnimal(idTipoAnimal, TipoDescripcion);
                tipoAnimals.Add(tipoAnimal);
            }

            records.Close();
            connection.Close();
            return tipoAnimals;

        }
    }
}