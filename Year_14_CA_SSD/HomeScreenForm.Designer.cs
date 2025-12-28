
namespace Year_14_CA_SSD
{
    partial class HomeScreenForm
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
            this.Message_Label = new System.Windows.Forms.Label();
            this.Message_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Message_Label
            // 
            this.Message_Label.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message_Label.Location = new System.Drawing.Point(221, 292);
            this.Message_Label.Name = "Message_Label";
            this.Message_Label.Size = new System.Drawing.Size(742, 25);
            this.Message_Label.TabIndex = 8;
            this.Message_Label.Text = "You are not signed in, would you like to?";
            this.Message_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Message_Button
            // 
            this.Message_Button.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message_Button.Location = new System.Drawing.Point(533, 320);
            this.Message_Button.Name = "Message_Button";
            this.Message_Button.Size = new System.Drawing.Size(120, 39);
            this.Message_Button.TabIndex = 9;
            this.Message_Button.Text = "Sign In";
            this.Message_Button.UseVisualStyleBackColor = true;
            this.Message_Button.Click += new System.EventHandler(this.Sign_In_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Year_14_CA_SSD.Properties.Resources.doherty_cars;
            this.pictureBox1.Location = new System.Drawing.Point(416, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(353, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // HomeScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 596);
            this.Controls.Add(this.Message_Label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Message_Button);
            this.Name = "HomeScreenForm";
            this.Text = "HomeScreenForm";
            this.Load += new System.EventHandler(this.HomeScreenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Message_Label;
        private System.Windows.Forms.Button Message_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}