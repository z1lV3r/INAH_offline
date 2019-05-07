using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            lblNoId.Content = itemId > 0 ? itemId.ToString() : "No asignado";
        }

        private void btnUpper_Click(object sender, RoutedEventArgs e)
        {
            TextBox tbToUpper = ((TextBox)((DockPanel)((StackPanel)((Button)sender).Parent).Parent).Children[1]);
            tbToUpper.Text = tbToUpper.Text.ToUpper();
        }

        private void btnGuardarDetalle_Click(object sender, RoutedEventArgs e)
        {
            using (var entities = new DataEntities())
            {
                if ("No asignado".Equals(lblNoId.Content.ToString()))
                {
                    piezas pieza = new piezas();
                    pieza.Numero_de_inventario = tbNumeroRegistro.Text;
                    pieza.Numero_de_catalogo = tbNumeroCatalogo.Text;
                    pieza.Cantidad_ampara = int.Parse(tbPiezasAmparadas.Text);
                    pieza.Clave_de_museo = 1;
                    entities.piezas.Add(pieza);
                    try
                    {
                        entities.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        // Retrieve the error messages as a list of strings.
                        var errorMessages = ex.EntityValidationErrors
                                .SelectMany(x => x.ValidationErrors)
                                .Select(x => x.ErrorMessage);

                        // Join the list to a single string.
                        var fullErrorMessage = string.Join("; ", errorMessages);

                        // Combine the original exception message with the new one.
                        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                        // Throw a new DbEntityValidationException with the improved exception message.
                        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                    }

                    descripcion_basica descripcion = new descripcion_basica();
                    descripcion.Numero_de_inventario = tbNumeroRegistro.Text;
                    descripcion.Tipo_de_objeto = tbTipoObjeto.Text;
                    descripcion.Nombre_o_tema = tbNombreTema.Text;
                    descripcion.Autor = tbAutor.Text;
                    descripcion.Epoca = tbEpoca.Text;
                    descripcion.Cultura = tbCultura.Text;
                    descripcion.Origen = tbLugarOrigen.Text;
                    descripcion.Forma = tbForma.Text;
                    descripcion.Inscripciones = tbInscripciones.Text;
                    descripcion.Descripcion = tbDescripcion.Text;
                    descripcion.Observaciones = tbObservaciones.Text;
                    descripcion.Acervo = cbAcervo.Text;
                    descripcion.Conservacion = cbConservacion.SelectedIndex;
                    descripcion.Avaluo = int.Parse(tbAvaluo.Text);
                    entities.descripcion_basica.Add(descripcion);
                    entities.SaveChanges();

                    composicion composicion = new composicion();
                    composicion.Numero_de_inventario = tbNumeroRegistro.Text;
                    composicion.Materia_prima = tbMaterial.Text;
                    composicion.Tecnica_de_manufactura = tbTecnicaManufactura.Text;
                    composicion.Tecnica_decorativa = tbTecnicaDecorativa.Text;
                    entities.composicion.Add(composicion);
                    entities.SaveChanges();

                    adquisiciones adquisicion = new adquisiciones();
                    adquisicion.Numero_de_inventario = tbNumeroRegistro.Text;
                    adquisicion.Procedencia = tbProcedencia.Text;
                    adquisicion.Metodo_de_adquisicion = tbProcedencia.Text;
                    entities.adquisiciones.Add(adquisicion);
                    entities.SaveChanges();

                    ubicaciones ubicacion = new ubicaciones();
                    ubicacion.Numero_de_inventario = tbNumeroRegistro.Text;
                    ubicacion.Ubicacion_Actual = tbUbicacion.Text;
                    entities.ubicaciones.Add(ubicacion);
                    entities.SaveChanges();

                    medidas medidas = new medidas();
                    medidas.Numero_de_inventario = tbNumeroRegistro.Text;
                    medidas.Alto = float.Parse(tbAlto.Text);
                    medidas.Largo = float.Parse(tbLargo.Text);
                    medidas.Ancho = float.Parse(tbEspesor.Text);
                    medidas.Diametro = float.Parse(tbDiametro.Text);
                    medidas.Peso = float.Parse(tbPeso.Text);
                    entities.medidas.Add(medidas);
                    entities.SaveChanges();
                }
                else
                {
                    MessageBox.Show("update");
                }
            }
            MessageBox.Show("Operacion exitosa.", "OK", MessageBoxButton.OK);
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var coleccionesWindow = new ColeccionesWindow
            {
                WindowState = WindowState.Maximized
            };
            coleccionesWindow.Show();
        }
    }
}
