using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimchaFund.Data
{
    public class DBManager
    {

        private string _connectionString;

        public DBManager(string cs)
        {
            _connectionString = cs;
        }

        public void AddContributer(Contributer c)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO CONTRIBUTERS VALUES(@firstName,@lastName,@cellNumber,@dateCreated,@alwaysInclude)";
            cmd.Parameters.AddWithValue("@firstName", c.FirstName);
            cmd.Parameters.AddWithValue("@lastName", c.LastName);
            cmd.Parameters.AddWithValue("@cellNumber", c.CellNumber);
            cmd.Parameters.AddWithValue("@dateCreated", c.DateCreated);
            cmd.Parameters.AddWithValue("@alwaysInclude", c.AlwaysInclude);
            connection.Open();
            cmd.ExecuteNonQuery();

        }

        public List<Contributer> GetAllContributers()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM CONTRIBUTERS";
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Contributer> contributers = new();
            while (reader.Read())
            {
                contributers.Add(new Contributer
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    CellNumber = (string)reader["CellNumber"],
                    DateCreated = (DateTime)reader["DateCreated"]
                });
            }

            return contributers;
        }

        public void AddSimcha(Simcha s)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO SIMCHA VALUES (@name,@date)";
            cmd.Parameters.AddWithValue("@name", s.SimchaName);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            connection.Open();
            cmd.ExecuteNonQuery();
        }



        public List<Simcha> GetAllSimchas()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Simcha";
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Simcha> simchas = new();
            while (reader.Read())
            {
                simchas.Add(new Simcha
                {
                    SimchaName = (string)reader["SimchaName"],
                    SimchaDate = (DateTime)reader["DateCreated"]
                });
            }

            return simchas;
        }

    }
}
