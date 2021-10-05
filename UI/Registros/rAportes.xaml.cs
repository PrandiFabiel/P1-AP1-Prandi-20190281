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
using P1_AP1_Prandi_20190281.BLL;
using P1_AP1_Prandi_20190281.Entidades; 

namespace P1_AP1_Prandi_20190281.UI.Registros
{
    /// <summary>
    /// Interaction logic for rAportes.xaml
    /// </summary>
    public partial class rAportes : Window
    {
        public class DateFormat : System.Windows.Data.IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null) return null;

                return ((DateTime)value).ToString("dd/MM/yyyy");
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        private Aportes aporte = new Aportes(); 
        public rAportes()
        {
            InitializeComponent();
            this.DataContext = aporte; 
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var aporte = AportesBLL.Buscar(Convert.ToInt32(AporteIdTextBox.Text));

            if (aporte != null)
                this.aporte = aporte;
            else
                Limpiar();

            this.DataContext = this.aporte;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar(); 
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            if (!Validar())
                return;

            var paso = AportesBLL.Guardar(aporte);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado exitoso!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Guardado Fallido", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AportesBLL.Eliminar(Convert.ToInt32(AporteIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado con exito", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool Validar()
        {
            bool esValido = true;

            if (PersonaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Rellena los campos vacios", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (ConceptoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Rellena los campos vacios", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (MontoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Rellena los campos vacios", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }


            return esValido;
        }

        private void Limpiar()
        {
            this.aporte = new Aportes();
            this.DataContext = aporte;
        }

    }
}
