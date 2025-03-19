using MySql.Data.MySqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection kapcs = new MySqlConnection("server = server.fh2.hu;database = v2labgwj_12a; uid = v2labgwj_12a; password = 'HASnEeKvbDEPGgvTZubG';");

        public MainWindow()
        {
            InitializeComponent();
            //try
            //{
            //    kapcs.Open();
            //    MessageBox.Show("Siker");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("db hiba");
            //}
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            kapcs.Open();
            var sql = $"select * from user_homonnair where nev = '{txtNev.Text}' and jelszo = '{txtJelszo.Password}'";
            
            lbDebug.Content = sql;
            
            var lekerdezes = new MySqlCommand(sql, kapcs).ExecuteReader();
            if (lekerdezes.Read())  {
                    MessageBox.Show("sikeres bejelentkezes");
             } 
            else {
                    MessageBox.Show("Hibás bejelentkezés.");
                }
            kapcs.Close();
        }
    }
}