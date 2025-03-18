using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FoodWord
{
    public partial class ForgetPasswword : Form
    {
        public ForgetPasswword()
        {
            InitializeComponent();
        }
        string pattern = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";
        int OTPCode = 1000;
        private DateTime otpCreationTime;
        private TimeSpan otpValidityDuration = TimeSpan.FromMinutes(1);

        MySqlConnection con = new MySqlConnection("server = 127.0.0.1; database = foodhub; username = root; password= Admin@1234; ");

        private void textBoxNewPassword_TextChanged(object sender, EventArgs e)
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

        private void CheckOTPExpiration()
        {
            TimeSpan elapsedTime = DateTime.Now - otpCreationTime;
            TimeSpan remainingTime = otpValidityDuration - elapsedTime;

            // Check if more than 5 minutes have passed since OTP creation
            if (elapsedTime.TotalMinutes >= 1)
            {
                timer2.Stop();
                MessageBox.Show("OTP Code has expired!\n\n OPT Resent !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Handle expiration, e.g., disable verification button, show message, etc.
                textBoxOTP.Enabled = false;
                buttonOTPVerify.Enabled = false;
                labelTimerShow.Visible = false;
            }
            // labelTimerShow.Text = $"{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}";
            labelTimerShow.Text = $"Resent OPT - {remainingTime.Minutes:00}:{remainingTime.Seconds:00}";

            if (remainingTime.TotalSeconds <= 30)
            {
                labelTimerShow.ForeColor = Color.Red;
            }
            else
            {
                labelTimerShow.ForeColor = Color.Black; // Reset color to default
            }

        }

        private void textBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (textPassword.Text == textBoxConfirmPassword.Text)
            {

            }
            else
            {
                errorProviderConPass.SetError(this.textBoxConfirmPassword, "Not Matched ! ");
            }
        }

        private void buttonChangepass_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text; // Use lower case for variable names to follow conventions
            con.Open();
            MySqlCommand mySqlCommand = new MySqlCommand("UPDATE foodlist SET password = @password WHERE email = @Email", con);
            mySqlCommand.Parameters.AddWithValue("@password", textPassword.Text);
            mySqlCommand.Parameters.AddWithValue("@Email", email); // Use the correct parameter name
            mySqlCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update successful.");

            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();

        }

        private void buttonEmailSend_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            string to, from, pass, mail;
            from = "jahid.hasan1217@gmail.com";
            to = textBoxEmail.Text;
            mail = OTPCode.ToString();
            pass = "vttd muwi krce shdk"; // Provide the actual password for the 'from' email account

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(to);
            mailMessage.From = new MailAddress(from);
            mailMessage.Subject = "Your OTP Code";
            mailMessage.Body = "Your OTP Code is: " + mail; // Include the OTP code in the email body

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtpClient.Send(mailMessage);
                MessageBox.Show("OTP Code sent successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxOTP.Enabled = true;
                buttonOTPVerify.Enabled = true;
                labelTimerShow.Visible = true;
                otpCreationTime = DateTime.Now;
                timer2.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonOTPVerify_Click(object sender, EventArgs e)
        {
            if (textBoxOTP.Text == OTPCode.ToString())
            {
                MessageBox.Show("Verify\n\nEnter new Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textPassword.Enabled = true;
                textBoxConfirmPassword.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            CheckOTPExpiration();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OTPCode += 10;
            if (OTPCode == 9999)
            {
                OTPCode = 1000;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            this.Hide();
            loginPage.Show();
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

        private void buttonConPassShowHide_Click(object sender, EventArgs e)
        {
            if (textBoxConfirmPassword.PasswordChar == '*')
            {
                textBoxConfirmPassword.PasswordChar = '\0';
            }
            else if (textBoxConfirmPassword.PasswordChar == '\0')
            {
                textBoxConfirmPassword.PasswordChar = '*';
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            searchEmail(textBoxEmail.Text);
        }

        public void searchEmail(string valueToFind)
        {
            string query = "SELECT email FROM registration WHERE email LIKE '%" + valueToFind + "%'";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            mySqlDataAdapter.Fill(dt);

            if (dt.Rows.Count > 0) // Check if there are any rows in the DataTable
            {
                buttonEmailSend.Enabled = true;
                labelemail.Text = ""; // Reset the label if a valid email is found
            }
            else
            {
                buttonEmailSend.Enabled = false;
                labelemail.Text = "Invalid Email";
            }
        }

        private void ForgetPasswword_Load(object sender, EventArgs e)
        {

        }
    }
}
