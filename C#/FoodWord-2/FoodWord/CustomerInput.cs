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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FoodWord
{
    public partial class CustomerInput : Form
    {


        public CustomerInput()
        {
            InitializeComponent();
        }

        public static string UserPhone = "";
        public static string UserName  = "";
       string gender = "";

        private void buttonDone_Click(object sender, EventArgs e)
        {
            string email = textEmail.Text;
            string firstName = textFristname.Text; // Corrected variable name
            string lastName = textLastname.Text; // Corrected variable name
            string phone = textPhone.Text;
            string address = textAddress.Text; // Corrected variable name
            string age = textAge.Text;
            //string gender = ""; // You need to provide the gender or modify the query accordingly
            if (textEmail.Text == null || textFristname.Text == null || textPhone.Text == null || textAddress.Text == null || textAge.Text == null || gender == null)
            {
                MessageBox.Show("Missing Information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // Establish connection
                    using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                    {
                        con.Open();

                        // Create SQL command
                        string query = "INSERT INTO Table_Customer (email, firstName, lastName, age, gender, address, phone) " +
                                       "VALUES (@Email, @FirstName, @LastName, @Age, @Gender, @Address, @Phone)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            // Add parameters
                            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email; // Assuming email length up to 100 characters
                            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = firstName; // Adjust length as needed
                            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = lastName; // Adjust length as needed
                            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = Convert.ToInt32(age); // Assuming age is an integer
                            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 10).Value = gender; // Assuming gender length up to 10 characters
                            cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = address; // Adjust length as needed
                            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = phone; // Adjust length as needed

                            // Execute the query
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registration successful!");

                                UserName = textEmail.Text;
                                UserPhone = textPhone.Text;
                                Payment payment = new Payment();
                                this.Hide();
                                payment.Show();
                            }
                            else
                            {
                                MessageBox.Show("Registration failed!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }


        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = " Male ";
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = " Female ";
        }

        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            this.Hide();
            homepage.Show();
        }

        private void textAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }

        }

        private void textPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }

        }
    }
}
