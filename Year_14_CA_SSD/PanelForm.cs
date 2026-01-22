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
            Fill_Sidebar_Filler();
            Clear_To_HomeScreen();
        }
        public Action<object,EventArgs>[] sidebarEvents = new Action<object, EventArgs>[5];
        void Reset_SidebarEvents()
        {
            sidebarEvents = new Action<object, EventArgs>[5];
        }
        void Fill_Sidebar_Filler()
        {
            Sidebar_FlowPanel.Controls.Add(Sidebar_Function1_PictureBox);
            Sidebar_FlowPanel.Controls.Add(Filler_Button1_PictureBox);
            Sidebar_FlowPanel.Controls.Add(Sidebar_Function2_PictureBox);
            Sidebar_FlowPanel.Controls.Add(Filler_Button2_PictureBox);
            Sidebar_FlowPanel.Controls.Add(Sidebar_Function3_PictureBox);
            Sidebar_FlowPanel.Controls.Add(Filler_Button3_PictureBox);
            Sidebar_FlowPanel.Controls.Add(Sidebar_Function4_PictureBox);
            Sidebar_FlowPanel.Controls.Add(Filler_Button4_PictureBox);
            Sidebar_FlowPanel.Controls.Add(Sidebar_Function5_PictureBox);
            Sidebar_FlowPanel.Controls.Add(Filler_Button5_PictureBox);
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
            Login_Object.ManagerSettings += new EventHandler(Load_ManagerSettingsForm);
            Login_Object.HomeScreen += new EventHandler(Load_HomeScreenForm);
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
            Home_Object.ReturnCar += new EventHandler(Load_ReturnCarForm);
            Home_Object.Show();
        }
        void Load_ReturnCarForm(object sender, EventArgs e)
        {
            try
            {
                Car_Return_EventArgs carArgs = (Car_Return_EventArgs)e;
                Moving_Cars_Button_Click(this, EventArgs.Empty); //setting up the sidebar and highlighting
                Wipe_Panel();
                Reset_Sidebar_Highlights();
                Car_Return_Button.BackColor = Color.FromArgb(145, 145, 145);
                CarReturnForm Return_Object = new CarReturnForm();
                Return_Object.TestDriveId = carArgs.testDriveId;
                Return_Object.CarId = carArgs.carId;
                Return_Object.CustomerId = carArgs.customerId;
                Return_Object.EmployeeId = carArgs.employeeId;
                Return_Object.UseTestDriveId = true;
                Return_Object.TopLevel = false;
                Return_Object.AutoScroll = true;
                Return_Object.FormBorderStyle = FormBorderStyle.None;
                Return_Object.Dock = DockStyle.Fill;
                Screen_Panel.Controls.Add(Return_Object);
                Return_Object.Show();
                Return_Object.Return += new EventHandler(Load_HomeScreenForm);
            }
            catch
            {
                CarReturnForm Return_Object = new CarReturnForm();
                Return_Object.TopLevel = false;
                Return_Object.AutoScroll = true;
                Return_Object.FormBorderStyle = FormBorderStyle.None;
                Return_Object.Dock = DockStyle.Fill;
                Screen_Panel.Controls.Add(Return_Object);
                Return_Object.Show();
                Return_Object.Return += new EventHandler(Load_HomeScreenForm);
            }
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
        void Load_ManagerSettingsForm(object sender, EventArgs e)
        {
            ManagerSettingsForm Manager_Object = new ManagerSettingsForm();
            Manager_Object.TopLevel = false;
            Manager_Object.AutoScroll = true;
            Manager_Object.FormBorderStyle = FormBorderStyle.None;
            Manager_Object.Dock = DockStyle.Fill;
            Screen_Panel.Controls.Add(Manager_Object);
            Manager_Object.Show();
            Manager_Object.Back += new EventHandler(Load_LoginDataForm);
        }

        private void Adding_Cars_Button_Click(object sender, EventArgs e)
        {
            Clear_To_HomeScreen();
            Reset_Taskbar_Highlights();
            Reset_Sidebar_Highlights();
            Reset_SidebarEvents();
            Adding_Cars_Button.BackColor = SystemColors.ActiveBorder;
            Sidebar_FlowPanel.Controls.Clear();
            Fill_Sidebar_Filler();
            MessageBox.Show("Not part of program");
        }

        private void Selling_Cars_Button_Click(object sender, EventArgs e)
        {
            Clear_To_HomeScreen();
            Reset_Taskbar_Highlights();
            Reset_Sidebar_Highlights();
            Reset_SidebarEvents();
            Selling_Cars_Button.BackColor = SystemColors.ActiveBorder;
            Sidebar_FlowPanel.Controls.Clear();
            Fill_Sidebar_Filler();
            MessageBox.Show("Not part of program");
        }

        void Reset_Taskbar_Highlights()
        {
            Moving_Cars_Button.BackColor = SystemColors.ControlLight;
            Adding_Cars_Button.BackColor = SystemColors.ControlLight;
            Selling_Cars_Button.BackColor = SystemColors.ControlLight;
            Staff_Button.BackColor = SystemColors.ControlLight;
            Customers_Button.BackColor = SystemColors.ControlLight;
            Payment_Button.BackColor = SystemColors.ControlLight;
        }
        void Reset_Sidebar_Highlights()
        {
            foreach(PictureBox button in Sidebar_FlowPanel.Controls)
            {
                button.BackColor = SystemColors.ControlDark;
            }
        }

        private void Moving_Cars_Button_Click(object sender, EventArgs e)
        {
            if (Globals.signedIn)
            {
                Clear_To_HomeScreen();
                Reset_Taskbar_Highlights();
                Reset_Sidebar_Highlights();
                Reset_SidebarEvents();
                Moving_Cars_Button.BackColor = SystemColors.ActiveBorder;

                Sidebar_FlowPanel.Controls.Clear();
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function1_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Test_Drive_Button);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function2_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Car_Servicing_Button);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function3_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Calender_Button);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function4_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Test_Drive_Data_Button);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function5_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Car_Return_Button);

                sidebarEvents[0] = Test_Drive_Button_Click;
                sidebarEvents[1] = Car_Servicing_Button_Click;
                sidebarEvents[2] = Calender_Button_Click;
                sidebarEvents[3] = Test_Drive_Data_Button_Click;
                sidebarEvents[4] = Car_Return_Button_Click;
            }
            else
            {
                MessageBox.Show("Please Sign In");
            }
        }

        private void Staff_Button_Click(object sender, EventArgs e)
        {
            if (Globals.signedIn)
            {
                Clear_To_HomeScreen();
                Reset_Taskbar_Highlights();
                Reset_Sidebar_Highlights();
                Reset_SidebarEvents();
                Staff_Button.BackColor = SystemColors.ActiveBorder;

                Sidebar_FlowPanel.Controls.Clear();
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function1_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Reports_Button);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function2_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Employee_Database_Button);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function3_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Filler_Button3_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function4_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Filler_Button4_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function5_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Filler_Button5_PictureBox);

                sidebarEvents[0] = Reports_Button_Click;
                sidebarEvents[1] = Employee_Database_Button_Click;
            }
            else
            {
                MessageBox.Show("Please Sign In");
            }
        }

        private void Customers_Button_Click(object sender, EventArgs e)
        {
            if (Globals.signedIn)
            {
                Clear_To_HomeScreen();
                Reset_Taskbar_Highlights();
                Reset_Sidebar_Highlights();
                Reset_SidebarEvents();
                Customers_Button.BackColor = SystemColors.ActiveBorder;

                Sidebar_FlowPanel.Controls.Clear();
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function1_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Customer_Database_Button);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function2_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Filler_Button2_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function3_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Filler_Button3_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function4_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Filler_Button4_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function5_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Filler_Button5_PictureBox);

                sidebarEvents[0] = Customer_Database_Button_Click;
            }
            else
            {
                MessageBox.Show("Please Sign In");
            }
        }

        private void Customer_Database_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Reset_Sidebar_Highlights();
            Customer_Database_Button.BackColor = Color.FromArgb(145, 145, 145);
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
            Reset_Sidebar_Highlights();
            Test_Drive_Button.BackColor = Color.FromArgb(145,145,145);
            Load_TestDriveBookingForm(this, new TestDrive_EventArgs { AddMode = true }); ;
        }

        private void Calender_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Reset_Sidebar_Highlights();
            Calender_Button.BackColor = Color.FromArgb(145, 145, 145);
            Load_CarCalenderForm(this, EventArgs.Empty);
        }

        private void Test_Drive_Data_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Reset_Sidebar_Highlights();
            Test_Drive_Data_Button.BackColor = Color.FromArgb(145, 145, 145);
            Load_TestDriveDataForm(this, EventArgs.Empty);
        }

        private void Reports_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Reset_Sidebar_Highlights();
            Reports_Button.BackColor = Color.FromArgb(145, 145, 145);
            Load_ReportForm(this, EventArgs.Empty);
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            Clear_To_HomeScreen();
            Wipe_Panel();
            Reset_Taskbar_Highlights();
            Reset_Sidebar_Highlights();
            Sidebar_FlowPanel.Controls.Clear();
            Fill_Sidebar_Filler();
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
            Reset_Sidebar_Highlights();
            Car_Return_Button.BackColor = Color.FromArgb(145, 145, 145);
            Load_ReturnCarForm(this, EventArgs.Empty);
        }

        private void Payment_Database_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Reset_Sidebar_Highlights();
            Payment_Database_Button.BackColor = Color.FromArgb(145, 145, 145);
            Load_PaymentDataForm(this, EventArgs.Empty);
        }

        private void Payment_Button_Click(object sender, EventArgs e)
        {if (Globals.signedIn)
            {
                Clear_To_HomeScreen();
                Reset_Taskbar_Highlights();
                Reset_Sidebar_Highlights();
                Reset_SidebarEvents();
                Payment_Button.BackColor = SystemColors.ActiveBorder;

                Sidebar_FlowPanel.Controls.Clear();
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function1_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Payment_Database_Button);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function2_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Filler_Button2_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function3_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Filler_Button3_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function4_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Filler_Button4_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Sidebar_Function5_PictureBox);
                Sidebar_FlowPanel.Controls.Add(Filler_Button5_PictureBox);

                sidebarEvents[0] = Payment_Database_Button_Click;
            }
            else
            {
                MessageBox.Show("Please Sign In");
            }
        }

        private void Employee_Database_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Reset_Sidebar_Highlights();
            Employee_Database_Button.BackColor = Color.FromArgb(145, 145, 145);
            if (Globals.isManager)
            {
                Load_EmployeeDataForm(this, EventArgs.Empty);
            }
            else
            {
                Clear_To_HomeScreen();
                MessageBox.Show("Needs Manager access");
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) 
        {
            if (keyData == Keys.F1)
            {
                Moving_Cars_Button_Click(this,EventArgs.Empty);
            }
            if (keyData == Keys.F2)
            {
                Adding_Cars_Button_Click(this, EventArgs.Empty);
            }
            if (keyData == Keys.F3)
            {
                Selling_Cars_Button_Click(this, EventArgs.Empty);
            }
            if (keyData == Keys.F4)
            {
                Staff_Button_Click(this, EventArgs.Empty);
            }
            if (keyData == Keys.F5)
            {
                Customers_Button_Click(this, EventArgs.Empty);
            }
            if (keyData == Keys.F6)
            {
                Payment_Button_Click(this, EventArgs.Empty);
            }
            if (keyData == Keys.F7)
            {
                Login_Button_Click(this, EventArgs.Empty);
            }

            if (sidebarEvents == null)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            if (keyData == (Keys.F1 | Keys.Shift) && sidebarEvents[0] != null)
            {
                sidebarEvents[0](this, EventArgs.Empty);
            }
            if (keyData == (Keys.F2 | Keys.Shift) && sidebarEvents[1] != null)
            {
                sidebarEvents[1](this, EventArgs.Empty);
            }
            if (keyData == (Keys.F3 | Keys.Shift) && sidebarEvents[2] != null)
            {
                sidebarEvents[2](this, EventArgs.Empty);
            }
            if (keyData == (Keys.F4 | Keys.Shift) && sidebarEvents[3] != null)
            {
                sidebarEvents[3](this, EventArgs.Empty);
            }
            if (keyData == (Keys.F5 | Keys.Shift) && sidebarEvents[4] != null)
            {
                sidebarEvents[4](this, EventArgs.Empty);
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void Car_Servicing_Button_Click(object sender, EventArgs e)
        {
            Wipe_Panel();
            Reset_Sidebar_Highlights();
            Car_Servicing_Button.BackColor = Color.FromArgb(145, 145, 145);
        }

        private void Sidebar_FlowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Taskbar_FlowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Filler_Button2_PictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
