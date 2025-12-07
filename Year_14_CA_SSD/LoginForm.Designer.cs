
namespace Year_14_CA_SSD
{
    partial class LoginForm
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
            this.Username_TextBox = new System.Windows.Forms.TextBox();
            this.Password_TextBox = new System.Windows.Forms.TextBox();
            this.Username_Label = new System.Windows.Forms.Label();
            this.Password_Label = new System.Windows.Forms.Label();
            this.Login_Button = new System.Windows.Forms.Button();
            this.Show_Password_Button = new System.Windows.Forms.PictureBox();
            this.Logo_PictureBox = new System.Windows.Forms.PictureBox();
            this.Forgotten_Password_Button = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Show_Password_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Username_TextBox
            // 
            this.Username_TextBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_TextBox.Location = new System.Drawing.Point(386, 295);
            this.Username_TextBox.Name = "Username_TextBox";
            this.Username_TextBox.Size = new System.Drawing.Size(532, 39);
            this.Username_TextBox.TabIndex = 1;
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_TextBox.Location = new System.Drawing.Point(386, 372);
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.Size = new System.Drawing.Size(532, 39);
            this.Password_TextBox.TabIndex = 2;
            this.Password_TextBox.UseSystemPasswordChar = true;
            // 
            // Username_Label
            // 
            this.Username_Label.AutoSize = true;
            this.Username_Label.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_Label.Location = new System.Drawing.Point(258, 298);
            this.Username_Label.Name = "Username_Label";
            this.Username_Label.Size = new System.Drawing.Size(122, 32);
            this.Username_Label.TabIndex = 4;
            this.Username_Label.Text = "Username";
            // 
            // Password_Label
            // 
            this.Password_Label.AutoSize = true;
            this.Password_Label.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Label.Location = new System.Drawing.Point(268, 375);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(112, 32);
            this.Password_Label.TabIndex = 5;
            this.Password_Label.Text = "Password";
            // 
            // Login_Button
            // 
            this.Login_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Button.Location = new System.Drawing.Point(512, 478);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(162, 72);
            this.Login_Button.TabIndex = 6;
            this.Login_Button.Text = "Login";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // Show_Password_Button
            // 
            this.Show_Password_Button.BackColor = System.Drawing.Color.White;
            this.Show_Password_Button.Image = global::Year_14_CA_SSD.Properties.Resources.show_password;
            this.Show_Password_Button.Location = new System.Drawing.Point(878, 374);
            this.Show_Password_Button.Name = "Show_Password_Button";
            this.Show_Password_Button.Size = new System.Drawing.Size(38, 34);
            this.Show_Password_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Show_Password_Button.TabIndex = 7;
            this.Show_Password_Button.TabStop = false;
            this.Show_Password_Button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Show_Password_Button_MouseDown);
            this.Show_Password_Button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Show_Password_Button_MouseUp);
            // 
            // Logo_PictureBox
            // 
            this.Logo_PictureBox.Image = global::Year_14_CA_SSD.Properties.Resources.doherty_cars;
            this.Logo_PictureBox.Location = new System.Drawing.Point(416, 40);
            this.Logo_PictureBox.Name = "Logo_PictureBox";
            this.Logo_PictureBox.Size = new System.Drawing.Size(353, 277);
            this.Logo_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo_PictureBox.TabIndex = 11;
            this.Logo_PictureBox.TabStop = false;
            // 
            // Forgotten_Password_Button
            // 
            this.Forgotten_Password_Button.AutoSize = true;
            this.Forgotten_Password_Button.BackColor = System.Drawing.SystemColors.Control;
            this.Forgotten_Password_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Forgotten_Password_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Forgotten_Password_Button.ForeColor = System.Drawing.Color.SteelBlue;
            this.Forgotten_Password_Button.Location = new System.Drawing.Point(779, 414);
            this.Forgotten_Password_Button.Name = "Forgotten_Password_Button";
            this.Forgotten_Password_Button.Size = new System.Drawing.Size(145, 20);
            this.Forgotten_Password_Button.TabIndex = 12;
            this.Forgotten_Password_Button.Text = "Forgotten Password";
            this.Forgotten_Password_Button.Click += new System.EventHandler(this.Forgotten_Password_Button_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 596);
            this.Controls.Add(this.Forgotten_Password_Button);
            this.Controls.Add(this.Username_TextBox);
            this.Controls.Add(this.Logo_PictureBox);
            this.Controls.Add(this.Show_Password_Button);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.Password_Label);
            this.Controls.Add(this.Username_Label);
            this.Controls.Add(this.Password_TextBox);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.Show_Password_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Username_TextBox;
        private System.Windows.Forms.TextBox Password_TextBox;
        private System.Windows.Forms.Label Username_Label;
        private System.Windows.Forms.Label Password_Label;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.PictureBox Show_Password_Button;
        private System.Windows.Forms.PictureBox Logo_PictureBox;
        private System.Windows.Forms.Label Forgotten_Password_Button;
    }
}