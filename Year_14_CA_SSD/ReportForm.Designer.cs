
namespace Year_14_CA_SSD
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnectionCustomer = new System.Data.SqlClient.SqlConnection();
            this.sqlDataAdapterCustomer = new System.Data.SqlClient.SqlDataAdapter();
            this.dsTestDriveCustomer = new Year_14_CA_SSD.dsTestDriveBookings();
            this.Customer_TextBox = new System.Windows.Forms.ComboBox();
            this.View_Report_Button = new System.Windows.Forms.Button();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnectionTimes = new System.Data.SqlClient.SqlConnection();
            this.sqlDataAdapterTimes = new System.Data.SqlClient.SqlDataAdapter();
            this.dsTestDriveTimes = new Year_14_CA_SSD.dsTestDriveTimes();
            this.Time_RadioButton = new System.Windows.Forms.RadioButton();
            this.Customer_RadioButton = new System.Windows.Forms.RadioButton();
            this.Customer_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsTestDriveCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTestDriveTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReuseParameterValuesOnRefresh = true;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1175, 583);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.TabStop = false;
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnectionCustomer;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@CustId", System.Data.SqlDbType.Int, 4, "CustomerId")});
            // 
            // sqlConnectionCustomer
            // 
            this.sqlConnectionCustomer.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MyDatabase.md" +
    "f;Integrated Security=True";
            this.sqlConnectionCustomer.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlDataAdapterCustomer
            // 
            this.sqlDataAdapterCustomer.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapterCustomer.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "CarTable", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CustomerId", "CustomerId"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("PhoneNumber", "PhoneNumber"),
                        new System.Data.Common.DataColumnMapping("EmailAddress", "EmailAddress"),
                        new System.Data.Common.DataColumnMapping("StartTime", "StartTime"),
                        new System.Data.Common.DataColumnMapping("EndTime", "EndTime"),
                        new System.Data.Common.DataColumnMapping("Make", "Make"),
                        new System.Data.Common.DataColumnMapping("Model", "Model"),
                        new System.Data.Common.DataColumnMapping("Registration", "Registration"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("Amount", "Amount"),
                        new System.Data.Common.DataColumnMapping("IsCanceled", "IsCanceled")})});
            // 
            // dsTestDriveCustomer
            // 
            this.dsTestDriveCustomer.DataSetName = "dsTestDriveBookings";
            this.dsTestDriveCustomer.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Customer_TextBox
            // 
            this.Customer_TextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer_TextBox.FormattingEnabled = true;
            this.Customer_TextBox.Location = new System.Drawing.Point(12, 59);
            this.Customer_TextBox.Name = "Customer_TextBox";
            this.Customer_TextBox.Size = new System.Drawing.Size(182, 29);
            this.Customer_TextBox.TabIndex = 2;
            this.Customer_TextBox.Click += new System.EventHandler(this.Customer_TextBox_Click);
            this.Customer_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Customer_TextBox_KeyDown);
            // 
            // View_Report_Button
            // 
            this.View_Report_Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View_Report_Button.Location = new System.Drawing.Point(11, 501);
            this.View_Report_Button.Name = "View_Report_Button";
            this.View_Report_Button.Size = new System.Drawing.Size(180, 52);
            this.View_Report_Button.TabIndex = 5;
            this.View_Report_Button.Text = "View Report";
            this.View_Report_Button.UseVisualStyleBackColor = true;
            this.View_Report_Button.Click += new System.EventHandler(this.View_Report_Button_Click);
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = resources.GetString("sqlSelectCommand2.CommandText");
            this.sqlSelectCommand2.Connection = this.sqlConnectionTimes;
            // 
            // sqlConnectionTimes
            // 
            this.sqlConnectionTimes.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MyDatabase.md" +
    "f;Integrated Security=True";
            this.sqlConnectionTimes.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlDataAdapterTimes
            // 
            this.sqlDataAdapterTimes.SelectCommand = this.sqlSelectCommand2;
            this.sqlDataAdapterTimes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "CarTable", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CustomerId", "CustomerId"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("PhoneNumber", "PhoneNumber"),
                        new System.Data.Common.DataColumnMapping("EmailAddress", "EmailAddress"),
                        new System.Data.Common.DataColumnMapping("StartTime", "StartTime"),
                        new System.Data.Common.DataColumnMapping("EndTime", "EndTime"),
                        new System.Data.Common.DataColumnMapping("Make", "Make"),
                        new System.Data.Common.DataColumnMapping("Model", "Model"),
                        new System.Data.Common.DataColumnMapping("Registration", "Registration"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("Amount", "Amount"),
                        new System.Data.Common.DataColumnMapping("IsCanceled", "IsCanceled")})});
            // 
            // dsTestDriveTimes
            // 
            this.dsTestDriveTimes.DataSetName = "dsTestDriveTimes";
            this.dsTestDriveTimes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Time_RadioButton
            // 
            this.Time_RadioButton.AutoSize = true;
            this.Time_RadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_RadioButton.Location = new System.Drawing.Point(12, 470);
            this.Time_RadioButton.Name = "Time_RadioButton";
            this.Time_RadioButton.Size = new System.Drawing.Size(158, 25);
            this.Time_RadioButton.TabIndex = 4;
            this.Time_RadioButton.TabStop = true;
            this.Time_RadioButton.Text = "Time Select Report";
            this.Time_RadioButton.UseVisualStyleBackColor = true;
            this.Time_RadioButton.CheckedChanged += new System.EventHandler(this.Time_RadioButton_CheckedChanged);
            // 
            // Customer_RadioButton
            // 
            this.Customer_RadioButton.AutoSize = true;
            this.Customer_RadioButton.Checked = true;
            this.Customer_RadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer_RadioButton.Location = new System.Drawing.Point(12, 439);
            this.Customer_RadioButton.Name = "Customer_RadioButton";
            this.Customer_RadioButton.Size = new System.Drawing.Size(147, 25);
            this.Customer_RadioButton.TabIndex = 3;
            this.Customer_RadioButton.TabStop = true;
            this.Customer_RadioButton.Text = "Customer Report";
            this.Customer_RadioButton.UseVisualStyleBackColor = true;
            this.Customer_RadioButton.CheckedChanged += new System.EventHandler(this.Customer_RadioButton_CheckedChanged);
            // 
            // Customer_Label
            // 
            this.Customer_Label.AutoSize = true;
            this.Customer_Label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Customer_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer_Label.Location = new System.Drawing.Point(13, 35);
            this.Customer_Label.Name = "Customer_Label";
            this.Customer_Label.Size = new System.Drawing.Size(81, 21);
            this.Customer_Label.TabIndex = 6;
            this.Customer_Label.Text = "Customer:";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 583);
            this.Controls.Add(this.Customer_Label);
            this.Controls.Add(this.Customer_RadioButton);
            this.Controls.Add(this.Time_RadioButton);
            this.Controls.Add(this.View_Report_Button);
            this.Controls.Add(this.Customer_TextBox);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            ((System.ComponentModel.ISupportInitialize)(this.dsTestDriveCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTestDriveTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnectionCustomer;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapterCustomer;
        private dsTestDriveBookings dsTestDriveCustomer;
        private System.Windows.Forms.ComboBox Customer_TextBox;
        private System.Windows.Forms.Button View_Report_Button;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private System.Data.SqlClient.SqlConnection sqlConnectionTimes;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapterTimes;
        private dsTestDriveTimes dsTestDriveTimes;
        private System.Windows.Forms.RadioButton Time_RadioButton;
        private System.Windows.Forms.RadioButton Customer_RadioButton;
        private System.Windows.Forms.Label Customer_Label;
    }
}