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
    
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public event EventHandler onSelect = null;
        public int id
        {
            get { return int.Parse(labelId.Text); }
            set { labelId.Text = value.ToString(); }
        }

        public string PPrice
        {
            get {return labelPrice.Text;} 
            set {labelPrice.Text = value;} 
        }

        public string PCategory { set; get; }

        public string PName
        {
            get { return labelName.Text; }
            set { labelName.Text = value; }
        }

        public Image PImae
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public static Action<object, object> OnSelect { get; internal set; }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void UserControl1_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Orange;
        }

        private void UserControl1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }
    }
        
 }

