using INAH.config;
using INAH.constants.database;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
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

namespace INAH
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDataStructure();
        }

        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            if (MatchPassword(TbUsuario.Text, TbPassword.Password))
            {
                var detalleWindow = new DetalleWindow
                {
                    WindowState = WindowState.Maximized
                };
                this.Close();
                detalleWindow.Show();
            }
            else
            {
                //TODO: show error message
            }
        }

        private void InitializeDataStructure()
        {   
            if (!File.Exists(DatabaseConstants.DATABASE_FILE))
            {
                var sqEng = new SqlCeEngine(DatabaseConstants.DATABASE_STRING_CONNECTION);
                sqEng.CreateDatabase();

                var sqConn = new SqlCeConnection(DatabaseConstants.DATABASE_STRING_CONNECTION);
                sqConn.Open();
                var sqCmd = new SqlCeCommand(DatabaseConstants.CREATE_TABLE_CREDENTIALS, sqConn);
                sqCmd.ExecuteNonQuery();
                sqConn.Close();
            }
        }

        private bool MatchPassword(string user, string password)
        {
            //TODO: check external information
            //using (var entities = new DataEntities())
            //{
            //    credentials c = new credentials
            //    {
            //        Key = Utils.getHashSha256("123"),
            //        User = "user"
            //    };
            //    entities.credentials.Add(c);
            //    entities.SaveChanges();
            //}
            //TODO: check local database
            using (var entities = new DataEntities())
            {
                var cypherPass = Utils.getHashSha256(password);
                var result = entities.credentials.Where(c => c.User == user && c.Key == cypherPass).ToList();

                if (result.Count == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
