using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace FoodWord
{
    public partial class RegistrationPage : Form
    {
        string gender;

        string pattern = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";

        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrationPage_Load(object sender, EventArgs e)
        {

        }

        private void buttonPassShowHide_Click(object sender, EventArgs e)
        {
            if (textPassword.PasswordChar == '*')
            {
                textPassword.PasswordChar = '\0';
            }
            else if (textPassword.PasswordChar == '\0')
            {
                textPassword.PasswordChar = '*';
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            string email = textEmail.Text;
            string fristName = textFristname.Text;
            string lastName = textLastname.Text;
            string phone = textPhone.Text;
            string password = textPassword.Text;
            string adderss = textAddress.Text;
            string age = textAge.Text;

            if (textEmail.Text == null || textFristname.Text == null || textPhone.Text == null || textPassword.Text == null || textAddress.Text == null || textAge.Text == null || gender == null)
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
                        string query = "INSERT INTO Registration_db (email, firstName, lastName, password, age, gender , address, phone) " +
                                        "VALUES (@Email, @FirstName, @LastName, @Password, @Age, @Gender, @Address, @Phone)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            // Add parameters

                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@FirstName", fristName);
                            cmd.Parameters.AddWithValue("@LastName", lastName);
                            cmd.Parameters.AddWithValue("@Phone", phone);
                            cmd.Parameters.AddWithValue("@Password", password);
                            cmd.Parameters.AddWithValue("@Address", adderss);
                            cmd.Parameters.AddWithValue("@Age", age);
                            cmd.Parameters.AddWithValue("@Gender", gender);


                            // Execute the query
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registration successful!");

                                this.Hide();
                                LoginPage loginPage = new LoginPage();
                                loginPage.Show();
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

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {
            if (textPassword.TextLength < 8)
            {
                errorProviderPass.SetError(this.textPassword, "Minimum 8 Characters required");
            }
            else if (!Regex.IsMatch(textPassword.Text, pattern))
            {
                errorProviderPass.SetError(this.textPassword, "Password must include Uppercase, Lowercase, Number, Special Characters");
            }
            else
            {
                errorProviderPass.Clear();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
