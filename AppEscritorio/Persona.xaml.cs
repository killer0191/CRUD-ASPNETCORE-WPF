using AppEscritorio.services;
using System;
using System.Collections.Generic;
using System.Linq;
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
using static System.Collections.Specialized.BitVector32;
using AppEscritorio.Models;


namespace AppEscritorio
{
    /// <summary>
    /// Lógica de interacción para Persona.xaml
    /// </summary>
    public partial class Persona : Window
    {
        public Persona(string opcion)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            string opcionSeleccionada = opcion;

            // Ajusta la visibilidad de las secciones según la opción seleccionada
            switch (opcionSeleccionada)
            {
                case "Agregar":
                    Seccion1.Visibility = Visibility.Visible;
                    Seccion2.Visibility = Visibility.Collapsed;
                    Seccion3.Visibility = Visibility.Collapsed;
                    break;
                case "Buscar":
                    Seccion1.Visibility = Visibility.Collapsed;
                    Seccion2.Visibility = Visibility.Visible;
                    Seccion3.Visibility = Visibility.Collapsed;
                    break;
                case "Borrar":
                    Seccion1.Visibility = Visibility.Collapsed;
                    Seccion2.Visibility = Visibility.Collapsed;
                    Seccion3.Visibility = Visibility.Visible;
                    CargarPersonasEnComboBox();
                    break;
                default:
                    // Manejo de opción no válida
                    break;
            }
        }
        public void Inicio_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        public void Factura_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is MenuItem menuItem)
            {
                string opcion = menuItem.Tag?.ToString();

                if (opcion != null)
                {
                    var facturaWindow = new Factura(opcion);
                    facturaWindow.Show();
                    Close();
                }
            }
        }
        private void Seccion_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                string opcionSeleccionada = menuItem.Tag as string;

                // Ajusta la visibilidad de las secciones según la opción seleccionada
                switch (opcionSeleccionada)
                {
                    case "Agregar":
                        Seccion1.Visibility = Visibility.Visible;
                        Seccion2.Visibility = Visibility.Collapsed;
                        Seccion3.Visibility = Visibility.Collapsed;
                        break;
                    case "Buscar":
                        Seccion1.Visibility = Visibility.Collapsed;
                        Seccion2.Visibility = Visibility.Visible;
                        Seccion3.Visibility = Visibility.Collapsed;
                        break;
                    case "Borrar":
                        Seccion1.Visibility = Visibility.Collapsed;
                        Seccion2.Visibility = Visibility.Collapsed;
                        Seccion3.Visibility = Visibility.Visible;
                        CargarPersonasEnComboBox();
                        break;
                    default:
                        // Manejo de opción no válida
                        break;
                }
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == textBox.Tag?.ToString())
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag?.ToString();
                textBox.Foreground = Brushes.Gray;
            }
        }

        private async void GuardarPersona_Click(object sender, RoutedEventArgs e)
        {
            string nombre = NombreTextBox.Text;
            string apellidoPaterno = ApellidoPaternoTextBox.Text;
            string apellidoMaterno = "";
            if(ApellidoMaternoTextBox.Text!="Apellido Materno")
            {
              apellidoMaterno = ApellidoMaternoTextBox.Text;
            }
            
            string identificacion = IdentificacionTextBox.Text;

            // Crear una instancia de la clase Persona con los datos ingresados
            var nuevaPersona = new PersonaModel
            {
                Nombre = nombre,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                Identificacion = identificacion
            };

            bool exito = await services.PersonaService.StorePersona(nuevaPersona);

            if (exito)
            {
                MessageBox.Show("Persona guardada exitosamente");
                NombreTextBox.Text = string.Empty;
                ApellidoPaternoTextBox.Text = string.Empty;
                ApellidoMaternoTextBox.Text = string.Empty;
                IdentificacionTextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Error al guardar la persona");
            }
        }

        private async void BuscarPersona_Click(object sender, RoutedEventArgs e)
        {
            string identificacion = IdentificacionBusquedaTextBox.Text;
            Console.WriteLine("Identificación: " + identificacion);

            var personaEncontrada = await services.PersonaService.FindPersonaByIdentificacion(identificacion);
            Console.WriteLine("Persona "+ personaEncontrada);

            if (personaEncontrada != null)
            {
                NombreEncontradoTextBlock.Text = personaEncontrada.Nombre + " " + personaEncontrada.ApellidoPaterno + " " + personaEncontrada.ApellidoMaterno;
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private async void EliminarPersona_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el valor del ComboBox u otro control según sea necesario
            string identificacion = IdentificacionEliminarComboBox.SelectedValue?.ToString();

            if (!string.IsNullOrEmpty(identificacion))
            {
                bool exito = await services.PersonaService.DeletePersonaByIdentificacion(identificacion);

                if (exito)
                {
                    MessageBox.Show("Persona eliminada exitosamente");
                    List<PersonaModel> personas = await services.PersonaService.FindPersonas();

                    IdentificacionEliminarComboBox.ItemsSource = personas;
                    IdentificacionEliminarComboBox.DisplayMemberPath = "Nombre";
                    IdentificacionEliminarComboBox.SelectedValuePath = "Identificacion";
                }
                else
                {
                    MessageBox.Show("Error al eliminar la persona");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una persona para eliminar");
            }
        }

        private async void CargarPersonasEnComboBox()
        {
            // Obtener todas las personas desde el servicio
            List<PersonaModel> personas = await services.PersonaService.FindPersonas();

            if (personas != null)
            {
                // Asigna la lista de personas al ComboBox
                IdentificacionEliminarComboBox.ItemsSource = personas;
                IdentificacionEliminarComboBox.DisplayMemberPath = "Nombre";
                IdentificacionEliminarComboBox.SelectedValuePath = "Identificacion";
            }
            else
            {
                Console.WriteLine("Error al cargar las personas en el ComboBox");
            }
        }
    }
}