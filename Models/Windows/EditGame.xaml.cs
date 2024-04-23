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
    /// Логика взаимодействия для ChangeGame.xaml
    /// </summary>
    public partial class EditGame : Window
    {
        SqlConnection sqlConnection = null;

        public EditGame()
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

            Category_cb.ItemsSource = table.DefaultView;

            Name_tb.Text = Data.NameEditGame;
            Memory_tb.Text = Data.MemoryEditGame.ToString();
            Category_cb.SelectedIndex = Data.CategoryEditGame - 1;
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
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
                        SqlCommand command = new SqlCommand("select Name from Games where Name Like @name and Name not like @old_name", sqlConnection);
                        command.Parameters.AddWithValue("name", Name_tb.Text);
                        command.Parameters.AddWithValue("old_name", Data.NameEditGame);

                        DataTable dataTable = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count <= 0)
                        {
                            command = new SqlCommand($"select Id from Categories where Id = {Category_cb.SelectedIndex + 1}", sqlConnection);
                            int Category_id = Convert.ToInt32(command.ExecuteScalar());

                            command = new SqlCommand("update Games Set Name = @name, Category = @category, Memory = @memory where Name like @old_name", sqlConnection);
                            command.Parameters.AddWithValue("name", Name_tb.Text);
                            command.Parameters.AddWithValue("category", Category_id);
                            command.Parameters.AddWithValue("memory", Convert.ToDouble(Memory_tb.Text));
                            command.Parameters.AddWithValue("old_name", Data.NameEditGame);

                            command = new SqlCommand("update Library Set Name = @name, Category = @category, Memory = @memory where Name like @old_name", sqlConnection);
                            command.Parameters.AddWithValue("name", Name_tb.Text);
                            command.Parameters.AddWithValue("category", Category_id);
                            command.Parameters.AddWithValue("memory", Convert.ToDouble(Memory_tb.Text));
                            command.Parameters.AddWithValue("old_name", Data.NameEditGame);

                            if (command.ExecuteNonQuery() == 2)
                            {
                                MessageBox.Show("Данныые об игре обновлены!");
                                Data.MainFraimContent = "main";
                                this.Close();
                                Main main = new Main();
                                main.Show();
                            }
                            else
                            {
                                MessageBox.Show("Данныые об игре не обновлены!");
                            }
                        }
                    }
                }
            }


        }

        private void Memory_tb_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToDouble(Memory_tb.Text);
            }
            catch
            {
                MessageBox.Show("Введите число");
            }
        }
    }
}
