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
    public partial class AddEmployeeForm : Form
    {
        public event EventHandler Return;
        public AddEmployeeForm()
        {
            InitializeComponent();
        }
        public bool addMode = true;
        public bool ownAccount = false;
        public int Id = 0;
        public string[] employeeColumns = {"FirstName", "MiddleName", "LastName", "DateOfBirth", "PhoneNumber", "EmailAddress", "AddressLine1", "AddressLine2", "AddressLine3", "Postcode", "Department","Role","Username","Password","Archived","ManagerAccess" };
        public string[] updatedValues;
        public bool passwordUpdate = true;

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            if(!addMode)
            {
                Load_Employee_Data();
                Setup_Edit();
            }
            DOB_DateTimePicker.MaxDate = DateTime.Today.AddYears(-16);
        }

        private void Add_Employee_Button_Click(object sender, EventArgs e)
        {
            if (addMode)
            {
                Add_Employee();
            }
            else
            {
                Update_Employee();
            }
        }
        void Setup_Edit()
        {
            Title_Label.Text = "Edit Employee";
            Add_Employee_Button.Text = "Edit Employee";
        }
        string Get_Employee_Password() //specifically is unsafe
        {
            return SQL_Operation.ReadColumn(Id, "EmployeeId", "Password", "EmployeeTable");
        }
        void Add_Employee()
        {
            updatedValues = new string[] { First_Name_TextBox.Text, Middle_Name_TextBox.Text, Last_Name_TextBox.Text, DOB_DateTimePicker.Value.ToString("yyyyMMdd hh:mm:ss tt"), Phone_Number_TextBox.Text, Email_Address_TextBox.Text, Address_Line1_TextBox.Text, Address_Line2_TextBox.Text, Address_Line3_TextBox.Text, PostCode_TextBox.Text, Department_TextBox.Text, Role_TextBox.Text, Username_TextBox.Text, Password_TextBox.Text, "False", Convert.ToString(Manager_Access_CheckBox.Checked) };
            try
            {
                if (Employee_Valid())
                {
                    bool success = SQL_Operation.CreateEntry(updatedValues, "EmployeeTable");
                    if (!success)
                    {
                        throw new Exception();
                    }
                    Return_To_EmployeeDataForm();
                }
            }
            catch
            {
                MessageBox.Show("An error ocurred");
            }
        }
        void Update_Employee()
        {
            try
            {
                if (Password_TextBox.Text != "")
                {
                    passwordUpdate = true;
                    updatedValues = new string[] { First_Name_TextBox.Text, Middle_Name_TextBox.Text, Last_Name_TextBox.Text, DOB_DateTimePicker.Value.ToString("yyyyMMdd hh:mm:ss tt"), Phone_Number_TextBox.Text, Email_Address_TextBox.Text, Address_Line1_TextBox.Text, Address_Line2_TextBox.Text, Address_Line3_TextBox.Text, PostCode_TextBox.Text, Department_TextBox.Text, Role_TextBox.Text, Username_TextBox.Text, Password_TextBox.Text, "False", Convert.ToString(Manager_Access_CheckBox.Checked) };
                }
                else
                {
                    passwordUpdate = false;
                    updatedValues = new string[] { First_Name_TextBox.Text, Middle_Name_TextBox.Text, Last_Name_TextBox.Text, DOB_DateTimePicker.Value.ToString("yyyyMMdd hh:mm:ss tt"), Phone_Number_TextBox.Text, Email_Address_TextBox.Text, Address_Line1_TextBox.Text, Address_Line2_TextBox.Text, Address_Line3_TextBox.Text, PostCode_TextBox.Text, Department_TextBox.Text, Role_TextBox.Text, Username_TextBox.Text, Get_Employee_Password(), "False", Convert.ToString(Manager_Access_CheckBox.Checked) };
                }

                if (Employee_Valid())
                {
                    bool success = SQL_Operation.UpdateEntryVariables(Id, "EmployeeId", employeeColumns, updatedValues, "EmployeeTable");
                    if (!success) { throw new Exception(); }
                    Return_To_EmployeeDataForm();
                }
            }
            catch
            {
                MessageBox.Show("An error occured updating the employee");
            }
        }
        void Load_Employee_Data()
        {
            try
            {
                string[] values = SQL_Operation.ReadEntry(Id, "EmployeeId", "EmployeeTable");
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
                Department_TextBox.Text = values[11];
                Role_TextBox.Text = values[12];
                Username_TextBox.Text = values[13];
                Manager_Access_CheckBox.Checked = Convert.ToBoolean(values[16]);
            }
            catch(Exception e)
            {
                MessageBox.Show("An error occurred when fetching user data");
            }

        }
        bool Employee_Valid()
        {
            bool valid = true;

            if(!Globals.validName(First_Name_TextBox.Text))
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
            if (!Globals.validName(Last_Name_TextBox.Text))
            {
                Last_Name_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Last_Name_TextBox, "Last Name is invalid \n Check that it is not empty and has no number or special characters \n If a double barrel name is used, use a space instead of a hypen");
                valid = false;
            }
            if (!Globals.validAddress(Address_Line1_TextBox.Text))
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
            if (!Globals.validAddress(Address_Line3_TextBox.Text))
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
            if (!Globals.validPhoneNumber(Phone_Number_TextBox.Text))
            {
                Phone_Number_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Phone_Number_TextBox, "Phone number is invalid \n ensure that you put 0 in front of a UK number");
                valid = false;
            }
            if (!Globals.validEmail(Email_Address_TextBox.Text))
            {
                Email_Address_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Email_Address_TextBox, "Email Address in invalid \n Ensure you have spelt it correctly");
                valid = false;
            }
            if(!Globals.validString(Department_TextBox.Text,20,1,false,false,false,true))
            {
                Department_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Department_TextBox, "Department name is invalid \n Ensure you have spelt it correctly");
                valid = false;
            }
            if(!Globals.validString(Role_TextBox.Text,20,1,false,false,false,true))
            {
                Role_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Role_TextBox, "Role name is invalid \n Ensure you have spelt it correctly");
                valid = false;
            }
            if (addMode || Password_TextBox.Text != "") //not checking when editing unless they're resetting their password
            {
                if (!Globals.validPassword(Password_TextBox.Text))
                {
                    Password_TextBox.BackColor = Color.Salmon;
                    Error_ToolTip.SetToolTip(Password_TextBox, "Password does not meet the requirements \n Needs to be between 8 and 50 characters, \n Have mixed case, a digit and a special character \n Also cannot contain spaces");
                    valid = false;
                }
                if (Password_TextBox.Text != Retype_Password_TextBox.Text)
                {
                    Retype_Password_TextBox.BackColor = Color.Salmon;
                    Error_ToolTip.SetToolTip(Retype_Password_TextBox, "Passwords do not match");
                    valid = false;
                }
            }
            return valid;
        }
        void Return_To_EmployeeDataForm()
        {
            if (Return != null)
            {
                Return.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        private void Generate_Username_Button_Click(object sender, EventArgs e)
        {
            string username;
            if(First_Name_TextBox.Text == "")
            {
                MessageBox.Show("Please fill in your first name");
                return;
            }
            if(Last_Name_TextBox.Text == "")
            {
                MessageBox.Show("Please fill in your last name");
            }
            Random rd = new Random();
            username = First_Name_TextBox.Text.ToUpper().Substring(0, 2) + Last_Name_TextBox.Text.ToUpper().Substring(0, 5) + rd.Next(100, 1000).ToString();
            Username_TextBox.Text = username;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            if(Return != null)
            {
                Return.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        private void First_Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            First_Name_TextBox.TextChanged -= new EventHandler(First_Name_TextBox_TextChanged);
            Globals.Remove_Illegal_Characters(First_Name_TextBox, Globals.typedNameInvalid);
            First_Name_TextBox.TextChanged += new EventHandler(First_Name_TextBox_TextChanged);
        }

        private void Middle_Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            Middle_Name_TextBox.TextChanged -= new EventHandler(Middle_Name_TextBox_TextChanged);
            Globals.Remove_Illegal_Characters(Middle_Name_TextBox, Globals.typedNameInvalid);
            Middle_Name_TextBox.TextChanged += new EventHandler(Middle_Name_TextBox_TextChanged);
        }

        private void Last_Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            Last_Name_TextBox.TextChanged -= new EventHandler(Last_Name_TextBox_TextChanged);
            Globals.Remove_Illegal_Characters(Last_Name_TextBox, Globals.typedNameInvalid);
            Last_Name_TextBox.TextChanged += new EventHandler(Last_Name_TextBox_TextChanged);
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
        void Capitalise_TextBox(TextBox textbox)
        {
            int index = textbox.SelectionStart;
            textbox.Text = Globals.capitaliseString(textbox.Text);
            textbox.SelectionStart = index;
            textbox.SelectionLength = 0;

        }

        private void Address_Line3_TextBox_TextChanged(object sender, EventArgs e)
        {
            Address_Line3_TextBox.TextChanged -= new EventHandler(Address_Line3_TextBox_TextChanged);
            Capitalise_TextBox(Address_Line3_TextBox);
            Globals.Remove_Illegal_Characters(Address_Line3_TextBox, Globals.typedAddressInvalid);
            Address_Line3_TextBox.TextChanged += new EventHandler(Address_Line3_TextBox_TextChanged);
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

            if (!Globals.validString(PostCode_TextBox.Text, 8, 0, false, true, false, true) || Globals.containsAccentedCharacters(PostCode_TextBox.Text))
            {
                PostCode_TextBox.TextChanged -= new EventHandler(PostCode_TextBox_TextChanged);
                PostCode_TextBox.Text = (string)PostCode_TextBox.Tag;
                PostCode_TextBox.TextChanged += new EventHandler(PostCode_TextBox_TextChanged);

                PostCode_TextBox.SelectionStart = index + 1;
            }

            PostCode_TextBox.SelectionLength = 0;

            PostCode_TextBox.Tag = PostCode_TextBox.Text;
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

        private void Usernname_TextBox_TextChanged(object sender, EventArgs e)
        {
            Username_TextBox.TextChanged -= new EventHandler(Usernname_TextBox_TextChanged);
            int index = Username_TextBox.SelectionStart;
            Username_TextBox.Text = Username_TextBox.Text.ToUpper();
            Username_TextBox.SelectionStart = index;
            Globals.Remove_Illegal_Characters(Username_TextBox, Globals.typedUsernameInvalid);
            Username_TextBox.TextChanged += new EventHandler(Usernname_TextBox_TextChanged);
        }

        private void Department_TextBox_TextChanged(object sender, EventArgs e)
        {
            Department_TextBox.TextChanged -= new EventHandler(Department_TextBox_TextChanged);
            Globals.Remove_Illegal_Characters(Department_TextBox, typedDepartmentInvalid);
            Department_TextBox.TextChanged += new EventHandler(Department_TextBox_TextChanged);
        }
        bool typedDepartmentInvalid(string department)
        {
            return !Globals.validString(department, 20, 0, false, false, true, true);
        }
        bool typedRoleInvalid(string role)
        {
            return !Globals.validString(role, 0, 20, false, false, true, true);
        }

        private void Role_TextBox_TextChanged(object sender, EventArgs e)
        {
            Role_TextBox.TextChanged -= new EventHandler(Role_TextBox_TextChanged);
            Globals.Remove_Illegal_Characters(Role_TextBox, typedDepartmentInvalid);
            Role_TextBox.TextChanged += new EventHandler(Role_TextBox_TextChanged);
        }

        private void First_Name_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Add_Employee_Button.PerformClick();
            }
        }

        private void Manager_Access_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Manager_Access_CheckBox.CheckedChanged -= new EventHandler(Manager_Access_CheckBox_CheckedChanged);
            if(ownAccount)
            {
                Manager_Access_CheckBox.Checked = !Manager_Access_CheckBox.Checked;
                MessageBox.Show("Cannot edit manager access for own account");
            }
            Manager_Access_CheckBox.CheckedChanged += new EventHandler(Manager_Access_CheckBox_CheckedChanged);

        }
    }
}
