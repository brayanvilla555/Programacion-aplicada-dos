using Programacion_aplicada_dos.Config;
using Programacion_aplicada_dos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Programacion_aplicada_dos.DTO
{
    internal class ClienteDto
    {
        Conexion conexion = new Conexion();

        private void crearCliente(Cliente cliente)
        {
            string query = "INSERT INTO CLIENTE(idCliente,nombres, apellidos, dni, fechaNacimiento)  VALUES('2','Diego', 'Villanueva', '123456', '2003-08-27 ')";
        }
        public List<Cliente> listarClientes()
        {
            string query = "SELECT * FROM CLIENTE";
            SqlCommand command = new SqlCommand(query);

            command.Connection = conexion.conectar();
            SqlDataReader reader = command.ExecuteReader();

            List<Cliente> clientes = new List<Cliente>();

            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.idCliente = reader.GetInt32(0);
                cliente.nombres = reader.GetString(1);
                cliente.apellidos = reader.GetString(2);
                cliente.dni = reader.GetString(3);
                cliente.fechaNacimiento = reader.GetDateTime(4);

                clientes.Add(cliente);
            }
            conexion.sqlConnection.Close();

            return clientes;
        }

        public bool eliminarCliente(Cliente cliente)
        {
            try
            {
                if (cliente.idCliente != null)
                {
                    int idCliente = cliente.idCliente;
                    string query = $"DELETE FROM CLIENTE WHERE idCliente = {idCliente}";
                    SqlCommand command = new SqlCommand(query);

                    command.Connection = conexion.conectar();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    conexion.sqlConnection.Close();
                    return true;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al eliminar el cliente: ",ex.Message);
            }

            return false;
        }

        public bool editarCliente(Cliente cliente)
        {
            //castear fecha 
            try
            {
                if (cliente != null && (cliente.idCliente != null || cliente.idCliente.ToString() != " "))
                {
                    string fecha = cliente.fechaNacimiento.ToString("yyyy-MM-dd");
                    string query = $"UPDATE CLIENTE SET nombres = '{cliente.nombres}', apellidos ='{cliente.apellidos}', dni = '{cliente.dni}' ,fechaNacimiento = '{fecha}' WHERE   idCliente = {cliente.idCliente}";
                    SqlCommand command = new SqlCommand(query);

                    command.Connection = conexion.conectar();
                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    conexion.sqlConnection.Close();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el cliente: ", ex.Message);
            }
            
            return false;
        }

        public bool crearRegistro(Cliente cliente)
        {
            //castear fecha 
            try
            {
                string fechaNacimiento = cliente.fechaNacimiento.ToString("yyyy-MM-dd");
                string query = $"INSERT INTO CLIENTE VALUES('{cliente.nombres}', '{cliente.apellidos}', '{cliente.dni}', '{fechaNacimiento}')";
                SqlCommand command = new SqlCommand(query);
                
                command.Connection = conexion.conectar();
                SqlDataReader sqlDataReader = command.ExecuteReader();

                conexion.sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el cliente: ", ex.Message);
            }

            return false;
        }
    }
}
