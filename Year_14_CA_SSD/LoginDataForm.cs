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
    public partial class LoginDataForm : Form
    {
        public event EventHandler ManagerSettings;
        public event EventHandler HomeScreen;
        public LoginDataForm()
        {
            InitializeComponent();
        }
        string[] employeeData;
        private void LoginDataForm_Load(object sender, EventArgs e)
        {
            Display_Employee_Data();
            if(!Globals.isManager)
            {
                Manager_Settings_Button.Visible = false;
            }
        }
        void Display_Employee_Data()
        {
            Load_Employee_Data();
            Name_Label.Text = employeeData[1] + " " + employeeData[2] + " " + employeeData[3];
            DOB_Label.Text = Globals.removeTime(employeeData[4]);
            Phone_Number_Label.Text = employeeData[5];
            Email_Label.Text = employeeData[6];
            Address_Line1_Label.Text = employeeData[7];
            Address_Line2_Label.Text = employeeData[8];
            Address_Line3_Label.Text = employeeData[9];
            Postcode_Label.Text = employeeData[10];
            Department_Label.Text = employeeData[11];
            Role_Label.Text = employeeData[12];
            Username_Label.Text = employeeData[13];
            Manager_Label.Text = Globals.boolToYN(employeeData[16]);
        }
        void Load_Employee_Data()
        {
            employeeData = SQL_Operation.ReadEntry((int)Globals.loginId, "EmployeeId", "EmployeeTable");
        }

        private void Sign_Out_Button_Click(object sender, EventArgs e)
        {
            Sign_Out();
        }
        void Sign_Out()
        {
            Globals.loginId = null;
            Globals.isManager = false;
            Globals.signedIn = false;
            if(HomeScreen != null)
            {
                HomeScreen.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        private void Manager_Settings_Button_Click(object sender, EventArgs e)
        {
            if(ManagerSettings != null)
            {
                ManagerSettings.Invoke(this,EventArgs.Empty);
            }
            this.Close();
        }

        private void Reset_Password_Button_Click(object sender, EventArgs e)
        {
            Error_ToolTip.RemoveAll();
            Retype_Password_TextBox.BackColor = SystemColors.Window;
            New_Password_TextBox.BackColor = SystemColors.Window;
            if(New_Password_TextBox.Text != Retype_Password_TextBox.Text)
            {
                Retype_Password_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(Retype_Password_TextBox, "Passwords must match");
                return;
            }
            if(Globals.validPassword(New_Password_TextBox.Text))
            {
                New_Password_TextBox.BackColor = Color.Salmon;
                Error_ToolTip.SetToolTip(New_Password_TextBox, "Password does not meet the requirements \n Needs to be between 8 and 50 characters, \n Have mixed case, a digit and a special character \n Also cannot contain spaces");
                return;
            }
            if(!SQL_Operation.UpdateEntryVariable(Globals.loginId.Value, "EmployeeId", "Password", New_Password_TextBox.Text, "EmployeeTable"))
            {
                MessageBox.Show("An error occured ");
                return;
            }

        }
    }
}
