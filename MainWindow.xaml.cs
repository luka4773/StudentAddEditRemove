using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace LetsDoThis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentViewModel studentViewModel = new StudentViewModel();
        Student student = new Student();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = studentViewModel;
            DataContext = student;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString =
             @"Data Source=E:\ConstructionSemester2\LetsDoThis\LetsDoThis\StudentsDB.mdf";            
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO StudentTable(Name,Address,Age)VALUES(@Name,@Address,@Age)";
            cmd.Parameters.AddWithValue("@Name", StudentName.Text);
            cmd.Parameters.AddWithValue("@Address", StudentAddress.Text);
            cmd.Parameters.AddWithValue("@Age", StudentAge.Text);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            
        
        }
    }
}
