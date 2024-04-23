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

namespace Practic.Models.Pages
{
    /// <summary>
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Page
    {
        private SqlConnection sqlConnection = null;

        public Test()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            sqlConnection.Open();

            SqlCommand command = new SqlCommand("select Games.Name, Categories.Name, Games.Memory from Games, Categories where Games.Category = Categories.Id", sqlConnection);

            using (sqlConnection)
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader[0].ToString();
                    string category = reader[1].ToString();
                    string memory = reader[2].ToString();

                    ListViewItem item = new ListViewItem();
                    item.Content = new { Name = name, Category = category, Memory = memory };
                    ListView.Items.Add(item);
                }
                reader.Close();




                //Код для добавления картинки


                /*
                <GridViewColumn Header="Изображение" Width="auto">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Image Source="{Binding Img}" Width="100" Height="auto"/>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                 */
            }
        }
    }
}
