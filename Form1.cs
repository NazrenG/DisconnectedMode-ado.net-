using Microsoft.Data.SqlClient;
using System.Data;

namespace DisconnectedMode
{
    public partial class Form1 : Form
    {
        SqlConnection? sqlConnection = null;
        SqlDataAdapter? adapter=null;
        DataTable? dataTable = null;

        string connectionString = "Data Source=WIN-EFS54O4O7OC\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;";


        public Form1()
        {
            InitializeComponent();

            sqlConnection=new SqlConnection(connectionString);
            string query = "Select * from Authors";
             adapter = new SqlDataAdapter(query, sqlConnection);
             dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {

            UpdateDeleteInsert();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            UpdateDeleteInsert();

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
           UpdateDeleteInsert();
        }

        private void UpdateDeleteInsert()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            if (dataTable != null)
            {
                adapter.Update(dataTable);
            }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                string query2 = $"select * from Authors where FirstName=@name";
                SqlCommand sqlCommand = new SqlCommand(query2,sqlConnection);
                sqlCommand.Parameters.AddWithValue("@name", textBox1.Text);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);

                DataTable dataTable1 = new DataTable();
                dataAdapter.Fill(dataTable1);
                dataGridView1.DataSource = dataTable1;
            }
        }
    }
}