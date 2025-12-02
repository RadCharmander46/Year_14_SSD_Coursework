
namespace Year_14_CA_SSD
{
    partial class PaymentDataForm
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
            this.Payments_ListView = new System.Windows.Forms.ListView();
            this.Customer_GroupBox = new System.Windows.Forms.GroupBox();
            this.Cust_Postcode_Label = new System.Windows.Forms.Label();
            this.Cust_Email_Label = new System.Windows.Forms.Label();
            this.Cust_DOB_Label = new System.Windows.Forms.Label();
            this.Cust_Tel_Label = new System.Windows.Forms.Label();
            this.Payment_Label = new System.Windows.Forms.GroupBox();
            this.Description_Text_Label = new System.Windows.Forms.Label();
            this.Description_Label = new System.Windows.Forms.Label();
            this.Cancelled_Label = new System.Windows.Forms.Label();
            this.Paid_Label = new System.Windows.Forms.Label();
            this.Transaction_Type_Label = new System.Windows.Forms.Label();
            this.Transaction_Time_Label = new System.Windows.Forms.Label();
            this.Amount_Label = new System.Windows.Forms.Label();
            this.Verified_Label = new System.Windows.Forms.Label();
            this.Cust_Expiry_Label = new System.Windows.Forms.Label();
            this.Cust_Issue_Label = new System.Windows.Forms.Label();
            this.Cust_LicenseNo_Label = new System.Windows.Forms.Label();
            this.PrevCust_Label = new System.Windows.Forms.Label();
            this.Filter_ComboBox = new System.Windows.Forms.ComboBox();
            this.Filter_TextBox = new System.Windows.Forms.TextBox();
            this.Mark_Paid_Button = new System.Windows.Forms.PictureBox();
            this.Show_Cancelled_Button = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Sort_Amount = new System.Windows.Forms.PictureBox();
            this.Sort_Transaction_Type = new System.Windows.Forms.PictureBox();
            this.Sort_Transaction_Time = new System.Windows.Forms.PictureBox();
            this.Sort_Customer = new System.Windows.Forms.PictureBox();
            this.Search_Button = new System.Windows.Forms.PictureBox();
            this.Refresh_Button = new System.Windows.Forms.PictureBox();
            this.Customer_GroupBox.SuspendLayout();
            this.Payment_Label.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mark_Paid_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Show_Cancelled_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sort_Amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sort_Transaction_Type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sort_Transaction_Time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sort_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // Payments_ListView
            // 
            this.Payments_ListView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Payments_ListView.FullRowSelect = true;
            this.Payments_ListView.HideSelection = false;
            this.Payments_ListView.Location = new System.Drawing.Point(12, 12);
            this.Payments_ListView.Name = "Payments_ListView";
            this.Payments_ListView.Scrollable = false;
            this.Payments_ListView.Size = new System.Drawing.Size(784, 499);
            this.Payments_ListView.TabIndex = 2;
            this.Payments_ListView.UseCompatibleStateImageBehavior = false;
            this.Payments_ListView.View = System.Windows.Forms.View.Details;
            this.Payments_ListView.SelectedIndexChanged += new System.EventHandler(this.Payments_ListView_SelectedIndexChanged);
            // 
            // Customer_GroupBox
            // 
            this.Customer_GroupBox.Controls.Add(this.Verified_Label);
            this.Customer_GroupBox.Controls.Add(this.Cust_Postcode_Label);
            this.Customer_GroupBox.Controls.Add(this.Cust_Expiry_Label);
            this.Customer_GroupBox.Controls.Add(this.Cust_Email_Label);
            this.Customer_GroupBox.Controls.Add(this.Cust_Issue_Label);
            this.Customer_GroupBox.Controls.Add(this.Cust_DOB_Label);
            this.Customer_GroupBox.Controls.Add(this.Cust_LicenseNo_Label);
            this.Customer_GroupBox.Controls.Add(this.Cust_Tel_Label);
            this.Customer_GroupBox.Controls.Add(this.PrevCust_Label);
            this.Customer_GroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer_GroupBox.Location = new System.Drawing.Point(871, 12);
            this.Customer_GroupBox.Name = "Customer_GroupBox";
            this.Customer_GroupBox.Size = new System.Drawing.Size(294, 228);
            this.Customer_GroupBox.TabIndex = 49;
            this.Customer_GroupBox.TabStop = false;
            this.Customer_GroupBox.Text = "Customer";
            // 
            // Cust_Postcode_Label
            // 
            this.Cust_Postcode_Label.AutoSize = true;
            this.Cust_Postcode_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cust_Postcode_Label.Location = new System.Drawing.Point(6, 83);
            this.Cust_Postcode_Label.Name = "Cust_Postcode_Label";
            this.Cust_Postcode_Label.Size = new System.Drawing.Size(150, 21);
            this.Cust_Postcode_Label.TabIndex = 3;
            this.Cust_Postcode_Label.Text = "Postcode: BT78 1AW";
            // 
            // Cust_Email_Label
            // 
            this.Cust_Email_Label.AutoSize = true;
            this.Cust_Email_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cust_Email_Label.Location = new System.Drawing.Point(6, 62);
            this.Cust_Email_Label.Name = "Cust_Email_Label";
            this.Cust_Email_Label.Size = new System.Drawing.Size(239, 21);
            this.Cust_Email_Label.TabIndex = 2;
            this.Cust_Email_Label.Text = "Email: Nathanmcgee@gmail.com";
            // 
            // Cust_DOB_Label
            // 
            this.Cust_DOB_Label.AutoSize = true;
            this.Cust_DOB_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cust_DOB_Label.Location = new System.Drawing.Point(6, 20);
            this.Cust_DOB_Label.Name = "Cust_DOB_Label";
            this.Cust_DOB_Label.Size = new System.Drawing.Size(133, 21);
            this.Cust_DOB_Label.TabIndex = 1;
            this.Cust_DOB_Label.Text = "DOB: 26/03/2008";
            // 
            // Cust_Tel_Label
            // 
            this.Cust_Tel_Label.AutoSize = true;
            this.Cust_Tel_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cust_Tel_Label.Location = new System.Drawing.Point(6, 41);
            this.Cust_Tel_Label.Name = "Cust_Tel_Label";
            this.Cust_Tel_Label.Size = new System.Drawing.Size(125, 21);
            this.Cust_Tel_Label.TabIndex = 0;
            this.Cust_Tel_Label.Text = "Tel: 0965736467";
            // 
            // Payment_Label
            // 
            this.Payment_Label.Controls.Add(this.Description_Text_Label);
            this.Payment_Label.Controls.Add(this.Description_Label);
            this.Payment_Label.Controls.Add(this.Cancelled_Label);
            this.Payment_Label.Controls.Add(this.Paid_Label);
            this.Payment_Label.Controls.Add(this.Transaction_Type_Label);
            this.Payment_Label.Controls.Add(this.Transaction_Time_Label);
            this.Payment_Label.Controls.Add(this.Amount_Label);
            this.Payment_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Payment_Label.Location = new System.Drawing.Point(871, 246);
            this.Payment_Label.Name = "Payment_Label";
            this.Payment_Label.Size = new System.Drawing.Size(294, 205);
            this.Payment_Label.TabIndex = 50;
            this.Payment_Label.TabStop = false;
            this.Payment_Label.Text = "Payment";
            this.Payment_Label.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Description_Text_Label
            // 
            this.Description_Text_Label.AutoSize = true;
            this.Description_Text_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description_Text_Label.Location = new System.Drawing.Point(18, 155);
            this.Description_Text_Label.Name = "Description_Text_Label";
            this.Description_Text_Label.Size = new System.Drawing.Size(180, 42);
            this.Description_Text_Label.TabIndex = 6;
            this.Description_Text_Label.Text = "Payment for 30 minutes \r\ntest drive booking";
            // 
            // Description_Label
            // 
            this.Description_Label.AutoSize = true;
            this.Description_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description_Label.Location = new System.Drawing.Point(6, 134);
            this.Description_Label.Name = "Description_Label";
            this.Description_Label.Size = new System.Drawing.Size(92, 21);
            this.Description_Label.TabIndex = 5;
            this.Description_Label.Text = "Description:";
            // 
            // Cancelled_Label
            // 
            this.Cancelled_Label.AutoSize = true;
            this.Cancelled_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelled_Label.Location = new System.Drawing.Point(6, 104);
            this.Cancelled_Label.Name = "Cancelled_Label";
            this.Cancelled_Label.Size = new System.Drawing.Size(105, 21);
            this.Cancelled_Label.TabIndex = 4;
            this.Cancelled_Label.Text = "Cancelled: No";
            // 
            // Paid_Label
            // 
            this.Paid_Label.AutoSize = true;
            this.Paid_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paid_Label.Location = new System.Drawing.Point(6, 83);
            this.Paid_Label.Name = "Paid_Label";
            this.Paid_Label.Size = new System.Drawing.Size(137, 21);
            this.Paid_Label.TabIndex = 3;
            this.Paid_Label.Text = "Has Been Paid: Yes";
            // 
            // Transaction_Type_Label
            // 
            this.Transaction_Type_Label.AutoSize = true;
            this.Transaction_Type_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transaction_Type_Label.Location = new System.Drawing.Point(6, 62);
            this.Transaction_Type_Label.Name = "Transaction_Type_Label";
            this.Transaction_Type_Label.Size = new System.Drawing.Size(192, 21);
            this.Transaction_Type_Label.TabIndex = 2;
            this.Transaction_Type_Label.Text = "Transaction Type: Payment";
            // 
            // Transaction_Time_Label
            // 
            this.Transaction_Time_Label.AutoSize = true;
            this.Transaction_Time_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transaction_Time_Label.Location = new System.Drawing.Point(6, 20);
            this.Transaction_Time_Label.Name = "Transaction_Time_Label";
            this.Transaction_Time_Label.Size = new System.Drawing.Size(261, 21);
            this.Transaction_Time_Label.TabIndex = 1;
            this.Transaction_Time_Label.Text = "Transaction Time: 01/12/2025 10:12";
            // 
            // Amount_Label
            // 
            this.Amount_Label.AutoSize = true;
            this.Amount_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amount_Label.Location = new System.Drawing.Point(6, 41);
            this.Amount_Label.Name = "Amount_Label";
            this.Amount_Label.Size = new System.Drawing.Size(112, 21);
            this.Amount_Label.TabIndex = 0;
            this.Amount_Label.Text = "Amount: £0.00";
            // 
            // Verified_Label
            // 
            this.Verified_Label.AutoSize = true;
            this.Verified_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Verified_Label.Location = new System.Drawing.Point(6, 201);
            this.Verified_Label.Name = "Verified_Label";
            this.Verified_Label.Size = new System.Drawing.Size(93, 21);
            this.Verified_Label.TabIndex = 55;
            this.Verified_Label.Text = "Verified: Yes";
            // 
            // Cust_Expiry_Label
            // 
            this.Cust_Expiry_Label.AutoSize = true;
            this.Cust_Expiry_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cust_Expiry_Label.Location = new System.Drawing.Point(6, 180);
            this.Cust_Expiry_Label.Name = "Cust_Expiry_Label";
            this.Cust_Expiry_Label.Size = new System.Drawing.Size(143, 21);
            this.Cust_Expiry_Label.TabIndex = 54;
            this.Cust_Expiry_Label.Text = "Expiry: 05/05/2029";
            // 
            // Cust_Issue_Label
            // 
            this.Cust_Issue_Label.AutoSize = true;
            this.Cust_Issue_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cust_Issue_Label.Location = new System.Drawing.Point(6, 159);
            this.Cust_Issue_Label.Name = "Cust_Issue_Label";
            this.Cust_Issue_Label.Size = new System.Drawing.Size(136, 21);
            this.Cust_Issue_Label.TabIndex = 53;
            this.Cust_Issue_Label.Text = "Issue: 03/04/2019";
            // 
            // Cust_LicenseNo_Label
            // 
            this.Cust_LicenseNo_Label.AutoSize = true;
            this.Cust_LicenseNo_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cust_LicenseNo_Label.Location = new System.Drawing.Point(6, 138);
            this.Cust_LicenseNo_Label.Name = "Cust_LicenseNo_Label";
            this.Cust_LicenseNo_Label.Size = new System.Drawing.Size(183, 21);
            this.Cust_LicenseNo_Label.TabIndex = 52;
            this.Cust_LicenseNo_Label.Text = "License No: 1946835735";
            // 
            // PrevCust_Label
            // 
            this.PrevCust_Label.AutoSize = true;
            this.PrevCust_Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevCust_Label.Location = new System.Drawing.Point(6, 104);
            this.PrevCust_Label.Name = "PrevCust_Label";
            this.PrevCust_Label.Size = new System.Drawing.Size(172, 21);
            this.PrevCust_Label.TabIndex = 51;
            this.PrevCust_Label.Text = "Previous Customer: Yes";
            // 
            // Filter_ComboBox
            // 
            this.Filter_ComboBox.CausesValidation = false;
            this.Filter_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Filter_ComboBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_ComboBox.FormattingEnabled = true;
            this.Filter_ComboBox.Items.AddRange(new object[] {
            "Customer Name",
            "Transaction Time",
            "Transaction Type",
            "Amount"});
            this.Filter_ComboBox.Location = new System.Drawing.Point(625, 532);
            this.Filter_ComboBox.Name = "Filter_ComboBox";
            this.Filter_ComboBox.Size = new System.Drawing.Size(165, 38);
            this.Filter_ComboBox.TabIndex = 56;
            // 
            // Filter_TextBox
            // 
            this.Filter_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Filter_TextBox.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_TextBox.Location = new System.Drawing.Point(17, 531);
            this.Filter_TextBox.Name = "Filter_TextBox";
            this.Filter_TextBox.Size = new System.Drawing.Size(587, 39);
            this.Filter_TextBox.TabIndex = 55;
            // 
            // Mark_Paid_Button
            // 
            this.Mark_Paid_Button.Image = global::Year_14_CA_SSD.Properties.Resources.paid;
            this.Mark_Paid_Button.Location = new System.Drawing.Point(802, 447);
            this.Mark_Paid_Button.Name = "Mark_Paid_Button";
            this.Mark_Paid_Button.Size = new System.Drawing.Size(64, 64);
            this.Mark_Paid_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Mark_Paid_Button.TabIndex = 64;
            this.Mark_Paid_Button.TabStop = false;
            // 
            // Show_Cancelled_Button
            // 
            this.Show_Cancelled_Button.Image = global::Year_14_CA_SSD.Properties.Resources.cancel_not_visible;
            this.Show_Cancelled_Button.Location = new System.Drawing.Point(802, 82);
            this.Show_Cancelled_Button.Name = "Show_Cancelled_Button";
            this.Show_Cancelled_Button.Size = new System.Drawing.Size(64, 64);
            this.Show_Cancelled_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Show_Cancelled_Button.TabIndex = 63;
            this.Show_Cancelled_Button.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox8.Location = new System.Drawing.Point(788, 528);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(5, 53);
            this.pictureBox8.TabIndex = 62;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox7.Location = new System.Drawing.Point(621, 525);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(5, 53);
            this.pictureBox7.TabIndex = 61;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox6.Location = new System.Drawing.Point(625, 568);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(164, 10);
            this.pictureBox6.TabIndex = 60;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox5.Location = new System.Drawing.Point(625, 526);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(164, 10);
            this.pictureBox5.TabIndex = 59;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(616, 523);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(180, 61);
            this.pictureBox4.TabIndex = 58;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(12, 523);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(598, 61);
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            // 
            // Sort_Amount
            // 
            this.Sort_Amount.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDownGrid;
            this.Sort_Amount.BackColor = System.Drawing.SystemColors.Window;
            this.Sort_Amount.Image = global::Year_14_CA_SSD.Properties.Resources.sort;
            this.Sort_Amount.Location = new System.Drawing.Point(768, 18);
            this.Sort_Amount.Name = "Sort_Amount";
            this.Sort_Amount.Size = new System.Drawing.Size(20, 20);
            this.Sort_Amount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sort_Amount.TabIndex = 54;
            this.Sort_Amount.TabStop = false;
            this.Sort_Amount.Click += new System.EventHandler(this.Sort_Amount_Click);
            // 
            // Sort_Transaction_Type
            // 
            this.Sort_Transaction_Type.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDownGrid;
            this.Sort_Transaction_Type.BackColor = System.Drawing.SystemColors.Window;
            this.Sort_Transaction_Type.Image = global::Year_14_CA_SSD.Properties.Resources.sort;
            this.Sort_Transaction_Type.Location = new System.Drawing.Point(571, 18);
            this.Sort_Transaction_Type.Name = "Sort_Transaction_Type";
            this.Sort_Transaction_Type.Size = new System.Drawing.Size(20, 20);
            this.Sort_Transaction_Type.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sort_Transaction_Type.TabIndex = 53;
            this.Sort_Transaction_Type.TabStop = false;
            this.Sort_Transaction_Type.Click += new System.EventHandler(this.Sort_Transaction_Type_Click);
            // 
            // Sort_Transaction_Time
            // 
            this.Sort_Transaction_Time.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDownGrid;
            this.Sort_Transaction_Time.BackColor = System.Drawing.SystemColors.Window;
            this.Sort_Transaction_Time.Image = global::Year_14_CA_SSD.Properties.Resources.sort;
            this.Sort_Transaction_Time.Location = new System.Drawing.Point(390, 18);
            this.Sort_Transaction_Time.Name = "Sort_Transaction_Time";
            this.Sort_Transaction_Time.Size = new System.Drawing.Size(20, 20);
            this.Sort_Transaction_Time.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sort_Transaction_Time.TabIndex = 52;
            this.Sort_Transaction_Time.TabStop = false;
            this.Sort_Transaction_Time.Click += new System.EventHandler(this.Sort_Transaction_Time_Click);
            // 
            // Sort_Customer
            // 
            this.Sort_Customer.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDownGrid;
            this.Sort_Customer.BackColor = System.Drawing.SystemColors.Window;
            this.Sort_Customer.Image = global::Year_14_CA_SSD.Properties.Resources.sort;
            this.Sort_Customer.Location = new System.Drawing.Point(188, 18);
            this.Sort_Customer.Name = "Sort_Customer";
            this.Sort_Customer.Size = new System.Drawing.Size(20, 20);
            this.Sort_Customer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sort_Customer.TabIndex = 51;
            this.Sort_Customer.TabStop = false;
            this.Sort_Customer.Click += new System.EventHandler(this.Sort_Customer_Click);
            // 
            // Search_Button
            // 
            this.Search_Button.Image = global::Year_14_CA_SSD.Properties.Resources.search_icon;
            this.Search_Button.Location = new System.Drawing.Point(802, 520);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(64, 64);
            this.Search_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Search_Button.TabIndex = 41;
            this.Search_Button.TabStop = false;
            this.Search_Button.Click += new System.EventHandler(this.Search_Button_Click);
            // 
            // Refresh_Button
            // 
            this.Refresh_Button.Image = global::Year_14_CA_SSD.Properties.Resources.grey_thin_refresh;
            this.Refresh_Button.Location = new System.Drawing.Point(802, 12);
            this.Refresh_Button.Name = "Refresh_Button";
            this.Refresh_Button.Size = new System.Drawing.Size(63, 64);
            this.Refresh_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Refresh_Button.TabIndex = 50;
            this.Refresh_Button.TabStop = false;
            this.Refresh_Button.Click += new System.EventHandler(this.Refresh_Button_Click);
            // 
            // PaymentDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 596);
            this.Controls.Add(this.Mark_Paid_Button);
            this.Controls.Add(this.Show_Cancelled_Button);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.Filter_ComboBox);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.Filter_TextBox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Sort_Amount);
            this.Controls.Add(this.Sort_Transaction_Type);
            this.Controls.Add(this.Sort_Transaction_Time);
            this.Controls.Add(this.Sort_Customer);
            this.Controls.Add(this.Search_Button);
            this.Controls.Add(this.Payment_Label);
            this.Controls.Add(this.Refresh_Button);
            this.Controls.Add(this.Customer_GroupBox);
            this.Controls.Add(this.Payments_ListView);
            this.Name = "PaymentDataForm";
            this.Text = "PaymentDataForm";
            this.Load += new System.EventHandler(this.PaymentDataForm_Load);
            this.Customer_GroupBox.ResumeLayout(false);
            this.Customer_GroupBox.PerformLayout();
            this.Payment_Label.ResumeLayout(false);
            this.Payment_Label.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mark_Paid_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Show_Cancelled_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sort_Amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sort_Transaction_Type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sort_Transaction_Time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sort_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh_Button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Payments_ListView;
        private System.Windows.Forms.GroupBox Customer_GroupBox;
        private System.Windows.Forms.Label Cust_Postcode_Label;
        private System.Windows.Forms.Label Cust_Email_Label;
        private System.Windows.Forms.Label Cust_DOB_Label;
        private System.Windows.Forms.Label Cust_Tel_Label;
        private System.Windows.Forms.PictureBox Refresh_Button;
        private System.Windows.Forms.GroupBox Payment_Label;
        private System.Windows.Forms.Label Transaction_Type_Label;
        private System.Windows.Forms.Label Transaction_Time_Label;
        private System.Windows.Forms.Label Amount_Label;
        private System.Windows.Forms.Label Description_Text_Label;
        private System.Windows.Forms.Label Description_Label;
        private System.Windows.Forms.Label Cancelled_Label;
        private System.Windows.Forms.Label Paid_Label;
        private System.Windows.Forms.PictureBox Search_Button;
        private System.Windows.Forms.Label Verified_Label;
        private System.Windows.Forms.Label Cust_Expiry_Label;
        private System.Windows.Forms.Label Cust_Issue_Label;
        private System.Windows.Forms.Label Cust_LicenseNo_Label;
        private System.Windows.Forms.Label PrevCust_Label;
        private System.Windows.Forms.PictureBox Sort_Amount;
        private System.Windows.Forms.PictureBox Sort_Transaction_Type;
        private System.Windows.Forms.PictureBox Sort_Transaction_Time;
        private System.Windows.Forms.PictureBox Sort_Customer;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ComboBox Filter_ComboBox;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox Filter_TextBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox Show_Cancelled_Button;
        private System.Windows.Forms.PictureBox Mark_Paid_Button;
    }
}