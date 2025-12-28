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
            Username_Value_Label.Text = employeeData[13];
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reset_Password_Button_Click(object sender, EventArgs e)
        {
            if(New_Password_TextBox.Text != Retype_Password_TextBox.Text)
            {
                MessageBox.Show("Passwords must match");
                return;
            }
            if(!Password_Is_Secure(New_Password_TextBox.Text))
            {
                MessageBox.Show("Password doesn't meet the requirements");
                return;
            }
            if(!SQL_Operation.UpdateEntryVariable(Globals.loginId.Value, "EmployeeId", "Password", New_Password_TextBox.Text, "EmployeeTable"))
            {
                MessageBox.Show("An error occured ");
                return;
            }

        }
        bool Password_Is_Secure(string password)
        {
            return true;
        }
    }
}
