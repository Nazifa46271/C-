using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodWord
{
    public partial class AdminPage : Form
    {
        public string adminName {  get; set; }
        public AdminPage()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            this.Hide();
            loginPage.Show();
        }

        private void buttonFoodAdd_Click(object sender, EventArgs e)
        {
            AddFood addFood = new AddFood();
            this.Hide();
            addFood.ShowDialog();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            FoodList foodList = new FoodList();
            this.Hide();
            foodList.ShowDialog();
        }

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer(); 
            this.Hide();
            customer.ShowDialog();
        }

        private void buttonOrderList_Click(object sender, EventArgs e)
        {
            PaymentList paymentList = new PaymentList();
            this.Hide();
            paymentList.ShowDialog();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {

        }
    }
}
