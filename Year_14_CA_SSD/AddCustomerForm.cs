using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Year_14_CA_SSD
{
    public partial class AddCustomerForm : Form
    {
        public event EventHandler Return;
        public AddCustomerForm()
        {
            InitializeComponent();
        }
        public int textBoxIndex = 0;
        public bool addMode = true;
        public int Id = 0;
        public string[] columnsToUpdate = { "FirstName","MiddleName","LastName","DateOfBirth","PhoneNumber","EmailAddress","AddressLine1","AddressLine2","AddressLine3","PostCode","LicenseNo","IssueDate","ExpiryDate","VerifiedLicense","PreviousCustomer","DamagedVehicle"};
        public string[] updatedValues;

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            DOB_DateTimePicker.MaxDate = DateTime.Now.AddYears(-16);
            DOB_DateTimePicker.MinDate = new DateTime(1900,1,1);
            Issue_DateTimePicker.MaxDate = DateTime.Now;
            Issue_DateTimePicker.MinDate = new DateTime(1970, 1, 1);
            Expiry_DateTimePicker.MinDate = new DateTime(1970, 1, 1);
            Expiry_DateTimePicker.MaxDate = DateTime.Now.AddYears(20);
            if (addMode)
            {
                Title_Label.Text = "Add Customer";
                Add_Customer_Button.Text = "Add Customer";
            }
            else
            {
                Title_Label.Text = "Edit Customer";
                Add_Customer_Button.Text = "Apply Changes";
                Load_Customer_Data();
            }
        }

        private void Add_Customer_Button_Click(object sender, EventArgs e)
        {
            updatedValues = new string[] { First_Name_TextBox.Text, Middle_Name_TextBox.Text, Last_Name_TextBox.Text, DOB_DateTimePicker.Value.ToString("yyyyMMdd hh:mm:ss tt"), Phone_Number_TextBox.Text, Email_Address_TextBox.Text, Address_Line1_TextBox.Text, Address_Line2_TextBox.Text, Address_Line3_TextBox.Text, PostCode_TextBox.Text, License_Number_TextBox.Text, Issue_DateTimePicker.Value.ToString("yyyyMMdd hh:mm:ss tt"), Expiry_DateTimePicker.Value.ToString("yyyyMMdd hh:mm:ss tt"), Convert.ToString(Verified_License_CheckBox.Checked), Convert.ToString(Previous_Customer_CheckBox.Checked), Convert.ToString(Damaged_Vehicle_CheckBox.Checked),"false" };
            if (addMode)
            {
                Add_Customer();
            }
            else
            {
                Update_Customer();
            }
        }
        void Set_TextBox_Backgrounds()
        {
            First_Name_TextBox.BackColor = SystemColors.Window;
            Middle_Name_TextBox.BackColor = SystemColors.Window;
            Last_Name_TextBox.BackColor = SystemColors.Window;
            Address_Line1_TextBox.BackColor = SystemColors.Window;
            Address_Line2_TextBox.BackColor = SystemColors.Window;
            Address_Line3_TextBox.BackColor = SystemColors.Window;
            PostCode_TextBox.BackColor = SystemColors.Window;
            License_Number_TextBox.BackColor = SystemColors.Window;
            Phone_Number_TextBox.BackColor = SystemColors.Window;
            Email_Address_TextBox.BackColor = SystemColors.Window;
        }
        bool Customer_Valid()
        {
            bool lettersOnly = true;
            bool nonLetters = false;
            bool numbers = true;
            bool noNumbers = false;
            bool specialChars = true;
            bool noSpecialChars = false;
            bool spaces = true;
            bool noSpaces = false;

            Error_ToolTip.RemoveAll();
            Set_TextBox_Backgrounds();
            Expiry_Invalid_Text.Visible = false;

            bool valid = true;

            if (!Globals.validString(First_Name_TextBox.Text,20,1,nonLetters,noNumbers,noSpecialChars,spaces))
            {
                First_Name_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(First_Name_TextBox, "First Name is invalid \n Check that it is not empty and has no numbers or special characters \n If a double barrel name is used, use a space not a hypen");
                valid = false;
            }
            if(Middle_Name_TextBox.Text != "" && !Globals.validString(Middle_Name_TextBox.Text,20,1,nonLetters,noNumbers,noSpecialChars,spaces))
            {
                Middle_Name_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Middle_Name_TextBox, "Middle Name is invalid \n If filled in, it must not have any numebr or special characters \n If a double barrel name is used, use a space");
                valid = false;
            }
            if(!Globals.validString(Last_Name_TextBox.Text,20,1,nonLetters,noNumbers,noSpecialChars,spaces))
            {
                Last_Name_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Last_Name_TextBox, "Last Name is invalid \n Check that it is not empty and has no number or special characters \n If a double barrel name is used, use a space instead of a hypen");
                valid = false;
            }
            if(!Globals.validString(Address_Line1_TextBox.Text,40,3,nonLetters,numbers,specialChars,spaces))
            {
                Address_Line1_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Address_Line1_TextBox, "Address Line 1 is invalid \n Check that it is filled in and not left empty");
                valid = false;
            }
            if (Address_Line2_TextBox.Text != "" && !Globals.validString(Address_Line2_TextBox.Text, 40, 0,nonLetters,numbers,specialChars,spaces))
            {
                Address_Line2_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Address_Line2_TextBox, "Address Line 2 is invalid \n Check that it is filled in and not left empty");
                valid = false;
            }
            if (!Globals.validString(Address_Line3_TextBox.Text,40,3,nonLetters,numbers,specialChars,spaces))
            {
                Address_Line3_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Address_Line3_TextBox, "Address Line 3 is invalid");
                valid = false;
            }
            if (!Globals.validPostCode(PostCode_TextBox.Text))
            {
                PostCode_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(PostCode_TextBox, "Postcode is invalid \n Make sure it is in the correct format");
                valid = false;
            }
            if(!Globals.validDriversNumber(License_Number_TextBox.Text,DOB_DateTimePicker.Value,First_Name_TextBox.Text,Middle_Name_TextBox.Text,Last_Name_TextBox.Text))
            {
                License_Number_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(License_Number_TextBox, "License Number is invalid \n Make sure you have inputted it correctly \n If you are using a Irish License, use your drivers number at 4b on your license");
                valid = false;
            }
            if(Expiry_DateTimePicker.Value < Issue_DateTimePicker.Value.AddYears(3))
            {
                Expiry_Invalid_Text.Visible = true;
                valid = false;
            }
            if(!Globals.validPhoneNumber(Phone_Number_TextBox.Text))
            {
                Phone_Number_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Phone_Number_TextBox, "Phone number is invalid \n ensure that you put 0 in front of a UK number");
                valid = false;
            }
            if(Email_Address_TextBox.Text != "" && !Globals.validString(Email_Address_TextBox.Text,50,5,nonLetters,numbers,specialChars,noSpaces))
            {
                Email_Address_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Email_Address_TextBox, "Email Address in invalid \n Ensure you have spelt it correctly");
                valid = false;
            }
            return valid;
        }
        void Add_Customer()
        {
            try
            {
                if (Customer_Valid())
                {
                    bool success = SQL_Operation.CreateEntry(updatedValues, "CustomerTable");
                    if (!success)
                    {
                        throw new Exception();
                    }
                    Return_To_CustomerDataForm();
                }
            }
            catch
            {
                MessageBox.Show("An error ocurred");
            }
        }
        void Update_Customer()
        {
            try
            {
                bool success = SQL_Operation.UpdateEntryVariables(Id, "CustomerId", columnsToUpdate, updatedValues, "CustomerTable");
                if(!success) { throw new Exception(); }
                Return_To_CustomerDataForm();
            }
            catch
            {
                MessageBox.Show("An error occured updating the customer");
            }
        }
        void Load_Customer_Data()
        {
            try
            {
                string[] values = SQL_Operation.ReadEntry(Id, "CustomerId", "CustomerTable");
                for (int i = 0; i < values.Length; i++)
                {
                    string value = values[i];
                    if (value == "")
                    {
                        value = " ";
                    }
                }
                First_Name_TextBox.Text = values[1];
                Middle_Name_TextBox.Text = values[2];
                Last_Name_TextBox.Text = values[3];
                DOB_DateTimePicker.Value = Convert.ToDateTime(values[4]);
                Phone_Number_TextBox.Text = values[5];
                Email_Address_TextBox.Text = values[6];
                Address_Line1_TextBox.Text = values[7];
                Address_Line2_TextBox.Text = values[8];
                Address_Line3_TextBox.Text = values[9];
                PostCode_TextBox.Text = values[10];
                License_Number_TextBox.Text = values[11];
                Issue_DateTimePicker.Value = Convert.ToDateTime(values[12]);
                Expiry_DateTimePicker.Value = Convert.ToDateTime(values[13]);
                Verified_License_CheckBox.Checked = Convert.ToBoolean(values[14]);
                Previous_Customer_CheckBox.Checked = Convert.ToBoolean(values[15]);
                Damaged_Vehicle_CheckBox.Checked = Convert.ToBoolean(values[16]);
            }
            catch
            {
                MessageBox.Show("An error occurred when fetching user data");
            }

        }
        void Return_To_CustomerDataForm()
        {
            if (Return != null)
            {
                Return.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            if (Return != null)
            {
                Return.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        private void PostCode_TextBox_TextChanged(object sender, EventArgs e)
        {
            PostCode_TextBox.Text = PostCode_TextBox.Text.ToUpper();
            PostCode_TextBox.SelectionStart = textBoxIndex+1;
            PostCode_TextBox.SelectionLength = 0;
            PostCode_TextBox.Text = Globals.postCodeInsertSpace(PostCode_TextBox.Text);
            textBoxIndex = PostCode_TextBox.SelectionStart;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Middle_Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            Capitalise_TextBox(Middle_Name_TextBox);
        }

        private void Middle_Name_Label_Click(object sender, EventArgs e)
        {

        }

        private void First_Name_Label_Click(object sender, EventArgs e)
        {

        }

        private void First_Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            if(!addMode)
            {
                if(!First_Name_Label.Text.Contains("*")) //not updated
                {
                    First_Name_Label.Text += "*";

                }
            }
            Capitalise_TextBox(First_Name_TextBox);
        }

        private void Address_Line1_Label_Click(object sender, EventArgs e)
        {

        }

        private void Address_Line2_Label_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Phone_Number_Label_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Verified_License_CheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

       

        private void Previous_Customer_CheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Last_Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            Capitalise_TextBox(Last_Name_TextBox);
        }

        private void Address_Line3_TextBox_TextChanged(object sender, EventArgs e)
        {
            Capitalise_TextBox(Address_Line3_TextBox);
        }

        private void Address_Line1_TextBox_TextChanged(object sender, EventArgs e)
        {
            Capitalise_TextBox(Address_Line1_TextBox);
        }

        private void Address_Line2_TextBox_TextChanged(object sender, EventArgs e)
        {
            Capitalise_TextBox(Address_Line2_TextBox);
        }

        private void License_Number_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Phone_Number_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Email_Address_TextBox_TextChanged(object sender, EventArgs e)
        {
            Capitalise_TextBox(Email_Address_TextBox);
        }
        void Capitalise_TextBox(TextBox textbox)
        {
            textbox.Text = Globals.capitaliseString(textbox.Text);
            textbox.SelectionStart = textBoxIndex + 1;
            textbox.SelectionLength = 0;
            textBoxIndex = textbox.SelectionStart;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
