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
    public partial class PaymentList : Form
    {
        public PaymentList()
        {
            InitializeComponent();
            ShowData();
            ShowCount();
            ShowAmount();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this .Hide();
        }

        public void ShowData()
        {
            try
            {
                // Establish connection
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                {
                    con.Open();

                    // Create SQL command
                    string query = "SELECT * FROM Table_Payment";

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

        public void ShowCount()
        {
            string connectionString = "Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;";
            string query = "SELECT COUNT(SL) FROM Table_Payment";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                labelPayNo.Text = count.ToString();
            }
        }

        public void ShowAmount()
        {
            string connectionString = "Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;";
            string query = "SELECT SUM(Payment_Amount) FROM Table_Payment"; // Assuming you want the sum of amounts

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    decimal amount = Convert.ToDecimal(result);
                    labelAmo.Text = amount.ToString("0.00"); // Format amount with two decimal places
                }
                else
                {
                    labelAmo.Text = "0.00"; // If no amount found, display zero
                }
            }
        }

    }
}
