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
        private string servidor = ".";
        private string bd = "negocios";
        private string usuario = "";
        private string passwor = "";
        public SqlConnection sqlConnection = null;

        public void conectar()
        {
            string connectionString = $"Data Source ={servidor}; Initial Catalog = {bd}; Integrated Security = True";
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //abrimos la conexion
                sqlConnection.Open();
                //cerramos la condicion
                //sqlConnection.Close();
            }catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
}
