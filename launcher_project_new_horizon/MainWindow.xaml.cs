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
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Media;

namespace launcher_project_new_horizon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public MainWindow()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WPF"].ConnectionString.ToString();

        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            if (VerifyUser(txtUsername.Text, txtPassword.Password))
            {
                MessageBox.Show("Weiterleitung erfolgt...", "Anmeldung Erfolgreich", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Benutzername oder Passwort ist falsch. Korrigiere deine Eingabe!", "Anmeldung Fehlgeschlagen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool VerifyUser(string username, string password)
        {
            con.Open();
            com.Connection = con;
            com.CommandText = "select ID from Users where username='" + username + "' and password='" + password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                if (Convert.ToBoolean(dr["ID"]) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //private void btnMusic_LoadPlay(object sender, RoutedEventArgs e)
        //{
        //   SoundPlayer sp = new SoundPlayer();
        //   sp.SoundLocation = @".\GTAIVTHEME.wav";
        //   sp.PlayLooping();
        //  }
        private void btnMusicPlay_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @".\GTAIVTHEME.wav";
            sp.PlayLooping();
        }


        private void btnMusicMute_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @".\GTAIVTHEME.wav";
            sp.Stop();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register objRegister = new Register();
            this.Visibility = Visibility.Hidden;
            objRegister.Show();
        }

        private void btnMusicPause_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
