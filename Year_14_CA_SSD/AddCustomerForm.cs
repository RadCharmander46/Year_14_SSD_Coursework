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
            First_Name_TextBox.Focus();
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
            Error_ToolTip.RemoveAll();
            Set_TextBox_Backgrounds();
            Expiry_Invalid_Label.Visible = false;

            bool valid = true;

            if (!Globals.validName(First_Name_TextBox.Text))
            {
                First_Name_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(First_Name_TextBox, "First Name is invalid \n Check that it is not empty and has no numbers or special characters \n If a double barrel name is used, use a space not a hypen");
                valid = false;
            }
            if(Middle_Name_TextBox.Text != "" && !Globals.validName(Middle_Name_TextBox.Text))
            {
                Middle_Name_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Middle_Name_TextBox, "Middle Name is invalid \n If filled in, it must not have any numebr or special characters \n If a double barrel name is used, use a space");
                valid = false;
            }
            if(!Globals.validName(Last_Name_TextBox.Text))
            {
                Last_Name_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Last_Name_TextBox, "Last Name is invalid \n Check that it is not empty and has no number or special characters \n If a double barrel name is used, use a space instead of a hypen");
                valid = false;
            }
            if(!Globals.validAddress(Address_Line1_TextBox.Text))
            {
                Address_Line1_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Address_Line1_TextBox, "Address Line 1 is invalid \n Check that it is filled in and not left empty");
                valid = false;
            }
            if (Address_Line2_TextBox.Text != "" && !Globals.validAddress(Address_Line2_TextBox.Text))
            {
                Address_Line2_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Address_Line2_TextBox, "Address Line 2 is invalid \n Check that it is filled in and not left empty");
                valid = false;
            }
            if (!Globals.validAddress(Address_Line3_TextBox.Text) || !Globals.validString(Address_Line3_TextBox.Text, 50, 1, false, false, true,true)) //can't have numbers in line 3
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
            int age = Get_Age();
            if (age != 0)
            {
                if(Issue_DateTimePicker.Value < DOB_DateTimePicker.Value.AddYears(16))
                {
                    Issue_Invalid_Label.Visible = true;
                    valid = false;
                }
                else if (Issue_DateTimePicker.Value < new DateTime(2000, 1, 1))
                {
                    if (Times_Roughly_Years_Apart(Expiry_DateTimePicker.Value, DOB_DateTimePicker.Value, 70))
                    {
                        Expiry_Invalid_Label.Visible = true;
                        valid = false;
                    }
                }
                else if (age <= 65 || (!Is_Ireland_License() && age <= 70)) //normal license expiry - 10 years
                {
                    if (!Times_Roughly_Years_Apart(Expiry_DateTimePicker.Value, Issue_DateTimePicker.Value, 10))
                    {
                        Expiry_Invalid_Label.Visible = true;
                        valid = false;
                    }
                }
                else if (age >= 70 && !Is_Ireland_License()) //uk over 70 - 3 years
                {
                    if (!Times_Roughly_Years_Apart(Expiry_DateTimePicker.Value, Issue_DateTimePicker.Value, 3))
                    {
                        Expiry_Invalid_Label.Visible = true;
                        valid = false;
                    }
                }
                else if (age >= 65 && Is_Ireland_License()) //ireland over 65 depends but can be 5,3, or 1 year/s
                {
                    if (!Times_Roughly_Years_Apart(Expiry_DateTimePicker.Value, Issue_DateTimePicker.Value, 5) && !Times_Roughly_Years_Apart(Expiry_DateTimePicker.Value, Issue_DateTimePicker.Value, 3) && !Times_Roughly_Years_Apart(Expiry_DateTimePicker.Value, Issue_DateTimePicker.Value, 1))
                    {
                        Expiry_Invalid_Label.Visible = true;
                        valid = false;
                    }
                }
            }
            if (!Globals.validPhoneNumber(Phone_Number_TextBox.Text))
            {
                Phone_Number_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Phone_Number_TextBox, "Phone number is invalid \n ensure that you put 0 in front of a UK number");
                valid = false;
            }
            if(!Globals.validEmail(Email_Address_TextBox.Text))
            {
                Email_Address_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Email_Address_TextBox, "Email Address in invalid \n Ensure you have spelt it correctly");
                valid = false;
            }
            return valid;
        }
        bool Times_Roughly_Years_Apart(DateTime dateTime1, DateTime dateTime2, int years)
        {
            if( years * 365.25 - 14 <= (dateTime1 - dateTime2).Days && (dateTime1 - dateTime2).Days <= years * 365.25 + 14)
            {
                return true;
            }
            return false;
        }
        int Get_Age()
        {
            try
            {
                return (DateTime.Now - DOB_DateTimePicker.Value).Days / 365;
            }
            catch
            {
                return 0;
            }
        }
        bool Is_Ireland_License()
        {
            if(License_Number_TextBox.Text.Length == 9)
            {
                return true;
            }
            return false;
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
                if (Customer_Valid())
                {
                    bool success = SQL_Operation.UpdateEntryVariables(Id, "CustomerId", columnsToUpdate, updatedValues, "CustomerTable");
                    if (!success) { throw new Exception(); }
                    Return_To_CustomerDataForm();
                }
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
            catch (Exception e)
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
            int index = PostCode_TextBox.SelectionStart;

            PostCode_TextBox.TextChanged -= new EventHandler(PostCode_TextBox_TextChanged);
            PostCode_TextBox.Text = PostCode_TextBox.Text.ToUpper();
            PostCode_TextBox.TextChanged += new EventHandler(PostCode_TextBox_TextChanged);

            string spaceText = Globals.postCodeInsertSpace(PostCode_TextBox.Text);
            PostCode_TextBox.SelectionStart = index;

            if (spaceText != PostCode_TextBox.Text) //adding a space so need to offset the cursor
            {
                PostCode_TextBox.TextChanged -= new EventHandler(PostCode_TextBox_TextChanged);
                PostCode_TextBox.Text = spaceText;
                PostCode_TextBox.TextChanged += new EventHandler(PostCode_TextBox_TextChanged);

                PostCode_TextBox.SelectionStart = index + 1;
            }

            if (!Globals.validString(PostCode_TextBox.Text,8,0,false,true,false,true) || Globals.containsAccentedCharacters(PostCode_TextBox.Text))
            {
                PostCode_TextBox.TextChanged -= new EventHandler(PostCode_TextBox_TextChanged);
                PostCode_TextBox.Text = (string)PostCode_TextBox.Tag;
                PostCode_TextBox.TextChanged += new EventHandler(PostCode_TextBox_TextChanged);

                PostCode_TextBox.SelectionStart = index + 1;
            }

            PostCode_TextBox.SelectionLength = 0;

            PostCode_TextBox.Tag = PostCode_TextBox.Text;
        }

        private void Middle_Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            Middle_Name_TextBox.TextChanged -= new EventHandler(Middle_Name_TextBox_TextChanged);
            Globals.Remove_Illegal_Characters(Middle_Name_TextBox, Globals.typedNameInvalid);
            Middle_Name_TextBox.TextChanged += new EventHandler(Middle_Name_TextBox_TextChanged);
        }

        private void First_Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            First_Name_TextBox.TextChanged -= new EventHandler(First_Name_TextBox_TextChanged);
            Globals.Remove_Illegal_Characters(First_Name_TextBox, Globals.typedNameInvalid);
            First_Name_TextBox.TextChanged += new EventHandler(First_Name_TextBox_TextChanged);
            //if(!addMode)
            //{
            //    if(!First_Name_Label.Text.Contains("*")) //not updated
            //    {
            //        First_Name_Label.Text += "*";

            //    }
            //}
        }

        private void Verified_License_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Verified_License_CheckBox.CheckedChanged -= new EventHandler(Verified_License_CheckBox_CheckedChanged);
            if(!Globals.isManager)
            {
                MessageBox.Show("Needs manager approval");
                Verified_License_CheckBox.Checked = !Verified_License_CheckBox.Checked;
            }
            Verified_License_CheckBox.CheckedChanged += new EventHandler(Verified_License_CheckBox_CheckedChanged);
        }



        private void Previous_Customer_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Previous_Customer_CheckBox.CheckedChanged -= new EventHandler(Previous_Customer_CheckBox_CheckedChanged);
            if (!Globals.isManager)
            {
                MessageBox.Show("Needs manager approval");
                Previous_Customer_CheckBox.Checked = !Previous_Customer_CheckBox.Checked;
            }
            Previous_Customer_CheckBox.CheckedChanged += new EventHandler(Previous_Customer_CheckBox_CheckedChanged);
        }

        private void Last_Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            Last_Name_TextBox.TextChanged -= new EventHandler(Last_Name_TextBox_TextChanged);
            Globals.Remove_Illegal_Characters(Last_Name_TextBox, Globals.typedNameInvalid);
            Last_Name_TextBox.TextChanged += new EventHandler(Last_Name_TextBox_TextChanged);
        }

        private void Address_Line3_TextBox_TextChanged(object sender, EventArgs e)
        {
            Address_Line3_TextBox.TextChanged -= new EventHandler(Address_Line3_TextBox_TextChanged);
            Capitalise_TextBox(Address_Line3_TextBox);
            Globals.Remove_Illegal_Characters(Address_Line3_TextBox, Globals.typedAddressInvalid);
            Address_Line3_TextBox.TextChanged += new EventHandler(Address_Line3_TextBox_TextChanged);
        }

        private void Address_Line1_TextBox_TextChanged(object sender, EventArgs e)
        {
            Address_Line1_TextBox.TextChanged -= new EventHandler(Address_Line1_TextBox_TextChanged);
            Capitalise_TextBox(Address_Line1_TextBox);
            Globals.Remove_Illegal_Characters(Address_Line1_TextBox, Globals.typedAddressInvalid);
            Address_Line1_TextBox.TextChanged += new EventHandler(Address_Line1_TextBox_TextChanged);
        }

        private void Address_Line2_TextBox_TextChanged(object sender, EventArgs e)
        {
            Address_Line2_TextBox.TextChanged -= new EventHandler(Address_Line2_TextBox_TextChanged);
            Capitalise_TextBox(Address_Line2_TextBox);
            Globals.Remove_Illegal_Characters(Address_Line2_TextBox, Globals.typedAddressInvalid);
            Address_Line2_TextBox.TextChanged += new EventHandler(Address_Line2_TextBox_TextChanged);
        }

        private void License_Number_TextBox_TextChanged(object sender, EventArgs e)
        {
            License_Number_TextBox.TextChanged -= new EventHandler(License_Number_TextBox_TextChanged);
            int index = License_Number_TextBox.SelectionStart;
            License_Number_TextBox.Text = License_Number_TextBox.Text.ToUpper();
            License_Number_TextBox.SelectionStart = index;
            Globals.Remove_Illegal_Characters(License_Number_TextBox, Globals.typedLicenseInvalid);
            License_Number_TextBox.TextChanged += new EventHandler(License_Number_TextBox_TextChanged);
        }

        private void Phone_Number_TextBox_TextChanged(object sender, EventArgs e)
        {
            Phone_Number_TextBox.TextChanged -= new EventHandler(Phone_Number_TextBox_TextChanged);
            Globals.Remove_Illegal_Characters(Phone_Number_TextBox, Globals.typedPhoneNumberInvalid);
            Phone_Number_TextBox.TextChanged += new EventHandler(Phone_Number_TextBox_TextChanged);
        }

        private void Email_Address_TextBox_TextChanged(object sender, EventArgs e)
        {
            Email_Address_TextBox.TextChanged -= new EventHandler(Email_Address_TextBox_TextChanged);
            Globals.Remove_Illegal_Characters(Email_Address_TextBox, Globals.typedEmailInvalid);
            Email_Address_TextBox.TextChanged += new EventHandler(Email_Address_TextBox_TextChanged);
        }

        void Capitalise_TextBox(TextBox textbox)
        {
            int index = textbox.SelectionStart;
            textbox.Text = Globals.capitaliseString(textbox.Text);
            textbox.SelectionStart = index;
            textbox.SelectionLength = 0;

        }
        void Enter_Entered()
        {
            Add_Customer_Button_Click(this, EventArgs.Empty);
        }
      
        private void First_Name_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Enter_Entered();
            }
        }

        private void Damaged_Vehicle_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Damaged_Vehicle_CheckBox.CheckedChanged -= new EventHandler(Damaged_Vehicle_CheckBox_CheckedChanged);
            if (!Globals.isManager)
            {
                MessageBox.Show("Needs manager approval");
                Damaged_Vehicle_CheckBox.Checked = !Damaged_Vehicle_CheckBox.Checked;
            }
            Damaged_Vehicle_CheckBox.CheckedChanged += new EventHandler(Damaged_Vehicle_CheckBox_CheckedChanged);

        }
    }
}
