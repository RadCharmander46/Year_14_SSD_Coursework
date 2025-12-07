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
    public partial class PanelForm : Form
    {
        public PanelForm()
        {
            InitializeComponent();
            Sidebar_FlowPanel.Controls.Clear();
            Clear_To_HomeScreen();
        }

        private void PanelForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            Update_Clock();

        }
        void Load_CustomerDataForm(object sender, EventArgs e)
        {
            CustomerDataForm Customer_Object = new CustomerDataForm();
            Customer_Object.TopLevel = false;
            Customer_Object.AutoScroll = true;
            Customer_Object.FormBorderStyle = FormBorderStyle.None;
            Customer_Object.Dock = DockStyle.Fill;
            Screen_Panel.Controls.Add(Customer_Object);
            Customer_Object.AddCustomer += new EventHandler(Load_AddCustomerForm);
            Customer_Object.Show();
        }
        void Load_AddCustomerForm(object sender, EventArgs e)
        {
            AddCustomerForm Add_Customer_Object = new AddCustomerForm();
            Add_Customer_EventArgs eArgs = (Add_Customer_EventArgs)e;
            Add_Customer_Object.Id = eArgs.Id;
            Add_Customer_Object.addMode = eArgs.AddMode;
            Add_Customer_Object.TopLevel = false;
            Add_Customer_Object.AutoScroll = true;
            Add_Customer_Object.FormBorderStyle = FormBorderStyle.None;
            Add_Customer_Object.Dock = DockStyle.Fill;
            Screen_Panel.Controls.Add(Add_Customer_Object);
            Add_Customer_Object.Return += new EventHandler(Load_CustomerDataForm);
            Add_Customer_Object.Show();
        }

        void Load_TestDriveBookingForm(object sender, EventArgs e)
        {
            TestDrive_EventArgs args = (TestDrive_EventArgs)e;
            TestDriveBookingForm Test_Drive_Booking_Object = new TestDriveBookingForm();
            Test_Drive_Booking_Object.TopLevel = false;
            Test_Drive_Booking_Object.AutoScroll = true;
            Test_Drive_Booking_Object.FormBorderStyle = FormBorderStyle.None;
            Test_Drive_Booking_Object.Dock = DockStyle.Fill;
            Test_Drive_Booking_Object.AddMode = args.AddMode;
            Test_Drive_Booking_Object.TestDriveId = args.Id;
            Screen_Panel.Controls.Add(Test_Drive_Booking_Object);
            Test_Drive_Booking_Object.HomeScreen += new EventHandler(Load_HomeScreenForm);
            Test_Drive_Booking_Object.Show();
        }
        void Load_TestDriveDataForm(object sender, EventArgs e)
        {
            TestDriveDataForm Test_Drive_Data_Object = new TestDriveDataForm();
            Test_Drive_Data_Object.TopLevel = false;
            Test_Drive_Data_Object.AutoScroll = true;
            Test_Drive_Data_Object.FormBorderStyle = FormBorderStyle.None;
            Test_Drive_Data_Object.Dock = DockStyle.Fill;
            Test_Drive_Data_Object.TestDrive += new EventHandler(Load_TestDriveBookingForm);
            Screen_Panel.Controls.Add(Test_Drive_Data_Object);
            Test_Drive_Data_Object.Show();
        }
        void Load_CarCalenderForm(object sender, EventArgs e)
        {
            CarCalendarForm Car_Calender_Object = new CarCalendarForm();
            Car_Calender_Object.TopLevel = false;
            Car_Calender_Object.AutoScroll = true;
            Car_Calender_Object.FormBorderStyle = FormBorderStyle.None;
            Car_Calender_Object.Dock = DockStyle.Fill;
            Screen_Panel.Controls.Add(Car_Calender_Object);
            Car_Calender_Object.Show();
        }
        void Load_ReportForm(object sender, EventArgs e)
        {
            ReportForm Report_Object = new ReportForm();
            Report_Object.TopLevel = false;
            Report_Object.AutoScroll = true;
            Report_Object.FormBorderStyle = FormBorderStyle.None;
            Report_Object.Dock = DockStyle.Fill;
            Screen_Panel.Controls.Add(Report_Object);
            Report_Object.Show();
        }
        void Load_LoginForm(object sender, EventArgs e)
        {
            LoginForm Login_Object = new LoginForm();
            Login_Object.TopLevel = false;
            Login_Object.AutoScroll = true;
            Login_Object.FormBorderStyle = FormBorderStyle.None;
            Login_Object.Dock = DockStyle.Fill;
            Screen_Panel.Controls.Add(Login_Object);
            Login_Object.SignedIn += new EventHandler(Update_Signed_In);
            Login_Object.Show();
        }
        void Load_LoginDataForm(object sender, EventArgs e)
        {
            LoginDataForm Login_Object = new LoginDataForm();
            Login_Object.TopLevel = false;
            Login_Object.AutoScroll = true;
            Login_Object.FormBorderStyle = FormBorderStyle.None;
            Login_Object.Dock = DockStyle.Fill;
            Screen_Panel.Controls.Add(Login_Object);
            Login_Object.Show();
        }
        void Load_HomeScreenForm(object sender, EventArgs e)
        {
            HomeScreenForm Home_Object = new HomeScreenForm();
            Home_Object.TopLevel = false;
            Home_Object.AutoScroll = true;
            Home_Object.FormBorderStyle = FormBorderStyle.None;
            Home_Object.Dock = DockStyle.Fill;
            Screen_Panel.Controls.Add(Home_Object);
            Home_Object.SignIn += new EventHandler(Login_Button_Click);
            Home_Object.Show();
        }
        void Load_ReturnCarForm(object sender, EventArgs e)
        {
            CarReturnForm Return_Object = new CarReturnForm();
            Return_Object.TopLevel = false;
            Return_Object.AutoScroll = true;
            Return_Object.FormBorderStyle = FormBorderStyle.None;
            Return_Object.Dock = DockStyle.Fill;
            Screen_Panel.Controls.Add(Return_Object);
            Return_Object.Show();
        }

        void Load_PaymentDataForm(object sender, EventArgs e)
        {
            PaymentDataForm Payment_Object = new PaymentDataForm();
            Payment_Object.TopLevel = false;
            Payment_Object.AutoScroll = true;
            Payment_Object.FormBorderStyle = FormBorderStyle.None;
            Payment_Object.Dock = DockStyle.Fill;
            Screen_Panel.Controls.Add(Payment_Object);
            Payment_Object.Show();
        }
        void Load_EmployeeDataForm(object sender, EventArgs e)
        {
            EmployeeDataForm Employee_Object = new EmployeeDataForm();
            Employee_Object.TopLevel = false;
            Employee_Object.AutoScroll = true;
            Employee_Object.FormBorderStyle = FormBorderStyle.None;
            Employee_Object.Dock = DockStyle.Fill;
            Screen_Panel.Controls.Add(Employee_Object);
            Employee_Object.AddEmployee += new EventHandler(Load_AddEmployeeForm);
            Employee_Object.Show();
        }
        void Load_AddEmployeeForm(object sender, EventArgs e)
        {
            AddEmployeeForm Add_Employee_Object = new AddEmployeeForm();
            Add_Employee_EventArgs eArgs = (Add_Employee_EventArgs)e;
            Add_Employee_Object.Id = eArgs.Id;
            Add_Employee_Object.addMode = eArgs.AddMode;
            Add_Employee_Object.TopLevel = false;
            Add_Employee_Object.AutoScroll = true;
            Add_Employee_Object.FormBorderStyle = FormBorderStyle.None;
            Add_Employee_Object.Dock = DockStyle.Fill;
            Screen_Panel.Controls.Add(Add_Employee_Object);
            Add_Employee_Object.Return += new EventHandler(Load_EmployeeDataForm);
            Add_Employee_Object.Show();
        }

        private void Adding_Cars_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not part of program");
        }

        private void Selling_Cars_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not part of program");
        }

        private void Moving_Cars_Button_Click(object sender, EventArgs e)
        {
            Clear_To_HomeScreen();
            Sidebar_FlowPanel.Controls.Clear();
            Sidebar_FlowPanel.Controls.Add(Test_Drive_Button);
            Sidebar_FlowPanel.Controls.Add(Car_Servicing_Button);
            Sidebar_FlowPanel.Controls.Add(Calender_Button);
            Sidebar_FlowPanel.Controls.Add(Test_Drive_Data_Button);
            Sidebar_FlowPanel.Controls.Add(Car_Return_Button);
        }

        private void Staff_Button_Click(object sender, EventArgs e)
        {
            Clear_To_HomeScreen();
            Sidebar_FlowPanel.Controls.Clear();
            Sidebar_FlowPanel.Controls.Add(Reports_Button);
            Sidebar_FlowPanel.Controls.Add(Employee_Database_Button);
        }

        private void Customers_Button_Click(object sender, EventArgs e)
        {
            Clear_To_HomeScreen();
            Sidebar_FlowPanel.Controls.Clear();
            Sidebar_FlowPanel.Controls.Add(Customer_Database_Button);
        }

        private void Customer_Database_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Load_CustomerDataForm(this, EventArgs.Empty);
        }
        void Wipe_Panel()
        {
            foreach (Control control in Screen_Panel.Controls)
            {
                Form form = (Form)control;
                form.Close();
            }
            Screen_Panel.Controls.Clear();
        }

        private void Test_Drive_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Load_TestDriveBookingForm(this, new TestDrive_EventArgs { AddMode = true }); ;
        }

        private void Calender_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Load_CarCalenderForm(this, EventArgs.Empty);
        }

        private void Test_Drive_Data_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Load_TestDriveDataForm(this, EventArgs.Empty);
        }

        private void Reports_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Load_ReportForm(this, EventArgs.Empty);
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            if (!Globals.signedIn)
            {
                Load_LoginForm(this, EventArgs.Empty);
            }
            else
            {
                Load_LoginDataForm(this, EventArgs.Empty);
            }
        }
        void Update_Signed_In(object sender, EventArgs e)
        {
            Clear_To_HomeScreen();
        }
        void Clear_To_HomeScreen()
        {
            Wipe_Panel();
            Load_HomeScreenForm(this, EventArgs.Empty);
        }

        private void Clock_Timer_Tick(object sender, EventArgs e)
        {
            Update_Clock();
        }
        void Update_Clock()
        {
            Clock_Label.Text = DateTime.Now.ToString("HH:mm \n dd/MM/yyyy");
        }

        private void Car_Return_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Load_ReturnCarForm(this, EventArgs.Empty);
        }

        private void Payment_Database_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Load_PaymentDataForm(this, EventArgs.Empty);
        }

        private void Payment_Button_Click(object sender, EventArgs e)
        {
            Clear_To_HomeScreen();
            Sidebar_FlowPanel.Controls.Clear();
            Sidebar_FlowPanel.Controls.Add(Payment_Database_Button);
        }

        private void Employee_Database_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Load_EmployeeDataForm(this, EventArgs.Empty);
        }
    }
}
