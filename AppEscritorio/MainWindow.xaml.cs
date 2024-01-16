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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppEscritorio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Navigation_Click(object sender, RoutedEventArgs e)
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
        private void Navigation_Click_Factura(object sender, RoutedEventArgs e)
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

    }
}
