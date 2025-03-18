using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodWord
{
    public partial class FoodList : Form
    {
        public FoodList()
        {
            InitializeComponent();
            FoodListDataset();
        }

        private void FoodListDataset()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                {
                    con.Open();

                    string query = "SELECT * FROM Table_Food_List";

                    using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;

                        // If you want to stretch the image in the DataGridView, you can set the ImageLayout property
                        if (dataGridView1.Columns.Contains("imageLocation"))
                        {
                            // Customize the display for the image column
                            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dataGridView1.Columns["imageLocation"];
                            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // or Stretch
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                {
                    con.Open();
                    SqlCommand mySqlCommand = new SqlCommand("UPDATE Table_Food_List SET foodName = @Food_Name, price = @Price WHERE SL = @SL", con);
                    mySqlCommand.Parameters.AddWithValue("@Food_Name", textBoxName.Text);
                    mySqlCommand.Parameters.AddWithValue("@Price", textBoxPrice.Text);
                    mySqlCommand.Parameters.AddWithValue("@SL", dataGridView1.SelectedRows[0].Cells["SL"].Value); // Assuming SL is the primary key
                    int rowsAffected = mySqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Update successful.");
                        // Resetting text boxes
                        textBoxName.Text = "";
                        textBoxPrice.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            FoodListDataset(); // Refresh data after update
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                {
                    con.Open();
                    string slValue = dataGridView1.SelectedRows[0].Cells["SL"].Value.ToString(); // Assuming SL is the primary key
                    string deleteQuery = "DELETE FROM Table_Food_List WHERE SL = @SL";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, con);
                    deleteCommand.Parameters.AddWithValue("@SL", slValue);
                    deleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Row deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            FoodListDataset(); // Refresh data after delete
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBoxName.Text = row.Cells[0].Value.ToString();
                textBoxPrice.Text = row.Cells[1].Value.ToString();
            }
        }

        private void textBoxPrice_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
