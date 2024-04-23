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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Markup;
using Practic.Models.Windows;

namespace Practic.Models.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main_page.xaml
    /// </summary>
    public partial class Main_page : Page
    {
        private SqlConnection sqlConnection = null;

        public Main_page()
        {
            InitializeComponent();
        }

        string role;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            sqlConnection.Open();

            //Проверка роли пользователя

            SqlCommand command = new SqlCommand("select Role From Users where Login like @log", sqlConnection);
            command.Parameters.AddWithValue("log", Data.Login);

            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataTable dataTable = new DataTable();
            //adapter.Fill(dataTable);

            if (command.ExecuteScalar().ToString() == "user")
            {
                role = "user";
                AddNewGame_btn.Visibility = Visibility.Hidden;
                AddInLib_btn.Visibility = Visibility.Hidden;
            }
            else
            {
                role = "admin";
                AddInLib_btn.Visibility = Visibility.Hidden;
            }

            EditDeleteGameGrid.Visibility = Visibility.Hidden;

            //Вывод списка игр

            command = new SqlCommand("select Games.Name as 'Название', Categories.Name as 'Категория', Games.Memory as 'Место' from Games, Categories where Games.Category = Categories.Id", sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            Datagrid.ItemsSource = dataTable.DefaultView;

            textbox.Text = "Поиск";
            textbox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
        }

        private void AddNewGame_Click(object sender, RoutedEventArgs e)
        {
            AddGame addGame = new AddGame();
            addGame.ShowDialog();
        }

        private void AddInLib_btn_Click(object sender, RoutedEventArgs e)
        {
            //SqlCommand command = new SqlCommand("select Games.Name as 'Название', Games.Category as 'Категория', Games.Memory as 'Место' from Games, Categories where Games.Category = Categories.Id", sqlConnection);
            SqlCommand command = new SqlCommand("select Name as 'Название', Category as 'Категория', Memory as 'Место' from Games", sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            //textbox.Text = dataTable.DefaultView[Datagrid.SelectedIndex]["Название"].ToString();

            //MessageBox.Show(Datagrid.SelectedIndex.ToString());
            //MessageBox.Show(dataTable.DefaultView[Datagrid.SelectedIndex]["Название"].ToString());

            command = new SqlCommand("Select Name from Library where Name like @name and Login like @log", sqlConnection);
            command.Parameters.AddWithValue("name", dataTable.DefaultView[Datagrid.SelectedIndex]["Название"].ToString());
            command.Parameters.AddWithValue("log", Data.Login);

            SqlDataAdapter adapter2 = new SqlDataAdapter(command);
            DataTable dataTable2 = new DataTable();
            adapter2.Fill(dataTable2);

            //MessageBox.Show(dataTable2.Rows.Count.ToString());
            //MessageBox.Show(command.ExecuteNonQuery().ToString());

            if (dataTable2.Rows.Count <= 0)
            {
                command = new SqlCommand("insert into Library (Name, Category, Memory, Login) values (@name, @category, @memory, @log)", sqlConnection);
                command.Parameters.AddWithValue("name", dataTable.DefaultView[Datagrid.SelectedIndex]["Название"].ToString());
                command.Parameters.AddWithValue("category", Convert.ToInt32(dataTable.DefaultView[Datagrid.SelectedIndex]["Категория"]));
                command.Parameters.AddWithValue("memory", (float)Convert.ToDouble(dataTable.DefaultView[Datagrid.SelectedIndex]["Место"]));
                command.Parameters.AddWithValue("log", Data.Login);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Игра добавлена в вашу библиотеку!");
                }
                else
                {
                    MessageBox.Show("Игра не добавлена в вашу библиотеку!");
                }
            }
            else
            {
                MessageBox.Show("Игра уже находится в вашей библиотеке!");
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command = new SqlCommand("select Games.Name as 'Название', Games.Category as 'Категория', Games.Memory as 'Место' from Games, Categories where Games.Category = Categories.Id", sqlConnection);
            command.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            Data.NameEditGame = dataTable.DefaultView[Datagrid.SelectedIndex]["Название"].ToString();
            Data.CategoryEditGame = Convert.ToInt32(dataTable.DefaultView[Datagrid.SelectedIndex]["Категория"]);
            Data.MemoryEditGame = (float)Convert.ToDouble(dataTable.DefaultView[Datagrid.SelectedIndex]["Место"]);

            EditGame editGame = new EditGame();
            editGame.ShowDialog();
        }

        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (role == "admin")
            {
                EditDeleteGameGrid.Visibility = Visibility.Visible;
            }
            else
            {
                AddInLib_btn.Visibility = Visibility.Visible;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Data.NamePage = "main";

            SqlCommand command = new SqlCommand("select Games.Name as 'Название', Games.Category as 'Категория', Games.Memory as 'Место' from Games, Categories where Games.Category = Categories.Id", sqlConnection);
            command.ExecuteNonQuery();

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
                SqlCommand command = new SqlCommand($"select Games.Name as 'Название', Categories.Name as 'Категория', Games.Memory as 'Место' from Games, Categories where Games.Category = Categories.Id and Games.Name like '%{textbox.Text}%'", sqlConnection);

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
