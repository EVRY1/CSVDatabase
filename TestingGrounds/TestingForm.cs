using System;
using System.IO; //For File Manipulation
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestingGrounds
{
    public partial class TestingForm : Form
    {
        String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public TestingForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            String sqlShowCommand = "SELECT * FROM GradesList";
            String sqlDeleteCommand = "DELETE FROM GradesList";
            FileInfo importFile = new FileInfo(@"C:\Users\octav_000.TOSHIBA\source\repos\TestingGrounds\TestingGrounds\GradesList_Import.sql");
            String sqlImportCommand = importFile.OpenText().ReadToEnd();
            SqlCommand sqlImport = new SqlCommand(sqlImportCommand, sqlConnection);
            SqlCommand sqlDelete = new SqlCommand(sqlDeleteCommand, sqlConnection);
            using (sqlConnection)
            {
                sqlConnection.Open();
                sqlDelete.ExecuteNonQuery();
                sqlImport.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlShowCommand, sqlConnection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                studentsGridView.DataSource = dataTable;
            }
            sqlConnection.Close();
        }
    }
}
