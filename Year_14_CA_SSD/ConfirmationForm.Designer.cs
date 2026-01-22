
namespace Year_14_CA_SSD
{
    partial class ConfirmationForm
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
            this.Text_Label = new System.Windows.Forms.Label();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Confirm_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Text_Label
            // 
            this.Text_Label.AutoSize = true;
            this.Text_Label.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_Label.Location = new System.Drawing.Point(3, 3);
            this.Text_Label.Name = "Text_Label";
            this.Text_Label.Size = new System.Drawing.Size(369, 75);
            this.Text_Label.TabIndex = 0;
            this.Text_Label.Text = "Warning: Archiving is a permanent action, \r\nIt cannot be undone\r\nOnly continue if" +
    " you are certain";
            this.Text_Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_Button.Location = new System.Drawing.Point(178, 81);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(185, 46);
            this.Cancel_Button.TabIndex = 2;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Confirm_Button
            // 
            this.Confirm_Button.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirm_Button.Location = new System.Drawing.Point(-3, 81);
            this.Confirm_Button.Name = "Confirm_Button";
            this.Confirm_Button.Size = new System.Drawing.Size(185, 46);
            this.Confirm_Button.TabIndex = 1;
            this.Confirm_Button.Text = "Confirm";
            this.Confirm_Button.UseVisualStyleBackColor = true;
            this.Confirm_Button.Click += new System.EventHandler(this.Confirm_Button_Click);
            // 
            // ConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 123);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Confirm_Button);
            this.Controls.Add(this.Text_Label);
            this.Name = "ConfirmationForm";
            this.Text = "Are you sure?";
            this.Load += new System.EventHandler(this.ConfirmationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Text_Label;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Confirm_Button;
    }
}