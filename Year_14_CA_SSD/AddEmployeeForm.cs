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
        public int Id = 0;
        public string[] employeeColumns = { "EmployeeId", "First Name/s", "Middle Name/s", "Last Name/s", "Date Of Birth", "Phone Number", "Email Address", "Address Line 1", "Address Line 2", "Town/City", "Postcode", "Department","Role","Username","Password","Archived","Manager Access" };
        public string[] updatedValues;

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            if(!addMode)
            {
                Load_Employee_Data();
            }
            DOB_DateTimePicker.MaxDate = DateTime.Today.AddYears(-16);
        }

        private void Add_Employee_Button_Click(object sender, EventArgs e)
        {
            updatedValues = new string[] { First_Name_TextBox.Text, Middle_Name_TextBox.Text, Last_Name_TextBox.Text, DOB_DateTimePicker.Value.ToString("yyyyMMdd hh:mm:ss tt"), Phone_Number_TextBox.Text, Email_Address_TextBox.Text, Address_Line1_TextBox.Text, Address_Line2_TextBox.Text, Address_Line3_TextBox.Text, PostCode_TextBox.Text, Department_TextBox.Text, Role_TextBox.Text, Usernname_TextBox.Text, Password_TextBox.Text, "False", Convert.ToString(Manager_Access_CheckBox.Checked) };
            if (addMode)
            {
                Add_Employee();
            }
            else
            {
                Update_Employee();
            }
        }
        void Add_Employee()
        {
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
                bool success = SQL_Operation.UpdateEntryVariables(Id, "EmployeeId", employeeColumns, updatedValues, "EmployeeTable");
                if (!success) { throw new Exception(); }
                Return_To_EmployeeDataForm();
            }
            catch
            {
                MessageBox.Show("An error occured updating the customer");
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
                Usernname_TextBox.Text = values[13];
                Manager_Access_CheckBox.Checked = Convert.ToBoolean(values[16]);
            }
            catch
            {
                MessageBox.Show("An error occurred when fetching user data");
            }

        }
        bool Employee_Valid()
        {
            return true;
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
            Usernname_TextBox.Text = username;
        }
    }
}
