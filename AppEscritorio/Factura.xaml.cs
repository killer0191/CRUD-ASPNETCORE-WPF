using AppEscritorio.Models;
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
using System.Windows.Threading;
using static System.Collections.Specialized.BitVector32;


namespace AppEscritorio
{
    /// <summary>
    /// Lógica de interacción para Factura.xaml
    /// </summary>
    public partial class Factura : Window
    {
        //private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        public Factura(string opcion)
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
                    CargarPersonasEnComboBox();
                    FechaTextBlock.Text = $"{DateTime.Now}";
                    /*dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                    dispatcherTimer.Tick += new EventHandler(ActualizarFecha);
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    dispatcherTimer.Start();*/
                    break;
                case "Buscar":
                    Seccion1.Visibility = Visibility.Collapsed;
                    Seccion2.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
        public void Inicio_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void Seccion_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                string opcionSeleccionada = menuItem.Tag as string;

                switch (opcionSeleccionada)
                {
                    case "Agregar":
                        Seccion1.Visibility = Visibility.Visible;
                        Seccion2.Visibility = Visibility.Collapsed;
                        CargarPersonasEnComboBox();
                        FechaTextBlock.Text = $"{DateTime.Now}";
                        /*dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                        dispatcherTimer.Tick += new EventHandler(ActualizarFecha);
                        dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                        dispatcherTimer.Start();*/
                        break;
                    case "Buscar":
                        Seccion1.Visibility = Visibility.Collapsed;
                        Seccion2.Visibility = Visibility.Visible;
                        break;
                    default:
                        break;
                }
            }
        }
        public void Persona_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is MenuItem menuItem)
            {
                string opcion = menuItem.Tag?.ToString();

                if (opcion != null)
                {
                    var personaWindow = new Persona(opcion);
                    personaWindow.Show();
                    Close();
                }
            }
        }
        private async void GuardarFactura_Click(object sender, RoutedEventArgs e)
        {
            // Extraer valores de los controles           
            PersonaModel selectedPersona = (PersonaModel)IdAgregarComboBox.SelectedItem;
            string fechaString = FechaTextBlock.Text;
            string montoString = MontoTextBox.Text;

            if (DateTime.TryParse(fechaString, out DateTime fecha) &&
                float.TryParse(montoString, out float monto) &&
                selectedPersona != null)
            {
                var nuevaFactura = new FacturaModel
                {
                    Fecha = fecha,
                    Monto = monto,
                    IdPersona = selectedPersona.IdPersona
                };

                bool exito = await services.FacturaService.StoreFactura(nuevaFactura);

                if (exito)
                {
                    MessageBox.Show("Factura guardada exitosamente");
                    
                    MontoTextBox.Text = string.Empty;
                    IdAgregarComboBox.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Error al guardar la factura");
                }
            }
            else
            {
                MessageBox.Show("Error en el formato de los datos. Verifica que los datos ingresados sean correctos.");
            }
        }
        private async void CargarPersonasEnComboBox()
        {
            // Obtener todas las personas desde el servicio
            List<PersonaModel> personas = await services.PersonaService.FindPersonas();

            if (personas != null)
            {
                // Asigna la lista de personas al ComboBox
                IdAgregarComboBox.ItemsSource = personas;
                IdAgregarComboBox.DisplayMemberPath = "Nombre";
                IdAgregarComboBox.SelectedValuePath = "IdPersona";
            }
            else
            {
                Console.WriteLine("Error al cargar las personas en el ComboBox");
            }
        }
        private void ActualizarFecha(object sender, EventArgs e)
        {
            FechaTextBlock.Text = $"Fecha: {DateTime.Now}";
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
        private async void BuscarFacturasPorPersona(string identificacion)
        {
            try
            {
                List<FacturaModel> facturas = await services.FacturaService.FindFacturasByPersona(identificacion);

                if (facturas != null && facturas.Count > 0)
                {
                    StringBuilder facturaText = new StringBuilder();
                    facturaText.AppendLine("Facturas encontradas:");

                    foreach (var factura in facturas)
                    {
                        facturaText.AppendLine($"Fecha: {factura.Fecha}, Monto: {factura.Monto}, IdPersona: {factura.IdPersona}");
                    }
                    FacturaTextBlock.Text = facturaText.ToString();
                }
                else
                {
                    MessageBox.Show("No se encontraron facturas para la persona con la identificación proporcionada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar las facturas por persona: {ex.Message}");
            }
        }

        private void BuscarFactura_Click(object sender, RoutedEventArgs e)
        {
            string identificacion = RFCTextBox.Text;
            BuscarFacturasPorPersona(identificacion);
        }

    }
}
