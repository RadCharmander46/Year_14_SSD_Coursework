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
        public string[] employeeColumns = { "EmployeeId", "First Name/s", "Middle Name/s", "Last Name/s", "Date Of Birth", "Phone Number", "Email Address", "Address Line 1", "Address Line 2", "Town/City", "Postcode", "Department","Role","Username","Password","Archived","Unavailable","Next Time Available","Manager Access" };
        public string[] updatedValues;

        private void Add_Employee_Button_Click(object sender, EventArgs e)
        {
            updatedValues = new string[] { First_Name_TextBox.Text, Middle_Name_TextBox.Text, Last_Name_TextBox.Text, DOB_DateTimePicker.Value.ToString("yyyyMMdd hh:mm:ss tt"), Phone_Number_TextBox.Text, Email_Address_TextBox.Text, Address_Line1_TextBox.Text, Address_Line2_TextBox.Text, Address_Line3_TextBox.Text, PostCode_TextBox.Text, Department_TextBox.Text, Role_TextBox.Text, Usernname_TextBox.Text, Password_TextBox.Text, "False", "False", "", Convert.ToString(Manager_Access_CheckBox.Checked) };
            if (addMode)
            {
                Add_Employee();
            }
            else
            {
                Update_Employee();
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
        }

    }
}
