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
            WrapPanelColecciones.Children.Add(Utils.GetCollectionsItem(@"img\anadir.png", "Agregar elemento", "Agregar", "-1", detailBtn_Click, mouse_enter, mouse_leave));


            //Get items from database by user
            using (var entities = new DataEntities())
            {
                
                int pi = 1;
                foreach (piezas pieza in entities.piezas.ToList())
                {
                    descripcion_basica desc = entities.descripcion_basica.Where(d => d.Numero_de_inventario == pieza.Numero_de_inventario).ToList()[0];
                    WrapPanelColecciones.Children.Add(Utils.GetCollectionsItem(@"img\p"+pi+".jpg", desc.Nombre_o_tema, "Mostrar detalle", pieza.Numero_de_inventario, detailBtn_Click, mouse_enter, mouse_leave));
                    pi = pi < 5 ? pi+1 : 1;
                }
            }




            //Add a final item to add a new element
        }

        private void detailBtn_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            DetalleWindow detalleWindow = new DetalleWindow(int.Parse(button.Tag.ToString()));
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
