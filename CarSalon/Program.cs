using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarSalon
{
    static class Program
    {
        public const string ConnectionString = 
                                        "Data Source=DESKTOP-HASQP3Q;" +
                                        "Initial Catalog=CarSalon;" +
                                        "Integrated Security=True";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString))
            {
                connection.Open();               
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogIn());
        }
    }
}
