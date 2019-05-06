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
    public partial class ColeccionesWindow : Window
    {
        public ColeccionesWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            //Get items from database by user
            String[] tittles = { "Elemento1", "Elemento2", "Elemento3", "Elemento4", "Elemento5" };

            int pi = 1;

            WrapPanelColecciones.Children.Add(Utils.GetCollectionsItem(@"img\anadir.png", "Agregar elemento", "Agregar", -1, detailBtn_Click, mouse_enter, mouse_leave));

            foreach (String title in tittles)
            {
                WrapPanelColecciones.Children.Add(Utils.GetCollectionsItem(@"img\p"+pi+".jpg", "titulo" + pi, "Mostrar detalle", pi, detailBtn_Click, mouse_enter, mouse_leave));
                pi++;
            }

            //Add a final item to add a new element
        }

        private void detailBtn_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            DetalleWindow detalleWindow = new DetalleWindow((int)button.Tag);
            this.Close();
            detalleWindow.Show();
        }

        private void mouse_enter(object sender, EventArgs e)
        {
            var frontContainer = (Grid)sender;
            var backContainer = frontContainer.Children[0];
            backContainer.Visibility = Visibility.Visible;
            backContainer.Opacity = 1;
        }

        private void mouse_leave(object sender, EventArgs e)
        {
            var frontContainer = (Grid)sender;
            var backContainer = frontContainer.Children[0];
            backContainer.Opacity = 0;
            backContainer.Visibility = Visibility.Collapsed;
        }
    }
}
