using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodWord
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            EmployeeeShowData();
            CustomerShowData();
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchEmail(textBoxSce.Text);
        }
        public void searchEmail(string valueToFind)
        {

            try
            {
                // Establish connection
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                {
                    con.Open();

                    // Use parameterized query to prevent SQL injection
                    string query = "SELECT * FROM Registration_db WHERE email LIKE @valueToFind";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@valueToFind", "%" + valueToFind + "%");

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                } // This will automatically close the connection when leaving the 'using' block
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }

            try
            {
                // Establish connection
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                {
                    con.Open();

                    // Use parameterized query to prevent SQL injection
                    string query = "SELECT * FROM Table_Customer WHERE email LIKE @valueToFind";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@valueToFind", "%" + valueToFind + "%");

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dataGridView2.DataSource = dt;
                } // This will automatically close the connection when leaving the 'using' block
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        public void EmployeeeShowData()
        {
            try
            {
                // Establish connection
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                {
                    con.Open();

                    // Create SQL command
                    string query = "SELECT SL,email,firstName,lastName,age,gender,address,phone FROM Registration_db";

                    using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                } // This will automatically close the connection when leaving the 'using' block
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        public void CustomerShowData()
        {
            try
            {
                // Establish connection
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                {
                    con.Open();

                    // Create SQL command
                    string query = "SELECT * FROM Table_Customer";

                    using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                } // This will automatically close the connection when leaving the 'using' block
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();  
            adminPage.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Establish connection
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                {
                    con.Open();
                    int index = dataGridView1.CurrentCell.RowIndex;
                    string slValue = dataGridView1.Rows[index].Cells["SL"].Value.ToString(); // Assuming SL is the name of the column containing the primary key
                    string deleteQuery = "DELETE FROM Registration_db WHERE SL = @SL";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, con);
                    deleteCommand.Parameters.AddWithValue("@SL", slValue);
                    deleteCommand.ExecuteNonQuery();
                    con.Close();

                    dataGridView1.Rows.RemoveAt(index);
                    MessageBox.Show("Row deleted successfully.");
                } // This will automatically close the connection when leaving the 'using' block
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
            //Customer data delete
            try
            {
                // Establish connection
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                {
                    con.Open();
                    int index = dataGridView2.CurrentCell.RowIndex;
                    string slValue = dataGridView1.Rows[index].Cells["SL"].Value.ToString(); // Assuming SL is the name of the column containing the primary key
                    string deleteQuery = "DELETE FROM Table_Customer WHERE SL = @SL";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, con);
                    deleteCommand.Parameters.AddWithValue("@SL", slValue);
                    deleteCommand.ExecuteNonQuery();
                    con.Close();

                    dataGridView2.Rows.RemoveAt(index);
                    MessageBox.Show("Row deleted successfully.");
                } // This will automatically close the connection when leaving the 'using' block
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }
    }
}
