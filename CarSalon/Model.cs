using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalon
{
    public class Model
    {
        public int ID;
        public string Name { get; set; }
        public Brand Brand = new Brand();

        public Model()
        {
            Name = "Unknown";
        }

        public Model(int id,string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        static public IEnumerable<Model> GetModels(int BrandId)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string strSelect = $"select Id, Name" +
                                   $" from Model  where " +
                                   $"Model.BrandID = {BrandId}";

                SqlCommand command = new SqlCommand(strSelect, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Model(reader.GetInt32(reader.GetOrdinal("ID")),
                                            reader["Name"]?.ToString());
                }

                connection.Close();
            }
        }

        static public void AddModel(int BrandID,string ModelName)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string insertStr = "Insert into Model(Name, BrandID)";
                insertStr += " Values(@Name, @BrandID)";

                SqlCommand command = new SqlCommand(insertStr, connection);
                command.Parameters.AddWithValue("Name", ModelName);
                command.Parameters.AddWithValue("BrandId", BrandID);

                Console.WriteLine(command.ExecuteNonQuery());
            }
        }
    }
}
