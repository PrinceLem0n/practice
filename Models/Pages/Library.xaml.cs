using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
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
using Practic.Models.Windows;

namespace Practic.Models.Pages
{
    /// <summary>
    /// Логика взаимодействия для Library.xaml
    /// </summary>
    public partial class Library : Page
    {
        SqlConnection sqlConnection = null;
        public Library()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            sqlConnection.Open();

            SqlCommand command = new SqlCommand("select Library.Name as 'Название', Categories.Name as 'Категория', Library.Memory as 'Место' from Library, Categories where Library.Category = Categories.Id and Library.Login like @log", sqlConnection);
            command.Parameters.AddWithValue("log", Data.Login);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            Datagrid.ItemsSource = dataTable.DefaultView;

            Delete_btn.Visibility = Visibility.Hidden;

            textbox.Text = "Поиск";
            textbox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
        }

        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Delete_btn.Visibility = Visibility.Visible;
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            Data.NamePage = "Library";

            //SqlCommand command = new SqlCommand("select Library.Name as 'Название', Library.Category as 'Категория', Library.Memory as 'Место' from Library, Categories where Library.Category = Categories.Id and Library.Login like @log", sqlConnection);
            SqlCommand command = new SqlCommand("select Name as 'Название' from Library where Library.Login like @log", sqlConnection);
            command.Parameters.AddWithValue("log", Data.Login);
            //command.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            Data.NameDeleteGame = dataTable.DefaultView[Datagrid.SelectedIndex]["Название"].ToString();
            //Data.CategoryDeleteGame = Convert.ToInt32(dataTable.DefaultView[Datagrid.SelectedIndex]["Категория"]);
            //Data.MemoryDeleteGame = (float)Convert.ToDouble(dataTable.DefaultView[Datagrid.SelectedIndex]["Место"]);

            DeleteGame deleteGame = new DeleteGame();
            deleteGame.ShowDialog();
        }

        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textbox.Text != "Поиск")
            {
                SqlCommand command = new SqlCommand($"select Library.Name as 'Название', Categories.Name as 'Категория', Library.Memory as 'Место' from Library, Categories where Library.Category = Categories.Id and Library.Login like @log and Library.Name like '%{textbox.Text}%'", sqlConnection);
                command.Parameters.AddWithValue("log", Data.Login);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                Datagrid.ItemsSource = dataTable.DefaultView;
            }
        }

        private void textbox_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox.Foreground = Brushes.White;
            if (textbox.Text == "Поиск")
            {
                textbox.Text = "";
            }
        }

        private void textbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "")
            {
                textbox.Text = "Поиск";
                textbox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
            }
        }
    }
}
