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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Practic.Models.Windows
{
    /// <summary>
    /// Логика взаимодействия для DeleteGame.xaml
    /// </summary>
    public partial class DeleteGame : Window
    {
        SqlConnection sqlConnection = null;

        public DeleteGame()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            sqlConnection.Open();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            if (Data.NamePage == "main")
            {
                SqlCommand command = new SqlCommand("delete from Games where Name like @name", sqlConnection);
                command.Parameters.AddWithValue("name", Data.NameDeleteGame);

                command.ExecuteNonQuery();
                MessageBox.Show("Игра удалена!");
                Data.MainFraimContent = "main";
                this.Close();
                Main main = new Main();
                main.Show();
            }
            else
            {
                SqlCommand command = new SqlCommand("delete from Library where Name like @name and Login like @log", sqlConnection);
                command.Parameters.AddWithValue("name", Data.NameDeleteGame);
                command.Parameters.AddWithValue("log", Data.Login);

                command.ExecuteNonQuery();
                MessageBox.Show("Игра удалена!");
                Data.MainFraimContent = "library";
                this.Close();
                Main main = new Main();
                main.Show();
            }
        }
    }
}
