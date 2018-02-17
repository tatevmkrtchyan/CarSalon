using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarSalon
{
    public class Brand
    {
        public int ID;
        public string Name { get; set; }

        public Brand()
        {

        }

        public Brand(int id,string name)
        {
            this.ID = id;
            this.Name = name;                        
        }

        public Brand(string name)
        {
            Name = name;
        }

        static public IEnumerable<Brand> GetBrands()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();         

                string strSelect = "Select ID," +
                                   " Name From Brand";

                SqlCommand command = new SqlCommand(strSelect, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Brand(reader.GetInt32(reader.GetOrdinal("ID")),
                                           reader["Name"]?.ToString());  
                }

                connection.Close();
            }
        }

        static public int GetBrandID(string brandName)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                string strSelect = $"select ID " +
                                   $"from Brand  " +
                                   $"where Brand.Name = '{brandName}'";
              
                SqlCommand command = new SqlCommand(strSelect, connection);
                Int32 brandID = 0;

                try
                {
                    connection.Open();
                    brandID = (Int32)(command.ExecuteScalar());
                }
               catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                connection.Close();
                return brandID;
            }
        }

        static public void AddBrand(string text)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string insertStr = "Insert into Brand(Name)";
                insertStr += " Values(@Name)";

                SqlCommand command = new SqlCommand(insertStr, connection);
                command.Parameters.AddWithValue("Name",text);

                Console.WriteLine(command.ExecuteNonQuery());
            }
        }
    }
   }
