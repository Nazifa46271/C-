using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace FoodWord
{
    public partial class Homepage : Form
    {
        public string username { get; set; }
        public static string amount = "";

        public Homepage()
        {
            InitializeComponent();
            flowLayoutPanel1.Controls.Clear();
            labelUser.Text = username;
            LoadProducts();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
        }


        private void AddItems(string id, string name, string price, Image imagePath)
        {
            var w = new UserControl1()
            {
                id = Convert.ToInt32(id),
                PName = name,
                PPrice = price,
                PImae = imagePath

            };
           
            flowLayoutPanel1.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (UserControl1)ss;
                bool productExists = false;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells["SL"].Value) == wdg.id)
                    {
                        // Product already exists, update quantity and price
                        int quantity = int.Parse(item.Cells["Qty"].Value.ToString()) + 1;
                        item.Cells["Qty"].Value = quantity;
                        item.Cells["Amount"].Value = quantity * double.Parse(item.Cells["Price"].Value.ToString());
                        productExists = true;
                        break;
                    }
                }

                if (!productExists)
                {
                    // Product doesn't exist, add new row
                    dataGridView1.Rows.Add(new object[] {wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
                }

                GetTotal();
            };
        }
        public void LoadProducts()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                {
                    con.Open();

                    // Create SQL command
                    string query = "SELECT SL, foodName, price, imageLocation FROM Table_Food_List"; // Specify your table name here

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Execute the SQL command
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if there are rows returned
                            if (reader.HasRows)
                            {
                                // Loop through each row
                                while (reader.Read())
                                {
                                    // Retrieve data from the current row
                                    string SL = reader["SL"].ToString();
                                    string foodName = reader["foodName"].ToString();
                                    string price = reader["price"].ToString();

                                    // Retrieve the image data as byte array
                                    byte[] imageBytes = (byte[])reader["imageLocation"];

                                    // Convert byte array to image
                                    Image image;
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        image = Image.FromStream(ms);
                                    }

                                    // Call AddItems method to add the retrieved data
                                    AddItems(SL, foodName, price, image);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanel1.Controls)
            {
                var pro = (UserControl1)(item);
                pro.Visible = pro.PName.ToLower().Contains(textBox1.Text.ToLower());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            string no = textBoxTableNo.Text;
            if (no == "")
            {
                MessageBox.Show("Table No Missing.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTableNo.Focus();
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
                        string query = "INSERT INTO Oder_List (tableNo, foodName, quantity, price, amount) " +
                                       "VALUES (@TableNo, @FoodName, @Quantity, @Price, @Amount)";

                        // Use SqlCommandBuilder to dynamically create parameters
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            // Add parameters
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                // Check if the cell value is not null before accessing its properties
                                if (dataGridView1.Rows[i].Cells[1].Value != null &&
                                    dataGridView1.Rows[i].Cells[2].Value != null &&
                                    dataGridView1.Rows[i].Cells[3].Value != null &&
                                    dataGridView1.Rows[i].Cells[4].Value != null)
                                {
                                    cmd.Parameters.Clear(); // Clear parameters before adding new ones
                                    cmd.Parameters.AddWithValue("@TableNo", no); // Correct parameter name
                                    cmd.Parameters.AddWithValue("@FoodName", dataGridView1.Rows[i].Cells[1].Value.ToString());
                                    cmd.Parameters.AddWithValue("@Quantity", dataGridView1.Rows[i].Cells[2].Value.ToString());
                                    cmd.Parameters.AddWithValue("@Price", dataGridView1.Rows[i].Cells[3].Value.ToString());
                                    cmd.Parameters.AddWithValue("@Amount", dataGridView1.Rows[i].Cells[4].Value.ToString());

                                    // Execute the query inside the loop for each row
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected <= 0)
                                    {
                                        MessageBox.Show("Failed to insert data for row " + (i + 1));
                                    }
                                }
                                else
                                {
                                   // MessageBox.Show("Please check your order.");
                                    MessageBox.Show("Please check your order..", "Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                }
                            }

                        }

                        // Outside the loop, if all rows are successfully inserted
                        amount = labelAmount.Text;
                        // Payment payment = new Payment();
                        // payment.userName = labelUser.Text;
                        //payment.Show();
                        //this.Hide();
                        CustomerInput customerInput = new CustomerInput();
                        customerInput.Show();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void userControl13_onSelect(object sender, EventArgs e)
        {

        }

        private void buttonItemCancel_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);

            // Update the total after removing the row
            GetTotal();
        }

        private void GetTotal()
        {
            double total = 0;
            labelAmount.Text = "0.00";

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                // Check if the Amount cell value is not null and valid
                if (item.Cells["Amount"].Value != null && int.TryParse(item.Cells["Amount"].Value.ToString(), out int amount))
                {
                    total += amount;
                }
            }

            labelAmount.Text = total.ToString("0.00");
        }

        private void textBoxTableNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTableNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }

        }
    }
}
