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
using Practic.Models.Windows;

namespace Practic.Models.Pages
{
    /// <summary>
    /// Логика взаимодействия для Category.xaml
    /// </summary>
    public partial class Category : Page
    {
        SqlConnection sqlConnection = null;

        public Category()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            sqlConnection.Open();

            SqlCommand command = new SqlCommand("select Name as 'Название' from Categories", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            Datagrid.ItemsSource = dataTable.DefaultView;

            Edit_btn.Visibility = Visibility.Hidden;

            textbox.Text = "Поиск";
            textbox.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
        }

        private void AddNewCategory_btn_Click(object sender, RoutedEventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            addCategory.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command = new SqlCommand("select Name as 'Название' from Categories", sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            Data.NameEditCategory = dataTable.DefaultView[Datagrid.SelectedIndex]["Название"].ToString();

            EditCategory editCategory = new EditCategory();
            editCategory.ShowDialog();
        }

        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Edit_btn.Visibility = Visibility.Visible;
        }

        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textbox.Text != "Поиск")
            {
                SqlCommand command = new SqlCommand($"select Name as 'Название' from Categories where Name like N'%{textbox.Text}%'", sqlConnection);

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
