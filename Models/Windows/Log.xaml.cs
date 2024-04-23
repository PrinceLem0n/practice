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
using System.Data.Common;

namespace Practic.Models.Windows
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        private SqlConnection sqlConnection = null;

        public Log()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            sqlConnection.Open();

            Log_tb.Text = "Логин";
            Log_tb.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
            Pas_tb.Text = "Пароль";
            Pas_tb.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
            open_eye.Visibility = Visibility.Hidden;
        }

        private void Show_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command = new SqlCommand("select Nik from Users where Login like @log and Password like @pas", sqlConnection);

            command.Parameters.AddWithValue("log", Log_tb.Text);
            command.Parameters.AddWithValue("pas", Pas_tb.Text);

            DataTable dataTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(dataTable);

            if (Log_tb.Text == "" || Pas_tb.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                if (dataTable.Rows.Count != 0)
                {
                    MessageBox.Show($"Добро пожаловать, {command.ExecuteScalar()}!");
                    Data.Login = Log_tb.Text;
                    this.Hide();
                    Main main = new Main();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
        }

        private void Log_tb_GotFocus(object sender, RoutedEventArgs e)
        {
            Log_tb.Foreground = Brushes.White;
            if (Log_tb.Text == "Логин")
            {
                Log_tb.Text = "";
            }
        }

        private void Log_tb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Log_tb.Text == "")
            {
                Log_tb.Text = "Логин";
                Log_tb.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
            }
        }
        
        private void Pas_tb_GotFocus(object sender, RoutedEventArgs e)
        {
            Pas_tb.Foreground = Brushes.White;
            if (Pas_tb.Text == "Пароль")
            {
                Pas_tb.Text = "";
            }
        }

        private void Pas_tb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Pas_tb.Text == "")
            {
                Pas_tb.Text = "Пароль";
                Pas_tb.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
            }
        }
        string pas;
        private void open_eye_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (pas != "Пароль")
            {
                Pas_tb.Text = pas;
            }
            open_eye.Visibility = Visibility.Hidden;
            close_eye.Visibility = Visibility.Visible;
        }

        private void close_eye_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pas = Pas_tb.Text;
            string hide_pas = "";

            if (pas != "Пароль")
            {
                for (int i = 0; i < pas.Length; i++)
                {
                    hide_pas += "●";
                }
                Pas_tb.Text = hide_pas;
            }
            open_eye.Visibility = Visibility.Visible;
            close_eye.Visibility = Visibility.Hidden;
        }

        private void Reg_lb_MouseEnter(object sender, MouseEventArgs e)
        {
            Reg_lb.Foreground = (Brush)(new BrushConverter().ConvertFrom("#008a12"));
        }

        private void Reg_lb_MouseLeave(object sender, MouseEventArgs e)
        {
            Reg_lb.Foreground = Brushes.White;
        }

        private void Reg_lb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            Reg reg = new Reg();
            reg.Show();
        }
    }
}
