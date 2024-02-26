using Programacion_aplicada_dos.Config;
using Programacion_aplicada_dos.DTO;
using Programacion_aplicada_dos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Programacion_aplicada_dos.Clientes
{
    /// <summary>
    /// Lógica de interacción para ClienteView.xaml
    /// </summary>
    public partial class ClienteView : Window
    {
        Conexion conexion;
        public ClienteView()
        {
            InitializeComponent();
            conexion = new Conexion();
            this.listadoClientes();
            //iniciar ocultos los botones de editar y eliminar
            btn_actualizar.Visibility = Visibility.Collapsed;
            btn_eliminar.Visibility = Visibility.Collapsed;
        }

        private void btn_nuevo_Click(object sender, RoutedEventArgs e)
        {
            
            string nombre = textBlock_nombre.Text;
            string apellido = textBlock_apellido.Text;
            string dni = textBlock_dni.Text;
            string fechaNacimeinto = datePicker_nacimiento.Text;

            bool formulario = validarFormulario(nombre, apellido, dni, fechaNacimeinto);
            if (!formulario)
                return;

            bool statusCliente = false;
            ClienteDto clienteDto = new ClienteDto();
            string alerta = "";
            
            if (label_id.Content != null && label_id.Content != "")
            {
                int idCliente = Convert.ToInt16(label_id.Content);
                //Editamos el registro
                Cliente cliente = new Cliente(idCliente, nombre, apellido, dni, DateTime.Parse(fechaNacimeinto));
                //creamos el registro
                statusCliente = clienteDto.editarCliente(cliente);
                alerta = "Se edito correctamente el registro";
            }
            
            else
            {
                //cremos un nuevo reguistro
                Cliente cliente = new Cliente(nombre, apellido, dni, DateTime.Parse(fechaNacimeinto));
                statusCliente = clienteDto.crearRegistro(cliente);
                alerta = "Se creo correctamente el nuevo registro";
            }

            if (statusCliente)
                MessageBox.Show(alerta, "Alerta de confirmación", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(alerta, "Alerta de confirmación", MessageBoxButton.OK, MessageBoxImage.Warning);

            this.listadoClientes();
            this.limpiarFormulario();
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = (Cliente)listView_cleintes.SelectedItem;
            if(cliente != null)
            {
                this.eliminarCliente(cliente);
            }
            else
            {
                MessageBox.Show("Selecciona un registro a eliminar", "Alerta de eliminación", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            this.listadoClientes();
        }
        private void listView_cleintes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_actualizar.Visibility = Visibility.Visible;
            btn_eliminar.Visibility = Visibility.Visible;
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = (Cliente)listView_cleintes.SelectedItem;
            this.edita(cliente);
        }


        private void listadoClientes()
        {
            ClienteDto clienteDto = new ClienteDto();
            listView_cleintes.ItemsSource = clienteDto.listarClientes();
        }

        private void eliminarCliente(Cliente cliente)
        {
            ClienteDto clienteDto = new ClienteDto();
            bool confireElimiado = clienteDto.eliminarCliente(cliente);

            if (confireElimiado)
                MessageBox.Show("Se eliminó correctamente", "Alerta de eliminación" ,MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
                MessageBox.Show("No se ha podido eliminar", "Alerta de eliminación", MessageBoxButton.OK, MessageBoxImage.Warning);
            this.listadoClientes();
        }

        private void edita(Cliente cliente)
        {
            label_id.Content = cliente.idCliente.ToString();
            textBlock_nombre.Text = cliente.nombres;
            textBlock_apellido.Text = cliente.apellidos;
            textBlock_dni.Text = cliente.dni;
            datePicker_nacimiento.Text = cliente.fechaNacimiento.ToString();
        }

        private void limpiarFormulario()
        {
            label_id.Content = "";
            textBlock_nombre.Clear();
            textBlock_apellido.Clear();
            textBlock_dni.Clear();
            datePicker_nacimiento.Text = "";
            listView_cleintes.UnselectAll();
            btn_actualizar.Visibility = Visibility.Collapsed;
            btn_eliminar.Visibility = Visibility.Collapsed;
        }


        private bool validarFormulario(string nombre, string apellido, string dni, string fechaNacimeinto)
        {
            if (nombre == "" || apellido == "" || dni == "" || fechaNacimeinto == "")
            {
                MessageBox.Show("Rellenar todo el formulario ", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        
    }
}
