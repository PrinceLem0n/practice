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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        private SqlConnection sqlConnection = null;

        public Reg()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            sqlConnection.Open();

            nik.Text = "Ник";
            nik.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
            log.Text = "Логин";
            log.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
            pas.Text = "Пароль";
            pas.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
            open_eye.Visibility = Visibility.Hidden;
        }

        private void Reg_btn_Click(object sender, RoutedEventArgs e)
        {
            if (nik.Text == "" || log.Text == "" || pas.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                if (log.Text == "admin" || log.Text == "Admin")
                {
                    MessageBox.Show("Введите другой логин, пожалуйста!");
                }
                else
                {
                    SqlCommand command = new SqlCommand($"select Nik from Users where Login like @log or Login like '%{log.Text}%'", sqlConnection);
                    command.Parameters.AddWithValue("log", log.Text);

                    DataTable dataTable = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    adapter.SelectCommand = command;
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count <= 0)
                    {
                        SqlCommand command1 = new SqlCommand("Insert into Users (Nik, Login, Password, Role) values (@nik, @log, @pas, @role)", sqlConnection);
                        command1.Parameters.AddWithValue("nik", nik.Text);
                        command1.Parameters.AddWithValue("log", log.Text);
                        command1.Parameters.AddWithValue("pas", pas.Text);
                        if (log.Text.Contains("|admin|"))
                        {
                            command1.Parameters.AddWithValue("role", "admin");
                        }
                        else
                        {
                            command1.Parameters.AddWithValue("role", "user");
                        }
                        //command.Parameters.AddWithValue("role", "user");

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show($"Добро пожаловать, {command.ExecuteScalar()}!");
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не добавлен!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!");
                    }
                }
            }
        }

        private void log_lb_MouseEnter(object sender, MouseEventArgs e)
        {
            Log_lb.Foreground = (Brush)(new BrushConverter().ConvertFrom("#008a12"));
        }

        private void Log_lb_MouseLeave(object sender, MouseEventArgs e)
        {
            Log_lb.Foreground = Brushes.White;
        }

        private void Log_lb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            Log log = new Log();
            log.Show();
        }

        private void nik_GotFocus(object sender, RoutedEventArgs e)
        {
            nik.Foreground = Brushes.White;
            if (nik.Text == "Ник")
            {
                nik.Text = "";
            }
        }

        private void nik_LostFocus(object sender, RoutedEventArgs e)
        {
            if (nik.Text == "")
            {
                nik.Text = "Ник";
                nik.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
            }
        }

        private void log_GotFocus(object sender, RoutedEventArgs e)
        {
            log.Foreground = Brushes.White;
            if (log.Text == "Логин")
            {
                log.Text = "";
            }
        }

        private void log_LostFocus(object sender, RoutedEventArgs e)
        {
            if (log.Text == "")
            {
                log.Text = "Логин";
                log.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
            }
        }

        private void pas_GotFocus(object sender, RoutedEventArgs e)
        {
            pas.Foreground = Brushes.White;
            if (pas.Text == "Пароль")
            {
                pas.Text = "";
            }
        }

        private void pas_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pas.Text == "")
            {
                pas.Text = "Пароль";
                pas.Foreground = (Brush)(new BrushConverter().ConvertFrom("#6b6b6b"));
            }
        }

        string password;
        private void open_eye_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (password != "Пароль")
            {
                pas.Text = password;
            }
            open_eye.Visibility = Visibility.Hidden;
            close_eye.Visibility = Visibility.Visible;
        }

        private void close_eye_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            password = pas.Text;
            string hide_pas = "";

            if (password != "Пароль")
            {
                for (int i = 0; i < password.Length; i++)
                {
                    hide_pas += "●";
                }
                pas.Text = hide_pas;
            }
            open_eye.Visibility = Visibility.Visible;
            close_eye.Visibility = Visibility.Hidden;
        }
    }
}
