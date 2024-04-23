﻿using System;
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
    /// Логика взаимодействия для AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        SqlConnection sqlConnection = null;

        public AddCategory()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            sqlConnection.Open();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Name_tb.Text == "")
            {
                MessageBox.Show("Введите название!");
                Name_tb.Focus();
            }
            else
            {
                SqlCommand command = new SqlCommand("insert into Categories (Name) values (@name)", sqlConnection);
                command.Parameters.AddWithValue("name", Name_tb.Text);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Категория добавлена!");
                    Data.MainFraimContent = "category";
                    this.Close();
                    Main main = new Main();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Категория не добавлена!");
                }
            }
        }
    }
}