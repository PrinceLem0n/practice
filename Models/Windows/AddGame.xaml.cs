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
using Practic.Models.Pages;

namespace Practic.Models.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddGame.xaml
    /// </summary>
    public partial class AddGame : Window
    {
        SqlConnection sqlConnection = null;

        public AddGame()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            sqlConnection.Open();

            SqlCommand command = new SqlCommand("Select Name from Categories", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            Category_cb.DisplayMemberPath = "Name";
            //Category_cb.value

            Category_cb.ItemsSource = table.DefaultView;
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Memory_tb_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToDouble(Memory_tb.Text);
            }
            catch
            {
                MessageBox.Show("Введите число!");
            }
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Name_tb.Text == "")
            {
                MessageBox.Show("Введите имя игры!");
                Name_tb.Focus();
            }
            else
            {
                if (Memory_tb.Text == "")
                {
                    MessageBox.Show("Введите занимаемый игрой объём памяти!");
                    Memory_tb.Focus();
                }
                else
                {
                    if (Category_cb.SelectedItem == null)
                    {
                        MessageBox.Show("Выберите категорию, к которой относится игра!");
                        Category_cb.Focus();
                    }
                    else
                    {
                        SqlCommand command = new SqlCommand("select Name from Games where Name like @name", sqlConnection);
                        command.Parameters.AddWithValue("name", Name_tb.Text);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count <= 0)
                        {
                            command = new SqlCommand($"select Id from Categories where Id = {Category_cb.SelectedIndex + 1}", sqlConnection);
                            int Category_id = Convert.ToInt32(command.ExecuteScalar());

                            command = new SqlCommand("insert into Games (Name, Category, Memory) values (@name, @category, @memory)", sqlConnection);

                            command.Parameters.AddWithValue("name", Name_tb.Text);
                            command.Parameters.AddWithValue("category", Category_id);
                            command.Parameters.AddWithValue("memory", Convert.ToDouble(Memory_tb.Text));

                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Игра добавлена!");
                                Data.MainFraimContent = "main";
                                this.Close();
                                Main main = new Main();
                                main.Show();
                            }
                            else
                            {
                                MessageBox.Show("Игра не добавлена!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Игра с таким названием уже существует!");
                            Name_tb.Focus();
                        }
                    }
                }
            }            
        }
    }
}
