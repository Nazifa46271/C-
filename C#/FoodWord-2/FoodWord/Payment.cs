using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodWord
{
    public partial class Payment : Form
    {
        public string Amount { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string Method { get; set; }

        public Payment()
        {
            InitializeComponent();
            labelAm.Text = Homepage.amount;
            labelCostomer.Text = CustomerInput.UserName;
            labelNumber.Text = CustomerInput.UserPhone;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string amount = textBoxAmount.Text;
            
            if (string.IsNullOrEmpty(amount))
            {
                MessageBox.Show("Payment amount not entered.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (amount != labelAm.Text)
            {
                MessageBox.Show("Payment amount does not match.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxAmount.Text = "";
            }
            else
            {
                try
                {
                    //Method = "Cash"; // Corrected assignment
                    string userEmail = labelCostomer.Text;
                    string number = UserPhone;
                    string Amount = labelAm.Text;
                    string amountto = textBoxAmount.Text;
                    string PhoneNumber = labelNumber.Text;
                    if (amountto == null)
                    {
                        MessageBox.Show("amount not entered.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Method == null)
                    {
                        MessageBox.Show("Method not entered.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (userEmail == null)
                    {
                        MessageBox.Show("user not entered.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else if (PhoneNumber == null)
                    {
                        MessageBox.Show("number not entered.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        string connectionString = "Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;";
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();

                            // Create SQL command
                            string query = "INSERT INTO Table_Payment (email, phone, oder_Amount, Payment_Amount, method) " +
                                            "VALUES (@Email, @Phone, @order_Amount, @Payment_Amount, @Method)";

                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                // Add parameters
                                cmd.Parameters.AddWithValue("@Email", userEmail);
                                cmd.Parameters.AddWithValue("@Phone", PhoneNumber);
                                cmd.Parameters.AddWithValue("@order_Amount", Amount);
                                cmd.Parameters.AddWithValue("@Payment_Amount", amount);
                                cmd.Parameters.AddWithValue("@Method", Method);

                                // Execute the query
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Payment successful!");
                                    Homepage homepage = new Homepage();
                                    this.Hide();
                                    homepage.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Payment failed!");
                                }
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            this.Close();
            homepage.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Method = "Bkash";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Method = "Cash";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Method = "Card";
        }
    }
}
