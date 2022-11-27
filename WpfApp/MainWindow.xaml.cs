using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();
            string connectionStr = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=true";
            sqlConnection = new SqlConnection(connectionStr);
            showCustomers();
        }

        private void showCustomers()
        {
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
                    ("select * from Customers", sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable customerTable = new DataTable();
                    sqlDataAdapter.Fill(customerTable);

                    customerList.DisplayMemberPath = "Name";
                    customerList.SelectedValuePath = "Id";
                    customerList.ItemsSource = customerTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void CustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string query = "select * from Appointments join Customers " +
                    "on Appointments.CustomerId = Customers.Id " +
                    "where Customers.Id = @CustomerId";

                var CustomerId = customerList.SelectedValue;

                // 为了处理@CustomerId
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@CustomerId", CustomerId);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    DataTable appointmentTable = new DataTable();
                    sqlDataAdapter.Fill(appointmentTable);

                    appointmentList.DisplayMemberPath = "Time";
                    appointmentList.SelectedValuePath = "Id";
                    appointmentList.ItemsSource = appointmentTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListBox_SelectionChanged()
        {
        }
    }
}