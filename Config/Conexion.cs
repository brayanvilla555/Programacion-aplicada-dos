using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Programacion_aplicada_dos.Config
{
    internal class Conexion
    {
        private string servidor = "161.132.40.29";
        private string bd = "ZURICH_CORP";
        private string usuario = "estudiante";
        private string password = "Unc.2024";
        public SqlConnection sqlConnection = null;

        public SqlConnection conectar()
        {
            string connectionString = $"Data Source = {servidor}; Initial Catalog = {bd}; Persist Security Info = True; User ID = {usuario}; Password = {password}";
            //string connectionString = $"Data Source ={servidor}; Initial Catalog = {bd}; Integrated Security = True";
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                //abrimos la conexion
                sqlConnection.Open();
                //cerramos la condicion
                //sqlConnection.Close();
            }catch (Exception ex) { 
                Console.WriteLine("Error:", ex.ToString());
            }
            return sqlConnection;
        }
        
    }
}
