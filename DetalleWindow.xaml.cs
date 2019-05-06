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

namespace INAH
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class DetalleWindow : Window
    {
        public DetalleWindow(int itemId)
        {
            InitializeComponent();
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
            this.MinWidth = SystemParameters.PrimaryScreenWidth;
            this.MinHeight = SystemParameters.PrimaryScreenHeight;
            //Cargar datos desde base
            lblNoId.Content = itemId.ToString();
        }

        private void btnUpper_Click(object sender, RoutedEventArgs e)
        {
            TextBox tbToUpper = ((TextBox)((DockPanel)((StackPanel)((Button)sender).Parent).Parent).Children[1]);
            tbToUpper.Text = tbToUpper.Text.ToUpper();
        }

        private void btnGuardarDetalle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
