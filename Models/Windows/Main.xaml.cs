using Practic.Models.Pages;
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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private SqlConnection sqlConnection = null;

        public Main()
        {
            InitializeComponent();
        }

        string but;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            sqlConnection.Open();

            if (Data.MainFraimContent == "main")
            {
                Frame.Content = new Main_page();
                but = "main";
                Main_btn.IsEnabled = false;
            }
            else
            {
                if (Data.MainFraimContent == "library")
                {
                    Frame.Content = new Library();
                    but = "library";
                    Library_btn.IsEnabled = false;
                }
                else
                {
                    Frame.Content = new Category();
                    but = "category";
                    Category_btn.IsEnabled = false;
                }
            }

            SqlCommand command = new SqlCommand("select Role From Users where Login like @log", sqlConnection);
            command.Parameters.AddWithValue("log", Data.Login);

            if (command.ExecuteScalar().ToString() == "user")
            {
                Category_btn.Visibility = Visibility.Hidden;
            }
            else
            {
                Library_btn.Height = 0;
            }
        }

        bool visible;
        private async void Menu_img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (!visible)
            {
                int n = 150;
                while (n > 0)
                {
                    await Task.Delay(1);
                    if (n / 10 == 1)
                    {
                        n -= 2;
                        Menu_column.Width = new GridLength(n);
                    }
                    else
                    {
                        if (n < 10)
                        {
                            n -= 1;
                            Menu_column.Width = new GridLength(n);
                        }
                        else
                        {
                            n -= n / 10;
                            Menu_column.Width = new GridLength(n);
                        }
                    }
                }
                visible = !visible;
            }
            else
            {
                int w = 150;
                int n = 0;
                while (n < 150)
                {
                    await Task.Delay(1);
                    if (w / 10 == 1)
                    {
                        n += 2;
                        Menu_column.Width = new GridLength(n);
                    }
                    else
                    {
                        if (w < 10)
                        {
                            n += 1;
                            Menu_column.Width = new GridLength(n);
                        }
                        else
                        {
                            n += w / 10;
                            Menu_column.Width = new GridLength(n);
                        }
                    }
                    w -= w / 10;
                    Menu_column.Width = new GridLength(n);
                }
                visible = !visible;
            }
        }

        private void Close_img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Main_btn_Click(object sender, RoutedEventArgs e)
        {
            if (but != "main")
            {
                Frame.Content = new Main_page();
                but = "main";
                Main_btn.IsEnabled = false;
                Library_btn.IsEnabled = true;
                Category_btn.IsEnabled = true;
            }
        }

        private void Library_btn_Click(object sender, RoutedEventArgs e)
        {
            if (but != "library")
            {
                Frame.Content = new Library();
                but = "library";
                Library_btn.IsEnabled = false;
                Main_btn.IsEnabled = true;
            }
        }

        private void Category_btn_Click(object sender, RoutedEventArgs e)
        {
            if(but != "category")
            {            
                Frame.Content = new Category();
                but = "category";
                Category_btn.IsEnabled = false;
                Main_btn.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Log log = new Log();
            log.Show();
        }
    }
}
