using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodWord
{
    public partial class AddFood : Form
    {
        public AddFood()
        {
            InitializeComponent();
        }
        string imageLocation;
       
        private void buttonPicUplode_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "All Files (*.*)|*.*|JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if ( textBoxFoodName.Text == "" || textBoxPrice.Text == "")
            {
                MessageBox.Show("         Missing Information    ");
            }
            else
            {
                string Food,Price;

                Food = textBoxFoodName.Text;
                Price = textBoxPrice.Text;

                try
                {
                    // Establish connection
                    using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JB5122C;Initial Catalog=FoodHub;Persist Security Info=True;User ID=sa;Password=Jahid@1217;"))
                    {
                        con.Open();

                        // Begin transaction
                        SqlTransaction transaction = con.BeginTransaction();

                        try
                        {
                            // Create SQL command
                            string query = "INSERT INTO Table_Food_List (foodName, price, imageLocation) " +
                                           "VALUES (@Food_Name, @Price, @imageLocation)";
                            using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                            {
                                // Set parameters
                                cmd.Parameters.AddWithValue("@Food_Name", Food);
                                cmd.Parameters.AddWithValue("@Price", Price);

                                MemoryStream memory = new MemoryStream();
                                pictureBox1.Image.Save(memory,pictureBox1.Image.RawFormat);

                                cmd.Parameters.AddWithValue("@imageLocation", memory.ToArray());

                                // Execute query
                                cmd.ExecuteNonQuery();

                                // Commit transaction
                                transaction.Commit();

                                // Show success message
                                MessageBox.Show("Record Added Successfully");

                                // Clear text boxes
                                textBoxFoodName.Clear();
                                textBoxPrice.Clear();
                                pictureBox1.Image = null;

                            }
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction on exception
                            transaction.Rollback();
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle connection exception
                    MessageBox.Show("Connection Error: " + ex.Message);
                }


            }
        }

        private void buttonReseat_Click(object sender, EventArgs e)
        {
            textBoxFoodName.Clear();
            textBoxPrice.Clear();
            pictureBox1.Image = null;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Hide();
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
