
namespace Year_14_CA_SSD
{
    partial class PickerForm
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
            this.Table_ListView = new System.Windows.Forms.ListView();
            this.Search_TextBox = new System.Windows.Forms.TextBox();
            this.Continue_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Sorting_Label = new System.Windows.Forms.Label();
            this.Change_Column_Button = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Change_Column_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // Table_ListView
            // 
            this.Table_ListView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Table_ListView.FullRowSelect = true;
            this.Table_ListView.HideSelection = false;
            this.Table_ListView.Location = new System.Drawing.Point(7, 4);
            this.Table_ListView.Name = "Table_ListView";
            this.Table_ListView.ShowItemToolTips = true;
            this.Table_ListView.Size = new System.Drawing.Size(371, 209);
            this.Table_ListView.TabIndex = 0;
            this.Table_ListView.UseCompatibleStateImageBehavior = false;
            this.Table_ListView.View = System.Windows.Forms.View.Details;
            this.Table_ListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Table_ListView_KeyDown);
            // 
            // Search_TextBox
            // 
            this.Search_TextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_TextBox.Location = new System.Drawing.Point(93, 219);
            this.Search_TextBox.Name = "Search_TextBox";
            this.Search_TextBox.Size = new System.Drawing.Size(284, 33);
            this.Search_TextBox.TabIndex = 1;
            this.Search_TextBox.TextChanged += new System.EventHandler(this.Search_TextBox_TextChanged);
            // 
            // Continue_Button
            // 
            this.Continue_Button.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Continue_Button.Location = new System.Drawing.Point(5, 258);
            this.Continue_Button.Name = "Continue_Button";
            this.Continue_Button.Size = new System.Drawing.Size(200, 40);
            this.Continue_Button.TabIndex = 3;
            this.Continue_Button.Text = "Continue";
            this.Continue_Button.UseVisualStyleBackColor = true;
            this.Continue_Button.Click += new System.EventHandler(this.Continue_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_Button.Location = new System.Drawing.Point(211, 258);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(167, 40);
            this.Cancel_Button.TabIndex = 4;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Sorting_Label
            // 
            this.Sorting_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sorting_Label.Location = new System.Drawing.Point(2, 219);
            this.Sorting_Label.Name = "Sorting_Label";
            this.Sorting_Label.Size = new System.Drawing.Size(43, 32);
            this.Sorting_Label.TabIndex = 5;
            this.Sorting_Label.Text = "DOB";
            this.Sorting_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Change_Column_Button
            // 
            this.Change_Column_Button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Change_Column_Button.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Change_Column_Button.Image = global::Year_14_CA_SSD.Properties.Resources.arrow1;
            this.Change_Column_Button.Location = new System.Drawing.Point(47, 220);
            this.Change_Column_Button.Name = "Change_Column_Button";
            this.Change_Column_Button.Size = new System.Drawing.Size(39, 32);
            this.Change_Column_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Change_Column_Button.TabIndex = 6;
            this.Change_Column_Button.TabStop = false;
            this.Change_Column_Button.Click += new System.EventHandler(this.Change_Column_Button_Click);
            // 
            // PickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 306);
            this.Controls.Add(this.Change_Column_Button);
            this.Controls.Add(this.Search_TextBox);
            this.Controls.Add(this.Sorting_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Continue_Button);
            this.Controls.Add(this.Table_ListView);
            this.Name = "PickerForm";
            this.Text = "Picker Form";
            this.Load += new System.EventHandler(this.PickerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Change_Column_Button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Table_ListView;
        private System.Windows.Forms.TextBox Search_TextBox;
        private System.Windows.Forms.Button Continue_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Label Sorting_Label;
        private System.Windows.Forms.PictureBox Change_Column_Button;
    }
}