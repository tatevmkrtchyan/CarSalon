using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalon
{
    public class Car
    {
        public int ID;
        public Model Model = new Model();

        public string Color { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public bool Sold;
        public bool Deleted;

        public Car(int brandId, string brandName,int modelID,string modelName, 
                    int carID,string carColor, int carYear, int carPrice)
        {
            this.Model.Brand.ID = brandId;
            this.Model.Brand.Name = brandName;
            this.Model.ID = modelID;
            this.Model.Name = modelName;
            this.ID = carID;
            this.Color = carColor;
            this.Year = carYear;
            this.Price = carPrice;
        }

        public Car()
        {
            Sold = false;
            Deleted = false;
        }

        static public void AddCar(string text)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string insertStr = "Insert into Model(Name)";
                insertStr += " Values(@Name)";

                SqlCommand command = new SqlCommand(insertStr, connection);
                command.Parameters.AddWithValue("Name", text);

                Console.WriteLine(command.ExecuteNonQuery());
            }
        }

        static public IEnumerable<Car> GetCars()
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                connection.Open();

                string strSelect = "Select Brand.ID as brandId,Brand.[Name] as brandName,Model.ID as modelID,Model.[Name] as modelName,Car.ID as carID,Car.Color as carColor,Car.[Year] as carYear,Car.Price as carPrice from Car join Model on Model.ID = Car.ModelID  join Brand on Brand.ID = Model.BrandID";

                SqlCommand command = new SqlCommand(strSelect, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Car(Convert.ToInt32(reader["brandID"]),
                                        reader["brandName"]?.ToString(),
                                        Convert.ToInt32(reader["modelID"]),
                                        reader["modelName"]?.ToString(),
                                        Convert.ToInt32(reader["carID"]),
                                        reader["carColor"]?.ToString(),
                                        Convert.ToInt32(reader["carYear"]),
                                        Convert.ToInt32(reader["carPrice"]));
                }

                connection.Close();
            }
        }
    }
}
