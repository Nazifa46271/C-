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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;




namespace FoodWord
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        int count = 0;
        private void buttonPassShowHide_Click(object sender, EventArgs e)
        {
            if(textPassword.PasswordChar == '*')
            {
                textPassword.PasswordChar = '\0';
            }
            else if (textPassword.PasswordChar == '\0')
            {
                textPassword.PasswordChar = '*';
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username, userpassword;
            username = textUsername.Text;
            userpassword = textPassword.Text;

            count += count;
            if (count >= 3)
            {
                MessageBox.Show("\t \t System Is Block \t \t");
                Application.Exit();
            }
            if (username == "")
            {
                MessageBox.Show("\t\t Blank User Name \t\t");
            }
            else if (userpassword == "")
            {
                MessageBox.Show(" Blank Password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(username == "Admin" || userpassword == "Admin@123")
            {
                AdminPage adminPage = new AdminPage();
                adminPage.adminName = textUsername.Text;
                this.Hide();
                adminPage.Show();
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;");
                try
                {
                    con.Open(); // Open the connection
                    string query = "SELECT * FROM Registration_db WHERE email = @username AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", textUsername.Text);
                    cmd.Parameters.AddWithValue("@password", textPassword.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Login successful
                        username = textUsername.Text;
                        userpassword = textPassword.Text;

                        Homepage homepage = new Homepage();
                        this.Hide();
                        homepage.Show();
                        homepage.username = textUsername.Text;
                    }
                    else
                    {
                        // Invalid username or password
                        MessageBox.Show("Invalid Username & Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textUsername.Clear();
                        textPassword.Clear();
                        textUsername.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close(); // Close the connection in the finally block
                }
            }

        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.Show();
        }

        private void buttonForgetPass_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
