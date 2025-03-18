namespace FoodWord
{
    partial class ForgetPasswword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelTimerShow = new System.Windows.Forms.Label();
            this.buttonChangepass = new System.Windows.Forms.Button();
            this.buttonOTPVerify = new System.Windows.Forms.Button();
            this.buttonEmailSend = new System.Windows.Forms.Button();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textBoxOTP = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelemail = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.errorProviderPass = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderConPass = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.buttonPassShowHide = new System.Windows.Forms.Button();
            this.buttonConPassShowHide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConPass)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTimerShow
            // 
            this.labelTimerShow.AutoSize = true;
            this.labelTimerShow.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerShow.Location = new System.Drawing.Point(164, 217);
            this.labelTimerShow.Name = "labelTimerShow";
            this.labelTimerShow.Size = new System.Drawing.Size(0, 15);
            this.labelTimerShow.TabIndex = 31;
            this.labelTimerShow.Visible = false;
            // 
            // buttonChangepass
            // 
            this.buttonChangepass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangepass.Location = new System.Drawing.Point(247, 363);
            this.buttonChangepass.Name = "buttonChangepass";
            this.buttonChangepass.Size = new System.Drawing.Size(168, 31);
            this.buttonChangepass.TabIndex = 30;
            this.buttonChangepass.Text = "Change Password";
            this.buttonChangepass.UseVisualStyleBackColor = true;
            this.buttonChangepass.Click += new System.EventHandler(this.buttonChangepass_Click);
            // 
            // buttonOTPVerify
            // 
            this.buttonOTPVerify.Enabled = false;
            this.buttonOTPVerify.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOTPVerify.Location = new System.Drawing.Point(352, 217);
            this.buttonOTPVerify.Name = "buttonOTPVerify";
            this.buttonOTPVerify.Size = new System.Drawing.Size(73, 30);
            this.buttonOTPVerify.TabIndex = 29;
            this.buttonOTPVerify.Text = "Verify";
            this.buttonOTPVerify.UseVisualStyleBackColor = true;
            this.buttonOTPVerify.Click += new System.EventHandler(this.buttonOTPVerify_Click);
            // 
            // buttonEmailSend
            // 
            this.buttonEmailSend.Enabled = false;
            this.buttonEmailSend.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEmailSend.Location = new System.Drawing.Point(352, 147);
            this.buttonEmailSend.Name = "buttonEmailSend";
            this.buttonEmailSend.Size = new System.Drawing.Size(73, 32);
            this.buttonEmailSend.TabIndex = 28;
            this.buttonEmailSend.Text = "Send";
            this.buttonEmailSend.UseVisualStyleBackColor = true;
            this.buttonEmailSend.Click += new System.EventHandler(this.buttonEmailSend_Click);
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Enabled = false;
            this.textBoxConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(192, 310);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '*';
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(233, 22);
            this.textBoxConfirmPassword.TabIndex = 27;
            this.textBoxConfirmPassword.TextChanged += new System.EventHandler(this.textBoxConfirmPassword_TextChanged);
            // 
            // textPassword
            // 
            this.textPassword.Enabled = false;
            this.textPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassword.Location = new System.Drawing.Point(192, 258);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(233, 22);
            this.textPassword.TabIndex = 26;
            this.textPassword.TextChanged += new System.EventHandler(this.textBoxNewPassword_TextChanged);
            // 
            // textBoxOTP
            // 
            this.textBoxOTP.Enabled = false;
            this.textBoxOTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOTP.Location = new System.Drawing.Point(167, 185);
            this.textBoxOTP.Name = "textBoxOTP";
            this.textBoxOTP.Size = new System.Drawing.Size(258, 22);
            this.textBoxOTP.TabIndex = 25;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(167, 115);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(258, 22);
            this.textBoxEmail.TabIndex = 24;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 188);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(91, 21);
            this.label4.TabIndex = 22;
            this.label4.Text = "Enter OTP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 21);
            this.label6.TabIndex = 21;
            this.label6.Text = "Confirm Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 21);
            this.label5.TabIndex = 20;
            this.label5.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "New Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 36);
            this.label1.TabIndex = 17;
            this.label1.Text = "Forget Password";
            // 
            // labelemail
            // 
            this.labelemail.AutoSize = true;
            this.labelemail.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelemail.Location = new System.Drawing.Point(164, 147);
            this.labelemail.Name = "labelemail";
            this.labelemail.Size = new System.Drawing.Size(0, 15);
            this.labelemail.TabIndex = 32;
            this.labelemail.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FoodWord.Properties.Resources.Screenshot_2024_04_17_213850;
            this.pictureBox1.Location = new System.Drawing.Point(313, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(88, 363);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(114, 30);
            this.buttonBack.TabIndex = 34;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // errorProviderPass
            // 
            this.errorProviderPass.ContainerControl = this;
            // 
            // errorProviderConPass
            // 
            this.errorProviderConPass.ContainerControl = this;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // buttonPassShowHide
            // 
            this.buttonPassShowHide.BackgroundImage = global::FoodWord.Properties.Resources.hidden_Eye;
            this.buttonPassShowHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPassShowHide.Location = new System.Drawing.Point(398, 258);
            this.buttonPassShowHide.Name = "buttonPassShowHide";
            this.buttonPassShowHide.Size = new System.Drawing.Size(27, 23);
            this.buttonPassShowHide.TabIndex = 35;
            this.buttonPassShowHide.UseVisualStyleBackColor = true;
            this.buttonPassShowHide.Click += new System.EventHandler(this.buttonPassShowHide_Click);
            // 
            // buttonConPassShowHide
            // 
            this.buttonConPassShowHide.BackgroundImage = global::FoodWord.Properties.Resources.hidden_Eye;
            this.buttonConPassShowHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonConPassShowHide.Location = new System.Drawing.Point(398, 310);
            this.buttonConPassShowHide.Name = "buttonConPassShowHide";
            this.buttonConPassShowHide.Size = new System.Drawing.Size(27, 23);
            this.buttonConPassShowHide.TabIndex = 36;
            this.buttonConPassShowHide.UseVisualStyleBackColor = true;
            this.buttonConPassShowHide.Click += new System.EventHandler(this.buttonConPassShowHide_Click);
            // 
            // ForgetPasswword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(197)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(460, 449);
            this.Controls.Add(this.buttonConPassShowHide);
            this.Controls.Add(this.buttonPassShowHide);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelemail);
            this.Controls.Add(this.labelTimerShow);
            this.Controls.Add(this.buttonChangepass);
            this.Controls.Add(this.buttonOTPVerify);
            this.Controls.Add(this.buttonEmailSend);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textBoxOTP);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ForgetPasswword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgetPasswword";
            this.Load += new System.EventHandler(this.ForgetPasswword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConPass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTimerShow;
        private System.Windows.Forms.Button buttonChangepass;
        private System.Windows.Forms.Button buttonOTPVerify;
        private System.Windows.Forms.Button buttonEmailSend;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textBoxOTP;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelemail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.ErrorProvider errorProviderPass;
        private System.Windows.Forms.ErrorProvider errorProviderConPass;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button buttonConPassShowHide;
        private System.Windows.Forms.Button buttonPassShowHide;
    }
}