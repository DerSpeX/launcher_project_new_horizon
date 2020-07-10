using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Media;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;


namespace launcher_project_new_horizon
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();

        public Register()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WPF"].ConnectionString.ToString();
        }

        private void RegisterWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

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

        // private void btnMusicPause_Click(object sender, RoutedEventArgs e)
        // {
        // }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string Forname = Convert.ToString(txtForname);
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["WPF"].ConnectionString.ToString();

            

            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "INSERT Users (Forname) VALUES ('Forname')";
            com.Connection = con;

            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            Console.WriteLine();

        }


    }
}
