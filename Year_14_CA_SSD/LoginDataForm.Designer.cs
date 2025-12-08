
namespace Year_14_CA_SSD
{
    partial class LoginDataForm
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
            this.Sign_Out_Button = new System.Windows.Forms.Button();
            this.Username_Label = new System.Windows.Forms.Label();
            this.Username_Value_Label = new System.Windows.Forms.Label();
            this.Manager_Settings_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sign_Out_Button
            // 
            this.Sign_Out_Button.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sign_Out_Button.Location = new System.Drawing.Point(1009, 510);
            this.Sign_Out_Button.Name = "Sign_Out_Button";
            this.Sign_Out_Button.Size = new System.Drawing.Size(166, 74);
            this.Sign_Out_Button.TabIndex = 0;
            this.Sign_Out_Button.Text = "Sign Out";
            this.Sign_Out_Button.UseVisualStyleBackColor = true;
            this.Sign_Out_Button.Click += new System.EventHandler(this.Sign_Out_Button_Click);
            // 
            // Username_Label
            // 
            this.Username_Label.AutoSize = true;
            this.Username_Label.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_Label.Location = new System.Drawing.Point(87, 61);
            this.Username_Label.Name = "Username_Label";
            this.Username_Label.Size = new System.Drawing.Size(106, 30);
            this.Username_Label.TabIndex = 1;
            this.Username_Label.Text = "Username";
            // 
            // Username_Value_Label
            // 
            this.Username_Value_Label.AutoSize = true;
            this.Username_Value_Label.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_Value_Label.Location = new System.Drawing.Point(87, 91);
            this.Username_Value_Label.Name = "Username_Value_Label";
            this.Username_Value_Label.Size = new System.Drawing.Size(143, 30);
            this.Username_Value_Label.TabIndex = 2;
            this.Username_Value_Label.Text = "NAMCGEE782";
            // 
            // Manager_Settings_Button
            // 
            this.Manager_Settings_Button.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manager_Settings_Button.Location = new System.Drawing.Point(828, 510);
            this.Manager_Settings_Button.Name = "Manager_Settings_Button";
            this.Manager_Settings_Button.Size = new System.Drawing.Size(166, 74);
            this.Manager_Settings_Button.TabIndex = 3;
            this.Manager_Settings_Button.Text = "Manager Settings";
            this.Manager_Settings_Button.UseVisualStyleBackColor = true;
            this.Manager_Settings_Button.Click += new System.EventHandler(this.Manager_Settings_Button_Click);
            // 
            // LoginDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 596);
            this.Controls.Add(this.Manager_Settings_Button);
            this.Controls.Add(this.Username_Value_Label);
            this.Controls.Add(this.Username_Label);
            this.Controls.Add(this.Sign_Out_Button);
            this.Name = "LoginDataForm";
            this.Text = "LoginDataForm";
            this.Load += new System.EventHandler(this.LoginDataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Sign_Out_Button;
        private System.Windows.Forms.Label Username_Label;
        private System.Windows.Forms.Label Username_Value_Label;
        private System.Windows.Forms.Button Manager_Settings_Button;
    }
}