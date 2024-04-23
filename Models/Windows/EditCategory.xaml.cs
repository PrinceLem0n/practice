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
    /// Логика взаимодействия для EditCategory.xaml
    /// </summary>
    public partial class EditCategory : Window
    {
        SqlConnection sqlConnection = null;

        public EditCategory()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            sqlConnection.Open();

            Name_tb.Text = Data.NameEditCategory;
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Name_tb.Text == "")
            {
                MessageBox.Show("Введите название!");
                Name_tb.Focus();
            }
            else
            {
                SqlCommand command = new SqlCommand("update Categories set Name = @name where Name like @old_name", sqlConnection);
                command.Parameters.AddWithValue("name", Name_tb.Text);
                command.Parameters.AddWithValue("old_name", Data.NameEditCategory);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Информация о категории обнавлена!");
                    Data.MainFraimContent = "category";
                    this.Close();
                    Main main = new Main();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Информация о категории не обнавлена!");
                }
            }
        }
    }
}
